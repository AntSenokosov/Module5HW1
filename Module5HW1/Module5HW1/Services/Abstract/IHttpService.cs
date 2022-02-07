namespace Module5HW1.Services.Abstract;

public interface IHttpService
{
    public Task<T?> SendAsync<T>(string url, HttpMethod httpMethod, object? content = null);
}