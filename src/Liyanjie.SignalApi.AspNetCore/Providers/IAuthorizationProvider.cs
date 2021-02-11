using System.Threading.Tasks;

namespace Liyanjie.SignalApi.AspNetCore
{
    public interface IAuthorizationProvider
    {
        Task<bool> CheckAuthorizedAsync(ApiCallContext callContext);
    }
}
