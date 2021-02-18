using System.Threading.Tasks;

namespace Liyanjie.SignalApi.AspNetCore
{
    /// <summary>
    /// A filter that confirms request authorization.
    /// </summary>
    public interface IAuthorizationFilter : IFilterMetadata
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        Task<bool> AuthorizeAsync(ApiCallContext context);
    }
}
