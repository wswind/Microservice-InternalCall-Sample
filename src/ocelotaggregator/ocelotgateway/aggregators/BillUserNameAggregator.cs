using Ocelot.Middleware;
using Ocelot.Middleware.Multiplexer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ocelotgateway.aggregators
{
    public class BillUserNameAggregator : IDefinedAggregator
    {
        public Task<DownstreamResponse> Aggregate(List<DownstreamContext> responses)
        {
            throw new NotImplementedException(); 
        }
    }
}
