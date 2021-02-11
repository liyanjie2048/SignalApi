using System;
using System.Threading.Tasks;

namespace Liyanjie.SignalApi.AspNetCore
{
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public virtual Task<bool> AuthorizeAsync(ApiCallContext context)
        {
            return Task.FromResult(context.User.Identity.IsAuthenticated);
        }
    }
}
