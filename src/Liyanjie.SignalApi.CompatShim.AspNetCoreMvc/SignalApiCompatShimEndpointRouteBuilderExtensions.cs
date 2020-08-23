#if NETCOREAPP3_0 || NET5_0
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.AspNetCore.Builder
{
    /// <summary>
    /// 
    /// </summary>
    public static class SignalApiCompatShimEndpointRouteBuilderExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="endpoints"></param>
        /// <returns></returns>
        public static IEndpointRouteBuilder MapSignalApi(this IEndpointRouteBuilder endpoints,
            string path = "/signalApi")
        {
            endpoints.MapHub<Liyanjie.SignalApi.CompatShim.ApiHub>(path);

            return endpoints;
        }
    }
}
#endif
