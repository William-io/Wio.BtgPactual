using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Wio.BtgPactual.Banking.Application.Interfaces;
using Wio.BtgPactual.Banking.Application.Services;
using Wio.BtgPactual.Banking.Domain.Interfaces;
using Wio.BtgPactual.Banking.Infrastructure.Context;
using Wio.BtgPactual.Banking.Infrastructure.Repository;
using Wio.BtgPactual.Domain.Bus;
using Wio.BtgPactual.Infrastructure.Bus;

namespace Wio.BtgPactual.Infrastructure.IOC;

public class Containers
{
    public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
    {
        //Domain Bus (Mediator)
        services.AddScoped<IEventBus, Rabbit>();
        services.Configure<RabbitSettings>(r => configuration.GetSection("RabbitSettings"));

        //Application Services
        services.AddTransient<IAccountService, AccountService>();

        //Data
        services.AddTransient<IAccountRepository, AccountRepository>();
        services.AddTransient<BankingPactualContext>();    
    }
}

