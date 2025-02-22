using System.ComponentModel.DataAnnotations.Schema;

namespace Wio.BtgPactual.BankTransfer.Domain.Entities;

public class TransferLog
{
    public int Id { get; set; }
    public int FromAccount { get; set; }
    public int ToAccount { get; set; }

    [Column(TypeName = "decimal(5, 2)")]
    public decimal TransferAmount { get; set; }
}
