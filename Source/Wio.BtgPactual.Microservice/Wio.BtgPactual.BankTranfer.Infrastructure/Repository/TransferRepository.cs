using Wio.BtgPactual.BankTranfer.Infrastructure.Context;
using Wio.BtgPactual.BankTransfer.Domain.Entities;
using Wio.BtgPactual.BankTransfer.Domain.Interfaces;

namespace Wio.BtgPactual.BankTranfer.Infrastructure.Repository;

public class TransferRepository : ITransferRepository
{
    private readonly BankTransferContext _context;

    public TransferRepository(BankTransferContext context)
    {
        _context = context;
    }

    public void AddTransferLog(TransferLog log)
    {
        _context.Add(log);
        _context.SaveChanges();
    }

    public IEnumerable<TransferLog> GetTransferLogs()
    {
        return _context.TransferLogs;
    }
}
