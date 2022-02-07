namespace Module5HW1.Services.Abstract;

public interface IHttpService
{
    public Task<HttpResponseMessage> SendAsync(string url, HttpMethod httpMethod, StringContent? content = null);
}