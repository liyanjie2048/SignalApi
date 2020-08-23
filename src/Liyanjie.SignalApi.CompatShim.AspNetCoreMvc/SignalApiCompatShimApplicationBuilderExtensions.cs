#if NETSTANDARD2_0 || NETCOREAPP3_0
using System;

using Liyanjie.SignalApi.CompatShim;

namespace Microsoft.AspNetCore.Builder
{
    public static class SignalApiCompatShimApplicationBuilderExtensions
    {
#if NETCOREAPP3_0
        [Obsolete]
#endif
        public static IApplicationBuilder UseSignalApi(this IApplicationBuilder app,
            string path = "/signalApi")
        {
            app.UseSignalR(builder =>
            {
                builder.MapHub<ApiHub>(path);
            });

            return app;
        }
    }
}
#endif