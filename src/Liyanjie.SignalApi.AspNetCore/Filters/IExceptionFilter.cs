using System;
using System.Threading.Tasks;

namespace Liyanjie.SignalApi.AspNetCore
{
    /// <summary>
    /// A filter that runs after an action has thrown an <see cref="System.Exception"/>.
    /// </summary>
    public interface IExceptionFilter : IFilterMetadata
    {
        Task<bool> HandleAsync(ApiExceptionContext context);
    }
}
