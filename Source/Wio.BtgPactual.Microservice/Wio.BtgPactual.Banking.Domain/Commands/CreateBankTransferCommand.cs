namespace Wio.BtgPactual.Banking.Domain.Commands;

public class CreateBankTransferCommand : BankTransferCommand
{
    public CreateBankTransferCommand(int from, int to, decimal amount)
    {
        From = from;
        To = to;
        Amount = amount;
    }
}
