using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Liyanjie.SignalApi.Core
{
    class ApiMethod
    {
        public string Name { get; set; }
        public MethodInfo Info { get; set; }
        public Type DeclaringType { get; set; }
        public IEnumerable<Type> ParameterTypes { get; set; }
        public IEnumerable<object> Filters { get; set; }
    }
}
