using System;

namespace Liyanjie.SignalApi.Abstrations
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class ApiMethodAttribute : Attribute
    {
        public ApiMethodAttribute(string name)
        {
            this.Name = name;
        }

        public string Name { get; }
    }
}
