using System;
using System.Linq;
using System.Threading.Tasks;

using Liyanjie.SignalApi.Abstrations;
using Liyanjie.SignalApi.AspNetCore;
using Liyanjie.SignalApi.Common;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;

namespace Liyanjie.SignalApi.Sample.AspNetCore.Services
{
    public class WeatherForecastService : ServiceBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastService> _logger;

        public WeatherForecastService(ILogger<WeatherForecastService> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<WeatherForecast[]> Get(
            [FromServices] IHubContext<ApiHub, IApiClient> context)
        {
            await context.Clients.Client(Context.ConnectionId).Handle(new SignalCall
            {
                Method = "Trace",
                Parameters = $"Reach controller action:{Context.ConnectionId}",
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
