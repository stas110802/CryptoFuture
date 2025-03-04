using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using FutureClient.Application.Exchanges.Endpoints;
using FutureClient.Application.Exchanges.Requests;
using FutureClient.Application.Models;
using FutureClient.Domain.Types;
using FutureClient.Domain.Options;
using Microsoft.Extensions.Options;

namespace FutureClient.Application.Exchanges;

public class BinanceRestClient : IRestFutureConnector
{
    private readonly BaseRestApi<BaseRequest> _restApi;

    public BinanceRestClient(IOptions<ExchangeApiOptions> options)
    {
        _restApi = new BaseRestApi<BaseRequest>(options.Value);
    }

    public async Task<IEnumerable<Candle>> GetContinuousContractKlineAsync(string pair, ContractType contract, IntervalType interval,
        DateTime? startTime = null,
        DateTime? endTime = null, int limit = 500)
    {
        var queryBuilder = new StringBuilder();
        queryBuilder.Append($"?pair={pair}&contractType={contract.Value}&interval={interval.Value}");

        if (startTime != null && endTime != null)
        {
            var start = new DateTimeOffset((DateTime)startTime).ToUnixTimeMilliseconds();
            var end = new DateTimeOffset((DateTime)endTime).ToUnixTimeMilliseconds();
            queryBuilder.Append($"&startTime={start}&endTime={end}");
        }
        
        if (limit is > 0 and < 1500)
            queryBuilder.Append($"&limit={limit}");

        var query = queryBuilder.ToString();
        var response = await _restApi
            .CreateRequest(MethodType.Get, BinanceEndpoint.ContinuousContractKline, query)
            .ExecuteAsync();
        
        var deserialize = JsonSerializer.Deserialize<JsonArray>(response);
        var result = new List<Candle>();
        
        foreach (var candle in deserialize)
        {
            var milliseconds = long.Parse(candle[0].ToString());
            var time = DateTimeOffset.FromUnixTimeMilliseconds(milliseconds);
            
            result.Add(new Candle
            {
                OpenPrice = decimal.Parse(candle[1].ToString()),
                HighPrice = decimal.Parse(candle[2].ToString()),
                LowPrice = decimal.Parse(candle[3].ToString()),
                ClosePrice = decimal.Parse(candle[4].ToString()),
                TotalVolume = decimal.Parse(candle[5].ToString()),
                OpenTime = time,
                Pair = pair
            });
        }

        return result;
    }
}