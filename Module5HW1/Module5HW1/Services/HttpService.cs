using System.Text;
using Module5HW1.Models.Response;
using Module5HW1.Services.Abstract;
using Newtonsoft.Json;

namespace Module5HW1.Services;

public class HttpService : IHttpService
{
    private readonly HttpClient _client = new HttpClient();

    public async Task<T?> SendAsync<T>(string url, HttpMethod httpMethod, object? content = null)
    {
        var httpMessage = new HttpRequestMessage();
        if (content != null)
        {
            httpMessage.Content = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8);
        }

        httpMessage.Method = httpMethod;
        httpMessage.RequestUri = new Uri(url);

        var result = await _client.SendAsync(httpMessage);

        var resultString = await result.Content.ReadAsStringAsync();
        var response = JsonConvert.DeserializeObject<T>(resultString);

        return response;
    }
}