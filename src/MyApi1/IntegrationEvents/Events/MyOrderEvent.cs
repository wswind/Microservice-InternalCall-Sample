using Microsoft.eShopOnContainers.BuildingBlocks.EventBus.Events;

namespace MyApi1.IntegrationEvents.Events
{
    public class MyOrderEvent : IntegrationEvent
    {
        public int SomewhatId { get; set; }
        public MyOrderEvent(int somewhatId)
        {
            SomewhatId = somewhatId;
        }
    }
}
