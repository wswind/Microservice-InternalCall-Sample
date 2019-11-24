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
        private readonly IBillService _billService;

        public AggController(ILogger<AggController> logger, IConfiguration configuration, IBillService billService)
        {
            _logger = logger;
            _billService = billService;
        }

        public async Task<IActionResult>  GetBillWithUserName()
        {
            var bills = await _billService.GetBills();
            return Ok(bills);
        }
    }
}
