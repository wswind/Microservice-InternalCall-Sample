using api1.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace api1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CallController : ControllerBase
    {
        private readonly string baseUrl;

        private readonly ILogger<CallController> _logger;

        public CallController(ILogger<CallController> logger, IConfiguration configuration)
        {
            _logger = logger;
        }

        [HttpGet]
        public Task<int> Get()
        {
            //var api = HttpApi.Resolve<ICallService>();
            //int result = await api.GetDouble(1);
            //return result;
            throw new System.NotImplementedException();
        }
    }
}
