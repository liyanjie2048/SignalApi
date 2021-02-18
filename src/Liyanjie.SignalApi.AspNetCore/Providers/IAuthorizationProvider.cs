using System.Threading.Tasks;

namespace Liyanjie.SignalApi.AspNetCore
{
    /// <summary>
    /// 
    /// </summary>
    public interface IAuthorizationProvider
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="callContext"></param>
        /// <returns></returns>
        Task<bool> CheckAuthorizedAsync(ApiCallContext callContext);
    }
}
