namespace Wio.BtgPactual.Domain.Events;

public abstract class Event
{
    public DateTime Timestamping { get; protected set; }

    protected Event() => Timestamping = DateTime.Now;
}

