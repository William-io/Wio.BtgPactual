using MediatR;
using Microsoft.EntityFrameworkCore;
using Wio.BtgPactual.Banking.Application.Interfaces;
using Wio.BtgPactual.Banking.Application.Services;
using Wio.BtgPactual.Banking.Domain.CommandHandler;
using Wio.BtgPactual.Banking.Domain.Commands;

using Wio.BtgPactual.Banking.Domain.Interfaces;
using Wio.BtgPactual.Banking.Infrastructure.Context;
using Wio.BtgPactual.Banking.Infrastructure.Repository;
using Wio.BtgPactual.BankTranfer.Infrastructure.Context;
using Wio.BtgPactual.BankTranfer.Infrastructure.Migrations;
using Wio.BtgPactual.BankTranfer.Infrastructure.Repository;
using Wio.BtgPactual.BankTransfer.Application.Interfaces;
using Wio.BtgPactual.BankTransfer.Application.Services;
using Wio.BtgPactual.BankTransfer.Domain.EventHandlers;
using Wio.BtgPactual.BankTransfer.Domain.Events;
using Wio.BtgPactual.BankTransfer.Domain.Interfaces;
using Wio.BtgPactual.Domain.Bus;
using Wio.BtgPactual.Infrastructure.Bus;
using Wio.BtgPactual.Infrastructure.IOC;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("BankTransferConnection");
if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("Connection string 'BankTransferConnection' is not found.");
}

builder.Services.AddDbContext<BankTransferContext>(options =>
{
    options.UseSqlServer(connectionString);
});


builder.Services.Configure<RabbitSettings>(builder.Configuration.GetSection("RabbitSettings"));

builder.Services.RegisterServices(builder.Configuration);


builder.Services.AddTransient<ITransferService, TransferService>();
builder.Services.AddTransient<ITransferRepository, TransferRepository>();
builder.Services.AddTransient<BankTransferContext>();

builder.Services.AddTransient<IEventHandler<BankTransferCreatedEvent>, BankTransferEventHandler>();


builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder => builder.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader()
    );

});


var app = builder.Build();

var eventBus = app.Services.GetRequiredService<IEventBus>();
eventBus.Subscribe<BankTransferCreatedEvent, BankTransferEventHandler>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("CorsPolicy");

app.MapControllers();

app.Run();
