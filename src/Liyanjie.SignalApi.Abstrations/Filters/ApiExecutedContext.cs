namespace Liyanjie.SignalApi.Abstrations
{
    public class ApiExecutedContext : ApiExecutingContext
    {
        public ApiExecutedContext(
            ApiExecutingContext context,
            object result)
            : base(context, context.Service, context.Parameters)
        {
            this.Result = result;
        }

        public virtual object Result { get; }
    }
}
