namespace Wio.BtgPactual.Banking.Domain.Entities;

public class Account
{
    public int Id { get; set; }
    public string Type { get; set; } = string.Empty;
    public decimal Balance { get; set; } 
}
