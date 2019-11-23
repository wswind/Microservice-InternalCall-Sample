using System.Threading.Tasks;
using Microsoft.eShopOnContainers.BuildingBlocks.EventBus.Abstractions;
using Microsoft.Extensions.Logging;
using MyApi1.IntegrationEvents.Events;

namespace MyApi1.IntegrationEvents.EventHandling
{
    public class MyOrderEventHandler : IIntegrationEventHandler<MyOrderEvent>
    {
        private readonly ILogger<MyOrderEventHandler> logger;

        public MyOrderEventHandler(ILogger<MyOrderEventHandler> logger)
        {
            this.logger = logger;
        }

        public Task Handle(MyOrderEvent @event)
        {
            logger.LogInformation($"---- event somewhatid:{@event.SomewhatId}");
            return Task.CompletedTask;
        }
    }
}
