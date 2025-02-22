using MediatR;
using Wio.BtgPactual.Banking.Domain.Commands;
using Wio.BtgPactual.Banking.Domain.Events;
using Wio.BtgPactual.Domain.Bus;

namespace Wio.BtgPactual.Banking.Domain.CommandHandler;

public class BankTransferCommandHandler : IRequestHandler<CreateBankTransferCommand, bool>
{
    private readonly IEventBus _bus;

    public BankTransferCommandHandler(IEventBus bus)
    {
        _bus = bus;
    }

    public Task<bool> Handle(CreateBankTransferCommand request, CancellationToken cancellationToken)
    {
        //logica para publicar a mensagem dentro do evento bus rabbitmq
        _bus.Publish(new BankTransferCreatedEvent(request.From, request.To, request.Amount));

        return Task.FromResult(true);
    }
}
