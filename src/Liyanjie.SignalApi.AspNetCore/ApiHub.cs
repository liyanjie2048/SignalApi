using System;
using System.Linq;
using System.Threading.Tasks;

using Liyanjie.SignalApi.Common;

using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;

namespace Liyanjie.SignalApi.AspNetCore
{
    public class ApiHub : Hub<IApiClient>, IApiHub
    {
        readonly IServiceProvider serviceProvider;
        readonly ApiRegistration apiRegistration;
        public ApiHub(
            IServiceProvider serviceProvider,
            ApiRegistration apiRegistration)
        {
            this.serviceProvider = serviceProvider;
            this.apiRegistration = apiRegistration;
        }

        public async Task CallApi(SignalCall call)
        {
            await Clients.Caller.Trace($"Client call [{call.Method}] received");

            var context = await BuildContextAsync(call);

            if (!await apiRegistration.AuthorizationProvider.CheckAuthorizedAsync(context))
            {
                await Clients.Caller.Error("UnAuthorized");
                return;
            }

            var parameters = context.ApiMetadata.ApiDescriptor.Info.GetParameters()
                .Select(_ =>
#if NETCOREAPP3_0 || NET5_0
                    System.Text.Json.JsonSerializer.Deserialize(((System.Text.Json.JsonElement)call.Parameters).GetRawText(), _.ParameterType)
#else
                    (call.Parameters as Newtonsoft.Json.Linq.JObject)?.ToObject(_.ParameterType)
#endif
                )
                .ToArray();
            if (apiRegistration.ValidationProvider != null)
                if (!await apiRegistration.ValidationProvider.ValidateAsync(parameters))
                {
                    await Clients.Caller.Error("ValidationError", errors: apiRegistration.ValidationProvider.Errors);
                    return;
                }

            try
            {
                var service = ActivatorUtilities.GetServiceOrCreateInstance(serviceProvider, context.ApiMetadata.ApiDescriptor.Info.DeclaringType) as ServiceBase;
                service.Context = context;

                var excutingContext = new ApiExecutingContext(context, service, parameters);
                if (!await OnExecutingAsync(excutingContext))
                    return;

                var result = await ExecuteAsync(excutingContext);

                var executedContext = new ApiExecutedContext(excutingContext, result);
                if (!await OnExecutedAsync(executedContext))
                    return;

                if (!string.IsNullOrEmpty(call.Callback))
                    await Clients.Caller.Handle(new SignalResult
                    {
                        Method = call.Callback,
                        Data = executedContext.Result,
                    });
            }
            catch (Exception exception)
            {
                var exceptionContext = new ApiExceptionContext(context, exception);
                if (await HandleExceptionAsync(exceptionContext))
                    await Clients.Caller.Error(exception.Message, exception.HResult);
            }
        }

        async Task<ApiCallContext> BuildContextAsync(SignalCall call)
        {
            var apiDescriptor = apiRegistration.ApiCollections.SingleOrDefault(_ => _.Name == call.Method);
            if (apiDescriptor == null)
                throw new Exception($"Could not find descriptor by method \"{call.Method}\"");

            var apiMetadata = new ApiMetadata(
                apiDescriptor,
                apiDescriptor.FilterTypes
                    .Select(_ => ActivatorUtilities.GetServiceOrCreateInstance(serviceProvider, _))
                    .Where(_ => _ is IFilterMetadata)
                    .Cast<IFilterMetadata>()
                    .Union(apiRegistration.GlobalFilters)
            );
            var user = await apiRegistration.AuthenticationProvider.GetUserAsync(call.AccessToken);

            return new ApiCallContext(Context.ConnectionId, apiMetadata, user);
        }
        static async Task<bool> OnExecutingAsync(ApiExecutingContext context)
        {
            var continued = true;

            var filters = context.ApiMetadata.Filters;
            if (filters.Any(_ => _ is IApiCallFilter))
            {
                var apiCallFilters = filters
                    .Where(_ => _ is IApiCallFilter)
                    .OrderBy(_ => _ is IOrderedFilter o ? o.Order : 0)
                    .Cast<IApiCallFilter>();
                foreach (var filter in apiCallFilters)
                {
                    continued = await filter.OnExecutingAsync(context);
                    if (!continued)
                    {
                        break;
                    }
                }
            }

            return continued;
        }
        static async Task<object> ExecuteAsync(ApiExecutingContext excutingContext)
        {
            object result = null;

            var methodInfo = excutingContext.ApiMetadata.ApiDescriptor.Info;
            var obj = methodInfo.Invoke(excutingContext.Service, excutingContext.Parameters);
            if (obj is Task task)
            {
                if (methodInfo.ReturnType.IsGenericType)
                    await task.ContinueWith(_task =>
                    {
                        result = _task.GetType().GetProperty("Result").GetValue(_task);
                    });
                else
                    await task;
            }
            else
                result = obj;
            return result;
        }
        static async Task<bool> OnExecutedAsync(ApiExecutedContext context)
        {
            var continued = true;

            var filters = context.ApiMetadata.Filters;
            if (filters.Any(_ => _ is IApiCallFilter))
            {
                var apiCallFilters = filters
                    .Where(_ => _ is IApiCallFilter)
                    .OrderBy(_ => _ is IOrderedFilter o ? o.Order : 0)
                    .Cast<IApiCallFilter>();
                foreach (var filter in apiCallFilters)
                {
                    continued = await filter.OnExecutedAsync(context);
                    if (!continued)
                    {
                        break;
                    }
                }
            }

            return continued;
        }
        static async Task<bool> HandleExceptionAsync(ApiExceptionContext context)
        {
            var continued = true;

            var filters = context.ApiMetadata.Filters;
            if (filters.Any(_ => _ is IExceptionFilter))
            {
                var exceptionFilters = filters
                    .Where(_ => _ is IExceptionFilter)
                    .OrderBy(_ => _ is IOrderedFilter o ? o.Order : 0)
                    .Cast<IExceptionFilter>();
                foreach (var filter in exceptionFilters)
                {
                    continued = await filter.HandleAsync(context);
                    if (!continued)
                    {
                        break;
                    }
                }
            }

            return continued;
        }
    }
}
