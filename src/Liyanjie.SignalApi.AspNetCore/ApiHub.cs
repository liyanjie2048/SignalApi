using System.Threading.Tasks;

using Liyanjie.SignalApi.Common;
using Liyanjie.SignalApi.Core;

namespace Liyanjie.SignalApi.AspNetCore
{
    public class ApiHub : Microsoft.AspNetCore.SignalR.Hub<IApiClient>
    {
        public async Task<SignalResult> DispatchAsync(SignalCall call)
        {


            //find controller.action
            //handle filter
            //build parameter
            //execute method
            //respond result
            await Clients.Caller.Handle(new SignalCall
            {
                Method = "Msg",
                Data = $"received client call:{call.Data}",
            });
            return new SignalResult
            {
                Code = "0",
                Data = $"client call:{call.Data}"
            };

            System.Reflection.MethodInfo mi = null;
            //mi.Invoke()
        }
    }
}
