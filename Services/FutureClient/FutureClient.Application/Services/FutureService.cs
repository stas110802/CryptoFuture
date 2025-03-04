using FutureClient.Application.Dtos;
using FutureClient.Application.Exchanges;
using FutureClient.Domain.Types;

namespace FutureClient.Application.Services;

public class FutureService : IFutureService
{
    private readonly IRestFutureConnector _futureClient;

    public FutureService(IRestFutureConnector futureClient)
    {
        _futureClient = futureClient;
    }
    
    public static int Limit { get; set; } = 1;
    
    public async Task<FutureDifferenceServiceDto> CalculateQuarterFutureDifferenceAsync(string pair,
        IntervalType interval,
        DateTime? startTime = null, DateTime? endTime = null)
    {
        var firstCandle = (await _futureClient
            .GetContinuousContractKlineAsync(pair, ContractType.CurrentQuarter, interval, startTime, endTime, Limit))
            .First();
        var secondCandle = (await _futureClient
            .GetContinuousContractKlineAsync(pair, ContractType.NextQuarter, interval, startTime, endTime, Limit))
            .First();

        return new FutureDifferenceServiceDto
        {
            Currency = pair,
            CurrentQuarterPrice = firstCandle.ClosePrice,
            NextQuarterPrice = secondCandle.ClosePrice,
            StartTime = startTime,
            EndTime = endTime,
            Date = DateTime.UtcNow
        };
    }
}