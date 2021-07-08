# SignalApi

一系列帮助类及扩展方法、小组件等

- #### Liyanjie.SignalApi.Common
    Code认证
  - IApiClient
  - IApiHub
  - SignalCall
  - SignalResult
- #### Liyanjie.SignalApi.AspNetCore
  - Usage
    ```csharp
    //services is IServiceCollection
    services.AddSignalR()
        .AddJsonProtocol();
    services.AddSignalApi(apis =>
    {
        apis.RegisterApisFromAssemblyByClass<Startup>()
            .AddAuthenticationProvider<TAuthenticationProvider>()
            .AddAuthorizationProvider<TAuthorizationProvider>()
            .AddValidationProvider<TValidationProvider>();
    });
    //endpoints is IEndpointRouteBuilder
    endpoints.MapSignalApi(string path = "/signalApi");
    ```
- #### Liyanjie.SignalApi.AspNetCore.FluentValidation
  - Usage
    ```csharp
    //services is IServiceCollection
    services.AddSignalApi(apis =>
    {
        apis.RegisterApisFromAssemblyByClass<Startup>()
            .AddFluentValidationFromAssemblyByClass<TClass>();
    });
    ```
- #### Liyanjie.SignalApi.CompatShim.AspNetCoreMvc
  - Usage
    ```csharp
    //endpoints is IEndpointRouteBuilder
    endpoints.MapSignalApi(string path = "/signalApi");
    ```
- #### Liyanjie.SignalApi.CompatShim.AspNetWebApi
  - Usage
    ```csharp
    using Microsoft.Owin;
    using Owin;
    [assembly: OwinStartup(typeof(Liyanjie.SignalApi.CompatShim.Sample.AspNetWebApi.Startup))]
    namespace AspNetWebApi
    {
        public class Startup
        {
            public void Configuration(IAppBuilder app)
            {
                app.MapSignalR("/api-gateway", new Microsoft.AspNet.SignalR.HubConfiguration());
            }
        }
    }
    ```