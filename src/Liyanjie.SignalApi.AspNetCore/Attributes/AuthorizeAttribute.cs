using System;
using System.Threading.Tasks;

namespace Liyanjie.SignalApi.AspNetCore
{
    /// <summary>
    /// 
    /// </summary>
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public virtual Task<bool> AuthorizeAsync(ApiCallContext context)
        {
            return Task.FromResult(context.User.Identity.IsAuthenticated);
        }
    }
}
