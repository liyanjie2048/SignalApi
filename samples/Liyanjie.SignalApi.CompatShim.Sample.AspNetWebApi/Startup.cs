using Microsoft.Owin;

using Owin;

[assembly: OwinStartup(typeof(Liyanjie.SignalApi.CompatShim.Sample.AspNetWebApi.Startup))]
namespace Liyanjie.SignalApi.CompatShim.Sample.AspNetWebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // 有关如何配置应用程序的详细信息，请访问 https://go.microsoft.com/fwlink/?LinkID=316888
            app.MapSignalR("/api-gateway", new Microsoft.AspNet.SignalR.HubConfiguration());
        }
    }
}
