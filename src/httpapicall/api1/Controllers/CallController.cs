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
        private readonly ICallService _callService;

        public CallController(ILogger<CallController> logger,
            IConfiguration configuration,
            ICallService callService
            )
        {
            _logger = logger;
            _callService = callService;
        }

        [HttpGet]
        public async Task<int> Get()
        {
            int result = await _callService.GetDouble(1);
            return result;
        }
    }
}
