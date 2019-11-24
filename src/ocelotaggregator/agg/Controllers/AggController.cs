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
        private readonly IUserService _userService;

        public AggController(ILogger<AggController> logger, 
            IConfiguration configuration, 
            IBillService billService,
            IUserService userService)
        {
            _logger = logger;
            _billService = billService;
            _userService = userService;
        }

        public async Task<IActionResult>  GetBillWithUserName()
        {
            var bills = await _billService.GetBills();
            var users = await _userService.GetUsers();
            return Ok(new { bill=bills,user=users});
        }
    }
}
