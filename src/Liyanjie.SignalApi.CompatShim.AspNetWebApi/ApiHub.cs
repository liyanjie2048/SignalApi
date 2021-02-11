using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

using Liyanjie.SignalApi.Common;

using Microsoft.AspNet.SignalR;

namespace Liyanjie.SignalApi.CompatShim
{
    public class ApiHub : Hub<IApiClient>, IApiHub
    {
        public async Task CallApi(SignalCall call)
        {
            await Clients.Caller.Trace($"Client call [{call.Method}] received");

            var data = (call.Parameters as Newtonsoft.Json.Linq.JObject)?.ToObject<ApiRequest>() ?? new ApiRequest();
            data.Headers.Add(HeaderKeys.ConnectionId, new[] { Context.ConnectionId });

            try
            {
                var request = CreateRequest(call.Method, data.HttpMethod, data.Headers, data.Body);
                var response = await GetResponse(request);

                await Clients.Caller.Trace($"Client call [{call.Method}] done: {response.StatusCode}");

                if (response.IsSuccessStatusCode)
                {
                    if (!string.IsNullOrEmpty(call.Callback))
                        await Clients.Caller.Handle(new SignalResult
                        {
                            Method = call.Callback,
                            Data = new
                            {
                                Headers = response.Headers.ToDictionary(_ => _.Key, _ => _.Value),
                                Body = await response.Content.ReadAsStringAsync(),
                            },
                        });
                }
                else
                    await Clients.Caller.Error(response.StatusCode.ToString(), (int)response.StatusCode);
            }
            catch (Exception ex)
            {
                await Clients.Caller.Error(ex.Message, ex.HResult);
            }
        }

        public override async Task OnConnected()
        {
            await base.OnConnected();

            await Clients.Caller.Trace($"Client connected:{Context.ConnectionId}");
        }

        public override async Task OnReconnected()
        {
            await base.OnReconnected();

            await Clients.Caller.Trace($"Client reconnected:{Context.ConnectionId}");
        }

        static HttpRequestMessage CreateRequest(
            string url,
            string method,
            IReadOnlyDictionary<string, string[]> headers,
            string data)
        {
            var request = new HttpRequestMessage(new HttpMethod(method), url);
            foreach (var header in headers)
            {
                request.Headers.TryAddWithoutValidation(header.Key, header.Value);
            }
            if ("POST,PUT,PATCH".IndexOf(method.ToUpper()) > -1)
            {
                request.Content = new StringContent(data);
                request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json; charset=utf-8");
            }
            return request;
        }
        static async Task<HttpResponseMessage> GetResponse(HttpRequestMessage request)
        {
            using var http = new HttpClient();
            return await http.SendAsync(request);
        }
    }
}
