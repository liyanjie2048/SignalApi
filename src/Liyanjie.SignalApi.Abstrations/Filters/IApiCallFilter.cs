using System.Threading.Tasks;

namespace Liyanjie.SignalApi.Abstrations
{
    public interface IApiCallFilter:IFilterMetadata
    {
        Task<bool> OnExecutingAsync(ApiExecutingContext context);

        Task<bool> OnExecutedAsync(ApiExecutedContext context);
    }
}
