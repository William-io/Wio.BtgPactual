using Microsoft.EntityFrameworkCore;
using Wio.BtgPactual.Banking.Domain.Entities;

namespace Wio.BtgPactual.Banking.Infrastructure.Context;

public class BankingPactualContext : DbContext
{
    public BankingPactualContext(DbContextOptions<BankingPactualContext> options) : base(options) { }
    public DbSet<Account> Accounts { get; set; }

}

