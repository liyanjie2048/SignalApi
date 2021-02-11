using System.Collections.Generic;
using System.Threading.Tasks;

namespace Liyanjie.SignalApi.AspNetCore
{
    public interface IValidationProvider
    {
        IDictionary<string,string[]> Errors { get; }
        Task<bool> ValidateAsync(object[] parameters);
    }
}
