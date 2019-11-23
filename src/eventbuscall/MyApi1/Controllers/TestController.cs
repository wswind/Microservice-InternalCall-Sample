using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyApi1.IntegrationEvents;
using MyApi1.IntegrationEvents.Events;

namespace MyApi1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly IMyApi1IntegrationEventService myApi1IntegrationEventService;

        public TestController(IMyApi1IntegrationEventService myApi1IntegrationEventService)
        {
            this.myApi1IntegrationEventService = myApi1IntegrationEventService;
        }

        [HttpGet]
        public string Get()
        {
            var ev = new MyOrderEvent(3);
            myApi1IntegrationEventService.PublishThroughEventBusAsync(ev);
            return "Ok";

        }
    }
}
