namespace Wio.BtgPactual.Banking.Application.Entities;

public class AccountTransferred
{
    public int FromAccount { get; set; }
    public int ToAccount { get; set; }

    public decimal TransferAmount { get; set; }
}
