using Liyanjie.SignalApi.Abstrations;

namespace System.Web
{
    public static class SignalApiHttpApplicationExtensions
    {
        /// <summary>
        /// Add in Global.Application_Start (Use DI)
        /// </summary>
        /// <param name="app"></param>
        /// <param name="configureApis"></param>
        /// <returns></returns>
        public static HttpApplication AddSignalApi(this HttpApplication app,
            Action<ApiRegistration> configureApis,
            Action<Type, Func<IServiceProvider, object>, string> registerServiceImplementationFactory)
        {
            if (configureApis == null)
                throw new ArgumentNullException(nameof(configureApis));

            var _apiRegistration = new ApiRegistration(); 
            configureApis.Invoke(_apiRegistration);

            registerServiceImplementationFactory.Invoke(typeof(ApiRegistration), serviceProvider => _apiRegistration, "Singleton");

            return app;
        }

        readonly static ApiRegistration apiRegistration = new ApiRegistration();
        /// <summary>
        /// Add in Global.Application_Start (Static Mode)
        /// </summary>
        /// <param name="app"></param>
        /// <param name="configureApis"></param>
        /// <returns></returns>
        public static HttpApplication AddSignalApi(this HttpApplication app,
            Action<ApiRegistration> configureApis)
        {
            if (configureApis == null)
                throw new ArgumentNullException(nameof(configureApis));

            configureApis.Invoke(apiRegistration);

            return app;
        }
    }
}
