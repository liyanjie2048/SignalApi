using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace Liyanjie.SignalApi.Abstrations
{
    public class DefaultAuthenticationProvider : IAuthenticationProvider
    {
        public async Task<IPrincipal> GetUserAsync(string accessToken)
        {
            await Task.FromResult(0);

            return new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {

            }, "Default"));
        }
    }
}
