using System;

namespace Liyanjie.SignalApi.Core
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class ApiMethodAttribute : Attribute
    {
        public string Name { get; set; }
    }
}
