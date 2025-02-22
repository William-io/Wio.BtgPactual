using MediatR;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;
using Wio.BtgPactual.Domain.Bus;
using Wio.BtgPactual.Domain.Commands;
using Wio.BtgPactual.Domain.Events;

namespace Wio.BtgPactual.Infrastructure.Bus;

public sealed class Rabbit : IEventBus
{
    private readonly IMediator _mediator;
    //Dicionario para armazenar os eventos e os handlers
    private readonly Dictionary<string, List<Type>> _handlers;
    private readonly List<Type> _eventTypes;

    public Rabbit(IMediator mediator)
    {
        _mediator = mediator;
        _handlers = new Dictionary<string, List<Type>>();
        _eventTypes = new List<Type>();
    }

    public Task CommandSend<T>(T command) where T : Command
    {
        return _mediator.Send(command);
    }

    public void Publish<T>(T @event) where T : Event
    {
        var factoryConnection = new ConnectionFactory()
        {
            HostName = "localhost",
            UserName = "william_io",
            Password = "3OfCoffee"
        };

        using (var connection = factoryConnection.CreateConnection())
        {
            using (var channel = connection.CreateModel())
            {
                var eventName = @event.GetType().Name;

                channel.QueueDeclare(eventName, false, false, false, null);

                var message = JsonConvert.SerializeObject(@event);

                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish("", eventName, null, body);
            }
        }
    }

    public void Subscribe<T, TH>()
        where T : Event
        where TH : IEventHandler<T>
    {
        throw new NotImplementedException();
    }
}

