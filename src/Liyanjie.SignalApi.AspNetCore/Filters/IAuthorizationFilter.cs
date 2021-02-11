using System.Threading.Tasks;

namespace Liyanjie.SignalApi.AspNetCore
{
    /// <summary>
    /// A filter that confirms request authorization.
    /// </summary>
    public interface IAuthorizationFilter : IFilterMetadata
    {
        Task<bool> AuthorizeAsync(ApiCallContext context);
    }
}
