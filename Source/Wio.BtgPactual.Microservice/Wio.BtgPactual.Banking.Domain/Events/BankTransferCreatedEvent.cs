using Wio.BtgPactual.Domain.Events;

namespace Wio.BtgPactual.Banking.Domain.Events;

public class BankTransferCreatedEvent : Event
{
    public BankTransferCreatedEvent(int from, int to, decimal amount)
    {
        From = from;
        To = to;
        Amount = amount;
    }

    public int From { get; set; }
    public int To { get; set; }
    public decimal Amount { get; set; }
}
