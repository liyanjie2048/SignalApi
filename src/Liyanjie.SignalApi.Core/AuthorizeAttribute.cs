using System;
using System.Collections.Generic;
using System.Text;

namespace Liyanjie.SignalApi.Core
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class AuthorizeAttribute : Attribute, IAuthorizeData
    {
        public AuthorizeAttribute() { }

        public AuthorizeAttribute(string policy)
        {
            Policy = policy;
        }

        public string Policy { get; set; }

        public string Roles { get; set; }
    }
}
