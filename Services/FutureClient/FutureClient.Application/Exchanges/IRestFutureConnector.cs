using FutureClient.Application.Models;
using FutureClient.Application.Types;

namespace FutureClient.Application.Exchanges;

public interface IRestFutureConnector
{
    Task<IEnumerable<Candle>> GetContinuousContractKlineAsync(string pair, ContractType contract, IntervalType interval,
        DateTime? startTime = null, DateTime? endTime = null, int limit = 500);
}