using MediatR;
using Microsoft.EntityFrameworkCore;
using Wio.BtgPactual.Banking.Application.Interfaces;
using Wio.BtgPactual.Banking.Application.Services;
using Wio.BtgPactual.Banking.Domain.Interfaces;
using Wio.BtgPactual.Banking.Infrastructure.Context;
using Wio.BtgPactual.Banking.Infrastructure.Repository;
using Wio.BtgPactual.Infrastructure.Bus;
using Wio.BtgPactual.Infrastructure.IOC;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("BankingConnection");
if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("Connection string 'BankingConnection' is not found.");
}

builder.Services.AddDbContext<BankingPactualContext>(options =>
{
    options.UseSqlServer(connectionString);
});


builder.Services.Configure<RabbitSettings>(builder.Configuration.GetSection("RabbitSettings"));
Containers.RegisterServices(builder.Services, builder.Configuration);

builder.Services.AddTransient<IAccountService, AccountService>();
builder.Services.AddTransient<IAccountRepository, AccountRepository>();
builder.Services.AddTransient<BankingPactualContext>();
//builder.Services.AddTransient<IRequestHandler<CreateTransferCommand, bool>, TransferCommandHandler>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder => builder.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader()
    );

});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
