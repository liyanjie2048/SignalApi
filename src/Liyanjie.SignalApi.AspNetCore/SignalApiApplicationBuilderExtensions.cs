#if NETSTANDARD2_0 || NETCOREAPP3_0
using System;

using Liyanjie.SignalApi.AspNetCore;

namespace Microsoft.AspNetCore.Builder
{
    public static class SignalApiApplicationBuilderExtensions
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