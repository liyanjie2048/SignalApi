using System;
using System.Diagnostics;
using System.Reflection;

namespace Microsoft.AspNetCore.Mvc.ApplicationModels
{
    public class ParameterModel
    {
        public ParameterModel(ParameterInfo parameterInfo)
        {
            ParameterInfo = parameterInfo ?? throw new ArgumentNullException(nameof(parameterInfo));
        }

        public Type ParameterType { get; }

        public string ParameterName { get;  set; }

        public ParameterInfo ParameterInfo { get; }
    }
}
