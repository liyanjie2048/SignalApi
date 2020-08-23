namespace Liyanjie.SignalApi.Abstrations
{
    public class ApiExecutingContext : ApiCallContext
    {
        public ApiExecutingContext(
           ApiCallContext context,
           object service,
           object[] parameters)
           : base(context.ConnectionId, context.ApiMetadata, context.User)
        {
            this.Service = service;
            this.Parameters = parameters;
        }

        public virtual object Service { get; }
        public virtual object[] Parameters { get; }
    }
}
