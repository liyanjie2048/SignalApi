namespace Liyanjie.SignalApi.AspNetCore
{
    /// <summary>
    /// 
    /// </summary>
    public class ApiExecutingContext : ApiCallContext
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="service"></param>
        /// <param name="parameters"></param>
        public ApiExecutingContext(
           ApiCallContext context,
           object service,
           object[] parameters)
           : base(context.ConnectionId, context.ApiMetadata, context.User)
        {
            this.Service = service;
            this.Parameters = parameters;
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual object Service { get; }

        /// <summary>
        /// 
        /// </summary>
        public virtual object[] Parameters { get; }
    }
}
