using Ocelot.Middleware;
using Ocelot.Middleware.Multiplexer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ocelotgateway.aggregators
{
    public class BillUserNameAggregator : IDefinedAggregator
    {
        public async Task<DownstreamResponse> Aggregate(List<DownstreamContext> responses)
        {
            List<string> results = new List<string>();
            var contentBuilder = new StringBuilder();

            contentBuilder.Append("{");

            foreach (var down in responses)
            {
                string content = await down.DownstreamResponse.Content.ReadAsStringAsync();
                results.Add($"\"{down.DownstreamReRoute.Key}\":{content}");
            }

            results.Add("\"Agg\":{{\"AggComment\":\"this is from agg\"}}");

            contentBuilder.Append(string.Join(",", results));
            contentBuilder.Append("}");

            var stringContent = new StringContent(contentBuilder.ToString())
            {
                Headers = { ContentType = new MediaTypeHeaderValue("application/json") }
            };

            var headers = responses.SelectMany(x => x.DownstreamResponse.Headers).ToList();
            return new DownstreamResponse(stringContent, HttpStatusCode.OK, headers,"OK");
        }
    }
}
