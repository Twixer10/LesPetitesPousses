using LPPMaUI.Helper.Interfaces;

namespace LPPMaUI.Helper;

public class HttpClientHelper : IHttpClientHelper
{
    private readonly HttpClient _httpClient;
    
    public HttpClientHelper()
    {
        var handler = new HttpClientHandler();
        _httpClient = new HttpClient(handler);
    }
    
    public HttpClient GetHttpClient()
    {
        return _httpClient;
    }
}