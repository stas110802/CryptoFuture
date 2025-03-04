using System.Globalization;
using FutureClient.Application.Exchanges;
using FutureClient.Application.Services;
using FutureClient.Domain.Options;
using FutureClient.Domain.Repositories;
using FutureClient.Infrastructure.Data;
using FutureClient.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.InvariantCulture;
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddDbContext<FutureClientDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(FutureClientDbContext)));
});
builder.Services.AddScoped<IFutureRepository, FutureRepository>();
builder.Services.Configure<ExchangeApiOptions>(x 
    => x.BaseUri = "https://fapi.binance.com");
builder.Services.AddScoped<IRestFutureConnector, BinanceRestClient>();
builder.Services.AddScoped<IFutureService, FutureService>();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

using var context = app.Services.GetService<FutureClientDbContext>();
context?.Database.EnsureCreated();

app.MapControllers();
app.Run();