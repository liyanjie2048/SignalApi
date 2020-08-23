using System.Threading.Tasks;

namespace Liyanjie.SignalApi.Common
{
    public interface IApiClient
    {
        Task Handle(SignalCall call);
    }
}
