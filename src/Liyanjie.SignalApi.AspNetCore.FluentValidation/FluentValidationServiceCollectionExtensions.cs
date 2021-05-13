using FluentValidation;

using Liyanjie.SignalApi.AspNetCore;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// 
    /// </summary>
    public static class FluentValidationServiceCollectionExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TClass"></typeparam>
        /// <param name="registration"></param>
        /// <returns></returns>
        public static ApiRegistration AddFluentValidationFromAssemblyByClass<TClass>(this ApiRegistration registration)
        {
            registration.Services.AddValidatorsFromAssemblyContaining<TClass>();

            return registration;
        }
    }
}
