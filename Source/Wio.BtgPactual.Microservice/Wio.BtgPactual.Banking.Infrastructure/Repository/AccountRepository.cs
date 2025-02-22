using Wio.BtgPactual.Banking.Domain.Entities;
using Wio.BtgPactual.Banking.Domain.Interfaces;
using Wio.BtgPactual.Banking.Infrastructure.Context;

namespace Wio.BtgPactual.Banking.Infrastructure.Repository;

public class AccountRepository : IAccountRepository
{
    private readonly BankingPactualContext _context;

    public AccountRepository(BankingPactualContext context)
    {
        _context = context;
    }

    public IEnumerable<Account> GetAccounts()
    {
        return _context.Accounts;
    }
}
