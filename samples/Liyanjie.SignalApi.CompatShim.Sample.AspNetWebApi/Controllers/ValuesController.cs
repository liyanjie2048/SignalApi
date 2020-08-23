using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

using Liyanjie.SignalApi.Common;
using Liyanjie.SignalApi.CompatShim;

using Microsoft.AspNet.SignalR;

namespace Liyanjie.SignalApi.CompatShim.Sample.AspNetWebApi.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public async Task<IEnumerable<string>> Get()
        {
            var connectionId = Request.Headers.GetValues(HeaderKeys.ConnectionId).FirstOrDefault();
            var context = GlobalHost.ConnectionManager.GetHubContext<ApiHub, IApiClient>();
            await context.Clients.Client(connectionId).Handle(new SignalCall
            {
                Method = "Trace",
                Parameters = $"Reach controller action:{connectionId}",
            });

            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
