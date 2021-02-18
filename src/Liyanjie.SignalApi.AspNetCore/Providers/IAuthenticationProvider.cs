using System.Security.Principal;
using System.Threading.Tasks;

namespace Liyanjie.SignalApi.AspNetCore
{
    /// <summary>
    /// 
    /// </summary>
    public interface IAuthenticationProvider
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        Task<IPrincipal> GetUserAsync(string accessToken);
    }
}
