using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Reflection;
using Wio.BtgPactual.Banking.Application.Interfaces;
using Wio.BtgPactual.Banking.Application.Services;
using Wio.BtgPactual.Banking.Domain.Interfaces;
using Wio.BtgPactual.Banking.Infrastructure.Context;
using Wio.BtgPactual.Banking.Infrastructure.Repository;
using Wio.BtgPactual.Domain.Bus;
using Wio.BtgPactual.Infrastructure.Bus;

namespace Wio.BtgPactual.Infrastructure.IOC;

public static class Containers
{
    public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
    {

        //services.AddTransient<IRequestHandler<CreateTransferCommand, bool>, TransferCommandHandler>();

        services.AddMediatR(Assembly.GetExecutingAssembly());
        //services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        //Domain Bus (Mediator)

        //Domain Bus
        services.AddSingleton<IEventBus, Rabbit>(sp => {
            var scopeFactory = sp.GetRequiredService<IServiceScopeFactory>();
            var optionsFactory = sp.GetService<IOptions<RabbitSettings>>();
            return new Rabbit(sp.GetService<IMediator>(), scopeFactory, optionsFactory);
        });


        //Application Services
        services.AddTransient<IAccountService, AccountService>();

        //Data
        services.AddTransient<IAccountRepository, AccountRepository>();
        services.AddTransient<BankingPactualContext>();

        //services.AddDbContext<BankingPactualContext>(options =>
        //{
        //    options.UseSqlServer(configuration.GetConnectionString("BankingConnection"));
        //});


        return services;
    }
}

