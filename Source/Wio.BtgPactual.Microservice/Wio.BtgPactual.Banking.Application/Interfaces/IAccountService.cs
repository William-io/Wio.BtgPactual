using Wio.BtgPactual.Banking.Application.Entities;
using Wio.BtgPactual.Banking.Domain.Entities;

namespace Wio.BtgPactual.Banking.Application.Interfaces
{
    public interface IAccountService
    {
        IEnumerable<Account> GetAccounts();
        void Transfer(AccountTransferred accountTransferred);
    }
}
