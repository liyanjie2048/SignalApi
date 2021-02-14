using FluentValidation;

using Liyanjie.SignalApi.AspNetCore;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class FluentValidationServiceCollectionExtensions
    {
        public static ApiRegistration AddFluentValidationFromAssemblyByClass<TClass>(this ApiRegistration registration)
        {
            registration.Services.AddValidatorsFromAssemblyContaining<TClass>();

            return registration;
        }
    }
}
