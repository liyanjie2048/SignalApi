using System.Security.Principal;
using System.Threading.Tasks;

namespace Liyanjie.SignalApi.Abstrations
{
    public interface IAuthenticationProvider
    {
        Task<IPrincipal> GetUserAsync(string accessToken);
    }
}
