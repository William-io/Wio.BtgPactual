using System.ComponentModel.DataAnnotations.Schema;

namespace Wio.BtgPactual.Banking.Domain.Entities;

public class Account
{
    public int Id { get; set; }
    public string Type { get; set; } = string.Empty;

    [Column(TypeName = "decimal(5, 2)")]
    public decimal Balance { get; set; }
}
