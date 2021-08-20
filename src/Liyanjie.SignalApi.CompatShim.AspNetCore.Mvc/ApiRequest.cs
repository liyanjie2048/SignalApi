using System.Collections.Generic;

namespace Liyanjie.SignalApi.CompatShim
{
    public class ApiRequest
    {
        public string HttpMethod { get; set; }
        public Dictionary<string, string[]> Headers { get; set; }
        public string Body { get; set; }
    }
}
