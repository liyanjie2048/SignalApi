using System;
using System.Threading.Tasks;

namespace Liyanjie.SignalApi.AspNetCore
{
    /// <summary>
    /// A filter that runs after an api has thrown an <see cref="System.Exception"/>.
    /// </summary>
    public interface IExceptionFilter : IFilterMetadata
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        Task<bool> HandleAsync(ApiExceptionContext context);
    }
}
