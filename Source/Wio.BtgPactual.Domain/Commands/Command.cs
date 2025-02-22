using Wio.BtgPactual.Domain.Events;

namespace Wio.BtgPactual.Domain.Commands;

public abstract class Command : MessageStatus
{
    public DateTime Timestamping { get; protected set; }

    protected Command() => Timestamping = DateTime.Now;
}
