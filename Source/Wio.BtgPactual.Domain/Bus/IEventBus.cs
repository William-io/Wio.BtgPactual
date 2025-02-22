using Wio.BtgPactual.Domain.Commands;
using Wio.BtgPactual.Domain.Events;

namespace Wio.BtgPactual.Domain.Bus;

public interface IEventBus
{
    Task CommandSend<T>(T command) where T : Command; 

    void Publish<T>(T @event) where T : Event;

    void Subscribe<T, TH>()
        where T : Event
        where TH : IEventHandler<T>;
}

