using Wio.BtgPactual.Banking.Application.Entities;
using Wio.BtgPactual.Banking.Application.Interfaces;
using Wio.BtgPactual.Banking.Domain.Commands;
using Wio.BtgPactual.Banking.Domain.Entities;
using Wio.BtgPactual.Banking.Domain.Interfaces;
using Wio.BtgPactual.Domain.Bus;

namespace Wio.BtgPactual.Banking.Application.Services;

public class AccountService : IAccountService
{
    private readonly IAccountRepository _accountRepository;
    private readonly IEventBus _bus;

    public AccountService(IAccountRepository accountRepository, IEventBus bus)
    {
        _accountRepository = accountRepository;
        _bus = bus;
    }

    public IEnumerable<Account> GetAccounts()
    {
        return _accountRepository.GetAccounts();
    }

    public void Transfer(AccountTransferred accountTransferred)
    {
        var createBankTranferCommand = new CreateBankTransferCommand(
            accountTransferred.FromAccount,
            accountTransferred.ToAccount,
            accountTransferred.TransferAmount);

        _bus.CommandSend(createBankTranferCommand);

    }
}
