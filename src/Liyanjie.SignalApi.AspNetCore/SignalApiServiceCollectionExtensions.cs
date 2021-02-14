using System;

using Liyanjie.SignalApi.AspNetCore;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class SignalApiServiceCollectionExtensions
    {
        public static ApiRegistration AddSignalApi(this IServiceCollection services,
            Action<ApiRegistration> configureApis)
        {
            if (configureApis == null)
                throw new ArgumentNullException(nameof(configureApis));

            var apiRegistration = new ApiRegistration(services);
            configureApis.Invoke(apiRegistration);

            services
                .AddSingleton(apiRegistration)
                .AddScoped<IAuthenticationProvider, DefaultAuthenticationProvider>()
                .AddScoped<IAuthorizationProvider, DefaultAuthorizationProvider>();

            return apiRegistration;
        }

        public static ApiRegistration AddAuthenticationProvider<TAuthenticationProvider>(this ApiRegistration registration)
            where TAuthenticationProvider : class, IAuthenticationProvider
        {
            registration.Services.AddScoped<IAuthenticationProvider, TAuthenticationProvider>();

            return registration;
        }
        public static ApiRegistration AddAuthorizationProvider<TAuthorizationProvider>(this ApiRegistration registration)
            where TAuthorizationProvider : class, IAuthorizationProvider
        {
            registration.Services.AddScoped<IAuthorizationProvider, TAuthorizationProvider>();

            return registration;
        }
        public static ApiRegistration AddValidationProvider<TValidationProvider>(this ApiRegistration registration)
            where TValidationProvider : class, IValidationProvider
        {
            registration.Services.AddScoped<IValidationProvider, TValidationProvider>();

            return registration;
        }
    }
}
