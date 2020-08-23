using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace Liyanjie.SignalApi.Core
{
    //filter
    //validate
    //serviceprovider
    public abstract class ApiControllerBase
    {
        protected IPrincipal User { get; }
    }
}
