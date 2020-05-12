using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace api2.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class DoubleController : ControllerBase
    {
        private readonly ILogger<DoubleController> _logger;

        public DoubleController(ILogger<DoubleController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public int Get(int i)
        {
            return (i*2);
        }
    }
}
