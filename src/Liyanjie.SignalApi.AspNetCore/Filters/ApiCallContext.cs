using System.Security.Principal;

namespace Liyanjie.SignalApi.AspNetCore
{
    /// <summary>
    /// 
    /// </summary>
    public class ApiCallContext
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionId"></param>
        /// <param name="apiMetadata"></param>
        /// <param name="user"></param>
        public ApiCallContext(
            string connectionId,
            ApiMetadata apiMetadata,
            IPrincipal user)
        {
            this.ConnectionId = connectionId;
            this.ApiMetadata = apiMetadata;
            this.User = user;
        }

        /// <summary>
        /// 
        /// </summary>
        public string ConnectionId { get; }

        /// <summary>
        /// 
        /// </summary>
        public ApiMetadata ApiMetadata { get; }

        /// <summary>
        /// 
        /// </summary>
        public IPrincipal User { get; }
    }
}
