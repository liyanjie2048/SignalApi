using System.Threading.Tasks;

namespace Liyanjie.SignalApi.Common
{
    public interface IApiHub
    {
        Task CallApi(SignalCall call);
    }
}
