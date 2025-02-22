using Wio.BtgPactual.BankTransfer.Application.Interfaces;
using Wio.BtgPactual.BankTransfer.Domain.Entities;
using Wio.BtgPactual.BankTransfer.Domain.Interfaces;
using Wio.BtgPactual.Domain.Bus;

namespace Wio.BtgPactual.BankTransfer.Application.Services;

public class TransferService : ITransferService
{
    private readonly ITransferRepository _transferRepository;
    private readonly IEventBus _bus;

    public TransferService(ITransferRepository transferRepository, IEventBus bus)
    {
        _transferRepository = transferRepository;
        _bus = bus;
    }

    public IEnumerable<TransferLog> GetTransferLogs()
    {
        return _transferRepository.GetTransferLogs();
    }
}
