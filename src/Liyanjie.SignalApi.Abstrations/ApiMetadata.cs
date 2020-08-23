using System.Collections.Generic;

namespace Liyanjie.SignalApi.Abstrations
{
    public class ApiMetadata
    {
        public ApiMetadata(
            ApiDescriptor apiDescriptor,
            IEnumerable<IFilterMetadata> filters)
        {
            this.ApiDescriptor = apiDescriptor;
            this.Filters = filters;
        }
        public ApiDescriptor ApiDescriptor { get; }
        public IEnumerable<IFilterMetadata> Filters { get; }
    }
}
