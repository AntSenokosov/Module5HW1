using Module5HW1.Models.Response;
using Module5HW1.Services.Abstract;
using Newtonsoft.Json;

namespace Module5HW1.Services;

public class HttpService : IHttpService
{
    private readonly HttpClient _client = new HttpClient();

    public async Task<HttpResponseMessage> SendAsync(string url, HttpMethod httpMethod, StringContent? content = null)
    {
        var httpMessage = new HttpRequestMessage();
        httpMessage.Content = content;
        httpMessage.Method = httpMethod;
        httpMessage.RequestUri = new Uri(url);

        var result = await _client.SendAsync(httpMessage);

        return result;
    }
}