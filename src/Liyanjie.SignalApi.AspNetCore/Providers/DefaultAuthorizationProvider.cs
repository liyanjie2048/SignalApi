using System.Linq;
using System.Threading.Tasks;

namespace Liyanjie.SignalApi.AspNetCore
{
    /// <summary>
    /// 
    /// </summary>
    public class DefaultAuthorizationProvider : IAuthorizationProvider
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public virtual async Task<bool> CheckAuthorizedAsync(ApiCallContext context)
        {
            var authorized = true;

            var filters = context.ApiMetadata.Filters;
            if (filters.Any(_ => _ is IAuthorizationFilter) && !filters.Any(_ => _ is IAllowAnonymousFilter))
            {
                var authorizationFilters = filters
                    .Where(_ => _ is IAuthorizationFilter)
                    .OrderBy(_ => _ is IOrderedFilter o ? o.Order : 0)
                    .Cast<IAuthorizationFilter>();
                foreach (var filter in authorizationFilters)
                {
                    authorized = await filter.AuthorizeAsync(context);
                    if (!authorized)
                    {
                        break;
                    }
                }
            }

            return authorized;
        }
    }
}
