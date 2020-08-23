using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

using Liyanjie.SignalApi.Common;

namespace Liyanjie.SignalApi.CompatShim.AspNetCoreMvc
{
    public class ApiHub : Microsoft.AspNetCore.SignalR.Hub<IApiClient>
    {
        public async Task<SignalResult> DispatchAsync(SignalCall call)
        {
            var req = JsonSerializer.Deserialize<ApiRequest>(call.Data);
            req.Headers.Add(HeaderKeys.ConnectionId, new[] { Context.ConnectionId });

            await Clients.Caller.Handle(new SignalCall
            {
                Method = "Trace",
                Data = $"Client call received:{req.HttpMethod}-{call.Method}",
            });

            try
            {
                var request = CreateRequest(req.HttpMethod, call.Method, req.Headers, req.Body);
                var response = await GetResponse(request);
                var code = (int)response.StatusCode;
                var data = new
                {
                    Headers = response.Headers.ToDictionary(_ => _.Key, _ => _.Value),
                    Body = await response.Content.ReadAsStringAsync(),
                };
                return new SignalResult
                {
                    Code = code.ToString(),
                    Data = JsonSerializer.Serialize(data),
                };
            }
            catch (Exception ex)
            {
                return new SignalResult
                {
                    Code = "-1",
                    Data = ex.Message,
                };
            }
        }

        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();

            await Clients.Caller.Handle(new SignalCall
            {
                Method = "Trace",
                Data = $"Client connected:{Context.ConnectionId}",
            });
        }

        static HttpRequestMessage CreateRequest(
            string method,
            string url,
            IReadOnlyDictionary<string, IEnumerable<string>> headers,
            string body)
        {
            var request = new HttpRequestMessage(new HttpMethod(method), url);
            foreach (var header in headers)
            {
                request.Headers.TryAddWithoutValidation(header.Key, header.Value);
            }
            if ("POST,PUT,PATCH".IndexOf(method.ToUpper()) > -1)
            {
                request.Content = new StringContent(body);
                request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json; charset=utf-8");
            }
            return request;
        }
        static async Task<HttpResponseMessage> GetResponse(HttpRequestMessage request)
        {
            using var http = new HttpClient();
            return await http.SendAsync(request);
        }
    }
}
