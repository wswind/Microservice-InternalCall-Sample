using Microsoft.eShopOnContainers.BuildingBlocks.EventBus.Abstractions;
using Microsoft.eShopOnContainers.BuildingBlocks.EventBus.Events;
using System;

namespace MyApi1.IntegrationEvents
{
    public class MyApi1IntegrationEventService : IMyApi1IntegrationEventService
    {
        private IEventBus _eventBus;

        public MyApi1IntegrationEventService(IEventBus eventBus)
        {
            _eventBus = eventBus ?? throw new ArgumentNullException(nameof(eventBus));
        }

        public void PublishThroughEventBusAsync(IntegrationEvent evt)
        {
            _eventBus.Publish(evt);
        }
    }
}
