using Wio.BtgPactual.Domain.Events;

namespace Wio.BtgPactual.Domain.Bus;

public interface IEventHandler<in TEvent> : IEventHandler where TEvent : Event
{
    Task Handle(TEvent @event);
}

public interface IEventHandler
{
}
