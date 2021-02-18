using System;

namespace Liyanjie.SignalApi.AspNetCore
{
    /// <summary>
    /// 
    /// </summary>
    public class ApiExceptionContext : ApiCallContext
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="exception"></param>
        public ApiExceptionContext(
            ApiCallContext context,
            Exception exception)
            : base(context.ConnectionId, context.ApiMetadata, context.User)
        {
            this.Exception = exception;
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual Exception Exception { get; }
    }
}
