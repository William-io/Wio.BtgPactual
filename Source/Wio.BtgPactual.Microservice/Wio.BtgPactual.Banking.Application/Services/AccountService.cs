using Wio.BtgPactual.Banking.Application.Interfaces;
using Wio.BtgPactual.Banking.Domain.Entities;
using Wio.BtgPactual.Banking.Domain.Interfaces;

namespace Wio.BtgPactual.Banking.Application.Services;

public class AccountService : IAccountService
{
    private readonly IAccountRepository _accountRepository;

    public AccountService(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }

    public IEnumerable<Account> GetAccounts()
    {
        return _accountRepository.GetAccounts();
    }
}
