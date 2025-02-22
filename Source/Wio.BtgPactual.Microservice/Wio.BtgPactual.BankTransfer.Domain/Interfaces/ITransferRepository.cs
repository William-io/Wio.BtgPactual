using Wio.BtgPactual.BankTransfer.Domain.Entities;

namespace Wio.BtgPactual.BankTransfer.Domain.Interfaces;

public interface ITransferRepository
{
    IEnumerable<TransferLog> GetTransferLogs();

    void AddTransferLog(TransferLog log);
}
