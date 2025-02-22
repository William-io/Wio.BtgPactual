using Wio.BtgPactual.Domain.Commands;

namespace Wio.BtgPactual.Banking.Domain.Commands;

public abstract class BankTransferCommand : Command
{
    public int From { get; set; }
    public int To { get; set; }
    public decimal Amount { get; set; }
}
