using System;

using Liyanjie.SignalApi.Abstrations;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class SignalApiServiceCollectionExtensions
    {
        public static IServiceCollection AddSignalApi(this IServiceCollection services,
            Action<ApiRegistration> configureApis)
        {
            if (configureApis == null)
                throw new ArgumentNullException(nameof(configureApis));

            var apiRegistration = new ApiRegistration();
            configureApis.Invoke(apiRegistration);

            services.AddSingleton(apiRegistration);

            return services;
        }
    }
}
