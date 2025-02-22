using Microsoft.EntityFrameworkCore;
using Wio.BtgPactual.BankTransfer.Domain.Entities;

namespace Wio.BtgPactual.BankTranfer.Infrastructure.Context;


public class BankTransferContext : DbContext
{
    public BankTransferContext(DbContextOptions<BankTransferContext> options) : base(options)
    {
    }

    public DbSet<TransferLog> TransferLogs { get; set; } = null!;
}
