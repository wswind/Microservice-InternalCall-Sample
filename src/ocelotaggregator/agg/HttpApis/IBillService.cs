using api1.Dtos;
using System.Collections.Generic;
using WebApiClient;
using WebApiClient.Attributes;

namespace agg.HttpApis
{
    public interface IBillService : IHttpApi
    {
        [HttpGet("api1/bill")]
        ITask<List<BillDto>> GetBills();
    }


}
