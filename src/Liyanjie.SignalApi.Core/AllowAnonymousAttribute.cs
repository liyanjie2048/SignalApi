using System;
using System.Collections.Generic;
using System.Text;

namespace Liyanjie.SignalApi.Core
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class AllowAnonymousAttribute : Attribute, IAllowAnonymous
    {
    }
}
