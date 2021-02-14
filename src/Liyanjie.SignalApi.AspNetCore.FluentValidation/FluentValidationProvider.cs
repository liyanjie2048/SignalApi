using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using FluentValidation;

namespace Liyanjie.SignalApi.AspNetCore.FluentValidation
{
    public class FluentValidationProvider : IValidationProvider
    {
        readonly IValidatorFactory validatorFactory;

        public FluentValidationProvider(IValidatorFactory validatorFactory)
        {
            this.validatorFactory = validatorFactory;
        }

        public IDictionary<string, string[]> Errors { get; private set; }

        public async Task<bool> ValidateAsync(object[] parameters)
        {
            var validated = true;
            foreach (var parameter in parameters)
            {
                var parameterType = parameter.GetType();
                var validationContext = Activator.CreateInstance(typeof(ValidationContext<>).MakeGenericType(parameterType), parameters) as IValidationContext;
                var validator = validatorFactory.GetValidator(parameter.GetType());
                var result = await validator.ValidateAsync(validationContext);
                validated = result.IsValid;
                if (!validated)
                {
                    Errors = result.Errors
                        .GroupBy(_ => _.PropertyName)
                        .ToDictionary(_ => _.Key, _ => _.Select(__ => __.ErrorMessage).ToArray());
                    break;
                }
            }
            return validated;
        }
    }
}
