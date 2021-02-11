using System.Collections.Generic;
using System.Threading.Tasks;

namespace Liyanjie.SignalApi.Common
{
    public interface IApiClient
    {
        Task Trace(string message);
        Task Handle(SignalResult result);
        Task Error(string message, int code = 0, IDictionary<string, string[]> errors = null);
    }
}
