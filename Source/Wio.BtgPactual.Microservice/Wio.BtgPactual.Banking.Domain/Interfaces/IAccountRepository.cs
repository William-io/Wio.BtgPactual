using Wio.BtgPactual.Banking.Domain.Entities;

namespace Wio.BtgPactual.Banking.Domain.Interfaces;

public interface IAccountRepository
{
    IEnumerable<Account> GetAccounts();
}

