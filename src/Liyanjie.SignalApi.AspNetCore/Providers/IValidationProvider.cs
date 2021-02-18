using System.Collections.Generic;
using System.Threading.Tasks;

namespace Liyanjie.SignalApi.AspNetCore
{
    /// <summary>
    /// 
    /// </summary>
    public interface IValidationProvider
    {
        /// <summary>
        /// 
        /// </summary>
        IDictionary<string,string[]> Errors { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        Task<bool> ValidateAsync(object[] parameters);
    }
}
