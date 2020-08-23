using System.Security.Principal;

namespace Liyanjie.SignalApi.Abstrations
{
    public class ApiCallContext
    {
        public ApiCallContext(
            string connectionId,
            ApiMetadata apiMetadata,
            IPrincipal user)
        {
            this.ConnectionId = connectionId;
            this.ApiMetadata = ApiMetadata;
            this.User = user;
        }

        public string ConnectionId { get; }
        public ApiMetadata ApiMetadata { get; }
        public IPrincipal User { get; }
    }
}
