using System.Text;
using FutureClient.Application.Exchanges.Requests;
using FutureClient.Domain.Types;
using FutureClient.Domain.Options;

namespace FutureClient.Application.Exchanges;

public class BaseRestApi<T>
    where T : BaseRequest, new()
{
    private readonly ExchangeApiOptions _apiOptions;

    public BaseRestApi(ExchangeApiOptions apiOptions)
    {
        _apiOptions = apiOptions;
    }
    
    public T CreateRequest(MethodType method, BaseType endpoint,
        string? query = null, string? payload = null)
    {
        var full = endpoint.Value + query;
        var result = new T
        {
            ApiOptions = _apiOptions,
            Client = new HttpClient
            {
                BaseAddress = new Uri(_apiOptions.BaseUri)
            },
            RequestOptions = new RequestOptions
            {
                FullPath = full,
                Endpoint = endpoint,
                Type = method,
                Query = new StringBuilder()
            }
        };
        result.RequestOptions.Query.Append(query);
        return result;
    }
}