using System.Collections.Generic;

namespace Liyanjie.SignalApi.CompatShim.AspNetCoreMvc
{
    public class ApiRequest
    {
        public string HttpMethod { get; set; }
        public Dictionary<string, IEnumerable<string>> Headers { get; set; }
        public string Body { get; set; }
    }
}
