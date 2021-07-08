using System;

using Liyanjie.SignalApi.AspNetCore;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// 
    /// </summary>
    public static class SignalApiServiceCollectionExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configureApis"></param>
        /// <returns></returns>
        public static IServiceCollection AddSignalApi(this IServiceCollection services,
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

            return services;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TAuthenticationProvider"></typeparam>
        /// <param name="registration"></param>
        /// <returns></returns>
        public static ApiRegistration AddAuthenticationProvider<TAuthenticationProvider>(this ApiRegistration registration)
            where TAuthenticationProvider : class, IAuthenticationProvider
        {
            registration.Services.AddScoped<IAuthenticationProvider, TAuthenticationProvider>();

            return registration;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TAuthorizationProvider"></typeparam>
        /// <param name="registration"></param>
        /// <returns></returns>
        public static ApiRegistration AddAuthorizationProvider<TAuthorizationProvider>(this ApiRegistration registration)
            where TAuthorizationProvider : class, IAuthorizationProvider
        {
            registration.Services.AddScoped<IAuthorizationProvider, TAuthorizationProvider>();

            return registration;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TValidationProvider"></typeparam>
        /// <param name="registration"></param>
        /// <returns></returns>
        public static ApiRegistration AddValidationProvider<TValidationProvider>(this ApiRegistration registration)
            where TValidationProvider : class, IValidationProvider
        {
            registration.Services.AddScoped<IValidationProvider, TValidationProvider>();

            return registration;
        }
    }
}
