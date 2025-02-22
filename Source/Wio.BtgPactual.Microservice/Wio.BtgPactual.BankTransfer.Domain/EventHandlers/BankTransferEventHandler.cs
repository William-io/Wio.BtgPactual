using Wio.BtgPactual.BankTransfer.Domain.Entities;
using Wio.BtgPactual.BankTransfer.Domain.Events;
using Wio.BtgPactual.BankTransfer.Domain.Interfaces;
using Wio.BtgPactual.Domain.Bus;

namespace Wio.BtgPactual.BankTransfer.Domain.EventHandlers
{
    public class BankTransferEventHandler : IEventHandler<BankTransferCreatedEvent>
    {
        private readonly ITransferRepository _transferLogRepository;

        public BankTransferEventHandler(ITransferRepository transferLogRepository)
        {
            _transferLogRepository = transferLogRepository;
        }

        public Task Handle(BankTransferCreatedEvent @event)
        {
            var transaction = new TransferLog
            {
                FromAccount = @event.From,
                ToAccount = @event.To,
                TransferAmount = @event.Amount
            };

            _transferLogRepository.AddTransferLog(transaction);

            return Task.CompletedTask;
        }
    }
}
