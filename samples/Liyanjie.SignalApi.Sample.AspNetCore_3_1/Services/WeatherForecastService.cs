using System;
using System.Linq;
using System.Threading.Tasks;

using Liyanjie.SignalApi.AspNetCore;
using Liyanjie.SignalApi.Common;

using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;

namespace Liyanjie.SignalApi.Sample.AspNetCore_3_1.Services
{
    public class WeatherForecastService : ApiServiceBase
    {
        static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        readonly ILogger<WeatherForecastService> _logger;
        readonly IHubContext<ApiHub, IApiClient> _context;

        public WeatherForecastService(
            ILogger<WeatherForecastService> logger,
            IHubContext<ApiHub, IApiClient> context)
        {
            _logger = logger;
            _context = context;
        }

        [ApiMethod("GetWeatherForecasts")]
        public async Task<WeatherForecast[]> Get()
        {
            await _context.Clients.Client(CallContext.ConnectionId).Trace($"Reach service:{CallContext.ConnectionId}");

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
