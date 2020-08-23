using System;
using System.Collections.Generic;
using System.Reflection;

namespace Liyanjie.SignalApi.Abstrations
{
    public  class ApiDescriptor
    {
        public string Name { get; set; }
        public MethodInfo Info { get; set; }
        public IEnumerable<Type> FilterTypes { get; set; }
    }
}
