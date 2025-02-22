using MediatR;

namespace Wio.BtgPactual.Domain.Events;

public abstract class MessageStatus : IRequest<bool>
{
    public string MessageType { get; protected set; }

    protected MessageStatus() => MessageType = GetType().Name;
}
