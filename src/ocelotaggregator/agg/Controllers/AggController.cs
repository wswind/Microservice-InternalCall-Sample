using agg.HttpApis;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

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
