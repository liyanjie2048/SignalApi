using System;

namespace Liyanjie.SignalApi.AspNetCore
{
    /// <summary>
    /// 
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class ApiMethodAttribute : Attribute
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        public ApiMethodAttribute(string name)
        {
            this.Name = name;
        }

        /// <summary>
        /// 
        /// </summary>
        public string Name { get; }
    }
}
