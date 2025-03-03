using System.Globalization;
using FutureClient.Application.Exchanges;
using FutureClient.Application.Services;
using FutureClient.Domain.Options;
using FutureClient.Domain.Repositories;
using FutureClient.Infrastructure.Repositories;

CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.InvariantCulture;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddScoped<IFutureRepository, FutureRepository>();
builder.Services.Configure<ExchangeApiOptions>(x 
    => x.BaseUri = "https://fapi.binance.com");
builder.Services.AddScoped<IRestFutureConnector, BinanceRestClient>();
builder.Services.AddScoped<IFutureService, FutureService>();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.UseHttpsRedirection();
app.Run();