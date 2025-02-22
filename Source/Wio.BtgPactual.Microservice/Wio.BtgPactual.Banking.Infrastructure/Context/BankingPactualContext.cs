using Microsoft.EntityFrameworkCore;
using Wio.BtgPactual.Banking.Domain.Entities;

namespace Wio.BtgPactual.Banking.Infrastructure.Context;

public class BankingPactualContext(DbContextOptions<BankingPactualContext> options) : DbContext(options)
{
    public DbSet<Account> Accounts { get; set; } = null!;
}

