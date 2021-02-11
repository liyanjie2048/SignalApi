using System.Threading.Tasks;

namespace Liyanjie.SignalApi.AspNetCore
{
    public interface IApiCallFilter:IFilterMetadata
    {
        Task<bool> OnExecutingAsync(ApiExecutingContext context);

        Task<bool> OnExecutedAsync(ApiExecutedContext context);
    }
}
