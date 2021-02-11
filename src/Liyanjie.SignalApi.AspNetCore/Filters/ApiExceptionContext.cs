using System;

namespace Liyanjie.SignalApi.AspNetCore
{
    public class ApiExceptionContext : ApiCallContext
    {
        public ApiExceptionContext(
            ApiCallContext context,
            Exception exception)
            : base(context.ConnectionId, context.ApiMetadata, context.User)
        {
            this.Exception = exception;
        }

        public virtual Exception Exception { get; }
    }
}
