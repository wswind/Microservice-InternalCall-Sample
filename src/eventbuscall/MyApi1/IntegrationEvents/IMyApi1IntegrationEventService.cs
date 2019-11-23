using Microsoft.eShopOnContainers.BuildingBlocks.EventBus.Events;
using System.Threading.Tasks;

namespace MyApi1.IntegrationEvents
{
    public interface IMyApi1IntegrationEventService
    {
        void PublishThroughEventBusAsync(IntegrationEvent evt);
    }
}
