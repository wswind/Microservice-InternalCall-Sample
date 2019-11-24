using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using agg.AggDtos;
using agg.HttpApis;
using api1.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;
using WebApiClient;

namespace agg.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AggController : ControllerBase
    {
        
        private readonly ILogger<AggController> _logger;
        //private readonly string _billUrl;
        //private readonly string _userUrl;
        private readonly string _gatewayUrl;

        public AggController(ILogger<AggController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _gatewayUrl = configuration.GetValue<string>("GatewayUrl");
            //_billUrl = gatewayUrl + "/api1/bill";
            //_userUrl = gatewayUrl + "/api2/user";
        }

        public async Task<IActionResult>  GetBillWithUserName()
        {
            var apiConfig = new HttpApiConfig { HttpHost = new Uri(_gatewayUrl) };
            
            HttpContext.Request.Headers.TryGetValue("Authorization",out StringValues values);
            var bearer = values.FirstOrDefault();
            apiConfig.HttpClient.DefaultRequestHeaders.Add("Authorization", bearer);
            var billApi = HttpApi.Create<IBillService>(apiConfig);
            var bills = await billApi.GetBills();
            return Ok(bills);
            //HttpApi.Create<IBillService>(new HttpApiConfig { HttpHost })


        }
    }
}
