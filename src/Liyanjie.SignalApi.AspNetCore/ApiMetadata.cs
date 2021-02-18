using System.Collections.Generic;

namespace Liyanjie.SignalApi.AspNetCore
{
    /// <summary>
    /// 
    /// </summary>
    public class ApiMetadata
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="apiDescriptor"></param>
        /// <param name="filters"></param>
        public ApiMetadata(
            ApiDescriptor apiDescriptor,
            IEnumerable<IFilterMetadata> filters)
        {
            this.ApiDescriptor = apiDescriptor;
            this.Filters = filters;
        }

        /// <summary>
        /// 
        /// </summary>
        public ApiDescriptor ApiDescriptor { get; }

        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<IFilterMetadata> Filters { get; }
    }
}
