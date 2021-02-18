using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace Liyanjie.SignalApi.AspNetCore
{
    /// <summary>
    /// 
    /// </summary>
    public class DefaultAuthenticationProvider : IAuthenticationProvider
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public virtual async Task<IPrincipal> GetUserAsync(string accessToken)
        {
            await Task.FromResult(0);

            return new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {

            }, "Default"));
        }
    }
}
