using System;
using System.Collections.Generic;
using System.Reflection;

namespace Liyanjie.SignalApi.AspNetCore
{
    /// <summary>
    /// 
    /// </summary>
    public  class ApiDescriptor
    {
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public MethodInfo Info { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<Type> FilterTypes { get; set; }
    }
}
