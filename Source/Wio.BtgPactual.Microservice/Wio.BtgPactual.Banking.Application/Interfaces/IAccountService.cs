using Wio.BtgPactual.Banking.Domain.Entities;

namespace Wio.BtgPactual.Banking.Application.Interfaces
{
    public interface IAccountService
    {
        IEnumerable<Account> GetAccounts();
    }
}
