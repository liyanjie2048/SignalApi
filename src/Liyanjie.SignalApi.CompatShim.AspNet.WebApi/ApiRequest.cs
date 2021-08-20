using System.Collections.Generic;

namespace Liyanjie.SignalApi.CompatShim
{
    /// <summary>
    /// 
    /// </summary>
    public class ApiRequest 
    {
        /// <summary>
        /// 
        /// </summary>
        public string HttpMethod { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Dictionary<string, string[]> Headers { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Body { get; set; }
    }
}
