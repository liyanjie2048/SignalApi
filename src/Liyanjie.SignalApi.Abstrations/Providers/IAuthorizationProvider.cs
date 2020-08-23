using System.Threading.Tasks;

namespace Liyanjie.SignalApi.Abstrations
{
    public interface IAuthorizationProvider
    {
        Task<bool> CheckAuthorizedAsync(ApiCallContext callContext);
    }
}
