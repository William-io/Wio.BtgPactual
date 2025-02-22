using Wio.BtgPactual.BankTransfer.Domain.Entities;

namespace Wio.BtgPactual.BankTransfer.Application.Interfaces;

public interface ITransferService
{
    IEnumerable<TransferLog> GetTransferLogs();
}
