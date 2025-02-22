using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Reflection;
using Wio.BtgPactual.Banking.Application.Interfaces;
using Wio.BtgPactual.Banking.Application.Services;
using Wio.BtgPactual.Banking.Domain.CommandHandler;
using Wio.BtgPactual.Banking.Domain.Commands;
using Wio.BtgPactual.Banking.Domain.Interfaces;
using Wio.BtgPactual.Banking.Infrastructure.Context;
using Wio.BtgPactual.Banking.Infrastructure.Repository;
using Wio.BtgPactual.BankTranfer.Infrastructure.Context;
using Wio.BtgPactual.BankTranfer.Infrastructure.Repository;
using Wio.BtgPactual.BankTransfer.Application.Interfaces;
using Wio.BtgPactual.BankTransfer.Application.Services;
using Wio.BtgPactual.BankTransfer.Domain.Interfaces;
using Wio.BtgPactual.Domain.Bus;
using Wio.BtgPactual.Infrastructure.Bus;

namespace Wio.BtgPactual.Infrastructure.IOC;

public static class Containers
{
    public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
    {

        //services.AddTransient<IRequestHandler<CreateBankTransferCommand, bool>, BankTransferCommandHandler>();

        services.AddMediatR(Assembly.GetExecutingAssembly());

        services.AddTransient<IEventBus, Rabbit>();

        //Domain Bus
        services.AddSingleton<IEventBus, Rabbit>(sp =>
        {
            var scopeFactory = sp.GetRequiredService<IServiceScopeFactory>();
            var optionsFactory = sp.GetService<IOptions<RabbitSettings>>();
            return new Rabbit(sp.GetService<IMediator>(), scopeFactory, optionsFactory);
        });


        ////Application Services
        //services.AddTransient<IAccountService, AccountService>();
        //services.AddTransient<ITransferService, TransferService>();

        ////Data
        //services.AddTransient<IAccountRepository, AccountRepository>();
        //services.AddTransient<ITransferRepository, TransferRepository>();

        //services.AddTransient<BankingPactualContext>();
        //services.AddTransient<BankTransferContext>();

        return services;
    }
}

