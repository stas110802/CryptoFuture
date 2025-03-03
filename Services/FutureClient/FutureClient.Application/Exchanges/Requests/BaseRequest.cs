using FutureClient.Application.Types;
using FutureClient.Domain.Options;

namespace FutureClient.Application.Exchanges.Requests;

public class BaseRequest
{
    public HttpClient? Client;
    public RequestOptions? RequestOptions { get; set; }
    public ExchangeApiOptions? ApiOptions { get; set; }

    public async Task<string> ExecuteAsync()
    {
        if (RequestOptions == null || Client == null)
            throw new NullReferenceException("[Request error] : First you need to execute 'Create' method.");

        HttpResponseMessage? response = null;
        
        if(RequestOptions.Type == MethodType.Get)
            response = await Client.GetAsync(RequestOptions.FullPath);
        if(RequestOptions.Type == MethodType.Post)
            response = await Client.PostAsync(RequestOptions.FullPath, null);
        
        response!.EnsureSuccessStatusCode();
        var responseBody = await response.Content.ReadAsStringAsync();

        return responseBody;
    }
}