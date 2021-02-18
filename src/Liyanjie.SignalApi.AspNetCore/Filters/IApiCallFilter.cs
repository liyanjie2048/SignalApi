using System.Threading.Tasks;

namespace Liyanjie.SignalApi.AspNetCore
{
    /// <summary>
    /// 
    /// </summary>
    public interface IApiCallFilter:IFilterMetadata
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        Task<bool> OnExecutingAsync(ApiExecutingContext context);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        Task<bool> OnExecutedAsync(ApiExecutedContext context);
    }
}
