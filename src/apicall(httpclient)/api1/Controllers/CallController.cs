using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api1.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using WebApiClient;

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
        public async Task<int> Get()
        {
            var api = HttpApi.Resolve<ICallService>();
            int result = await api.GetDouble(1);
            return result;
        }
    }
}
