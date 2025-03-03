using FutureClient.Application.Types;

namespace FutureClient.Application.Exchanges.Endpoints;

public class BinanceEndpoint : BaseType
{
    private BinanceEndpoint(string value) : base(value) { }
    
    public static readonly BinanceEndpoint ContinuousContractKline = new("/fapi/v1/continuousKlines");
}