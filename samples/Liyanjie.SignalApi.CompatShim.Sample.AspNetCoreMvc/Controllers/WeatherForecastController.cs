using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Liyanjie.SignalApi.Common;
using Liyanjie.SignalApi.CompatShim.AspNetCoreMvc;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;

namespace Liyanjie.SignalApi.CompatShim.Sample.AspNetCoreMvc.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<WeatherForecast>> Get(
            [FromHeader(Name = HeaderKeys.ConnectionId)] string connectionId,
            [FromServices] IHubContext<ApiHub, IApiClient> context)
        {
            await context.Clients.Client(connectionId).Handle(new SignalCall
            {
                Method = "Trace",
                Data = $"Reach controller action:{connectionId}",
            });

            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
