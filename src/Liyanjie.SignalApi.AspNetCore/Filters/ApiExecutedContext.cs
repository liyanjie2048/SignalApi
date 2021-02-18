namespace Liyanjie.SignalApi.AspNetCore
{
    /// <summary>
    /// 
    /// </summary>
    public class ApiExecutedContext : ApiExecutingContext
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="result"></param>
        public ApiExecutedContext(
            ApiExecutingContext context,
            object result)
            : base(context, context.Service, context.Parameters)
        {
            this.Result = result;
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual object Result { get; }
    }
}
