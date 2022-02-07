using System.Text;
using Module5HW1.Models.Request;
using Module5HW1.Models.Response;
using Module5HW1.Services.Abstract;
using Newtonsoft.Json;

namespace Module5HW1.Services;

public class UserService : IUserService
{
    private readonly IHttpService _httpService;
    private readonly string _configUrl;
    private readonly string _urlUser = @"api/users";

    public UserService(IHttpService httpService, IConfigService config)
    {
        _httpService = httpService;
        _configUrl = config.GetConfig().Result;
    }

    public async Task<ListUserResponse> GetListUsersAsync(string page)
    {
        var result = await _httpService.SendAsync($"{_configUrl}/{_urlUser}?page={page}", HttpMethod.Get);

        var resultString = await result.Content.ReadAsStringAsync();
        var response = JsonConvert.DeserializeObject<ListUserResponse>(resultString);

        return response!;
    }

    public async Task<SingleUserResponse> GetUserAsync(string id)
    {
        var result = await _httpService.SendAsync($"{_configUrl}/{_urlUser}/{id}", HttpMethod.Get);

        var resultString = await result.Content.ReadAsStringAsync();
        var response = JsonConvert.DeserializeObject<SingleUserResponse>(resultString);

        return response!;
    }

    public async Task<PostCreateResponse> CreateAsync(PostCreateRequest user)
    {
        var httpContent = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8);
        var result = await _httpService.SendAsync($"{_configUrl}/{_urlUser}", HttpMethod.Post, httpContent);

        var resultString = await result.Content.ReadAsStringAsync();
        var response = JsonConvert.DeserializeObject<PostCreateResponse>(resultString);

        return response!;
    }

    public async Task<PutUpdateResponse> PutUpdateAsync(PutUpdateRequest user, string id)
    {
        var httpContent = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8);
        var result = await _httpService.SendAsync($"{_configUrl}/{_urlUser}/{id}", HttpMethod.Put, httpContent);

        var resultString = await result.Content.ReadAsStringAsync();
        var response = JsonConvert.DeserializeObject<PutUpdateResponse>(resultString);

        return response!;
    }

    public async Task<PatchUpdateResponse> PatchUpdateAsync(PatchUpdateRequest user, string id)
    {
        var httpContent = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8);
        var result = await _httpService.SendAsync($"{_configUrl}/{_urlUser}/{id}", HttpMethod.Patch, httpContent);

        var resultString = await result.Content.ReadAsStringAsync();
        var response = JsonConvert.DeserializeObject<PatchUpdateResponse>(resultString);

        return response!;
    }

    public async Task<DeleteResponse> DeleteAsync(string id)
    {
        var result = await _httpService.SendAsync($"{_configUrl}/{_urlUser}/{id}", HttpMethod.Delete);

        var resultString = await result.Content.ReadAsStringAsync();
        var response = JsonConvert.DeserializeObject<DeleteResponse>(resultString);

        return response!;
    }

    public async Task<DelayedResponse> DelayedAsync(string delay)
    {
        var result = await _httpService.SendAsync($"{_configUrl}/{_urlUser}?{delay}", HttpMethod.Get);

        var resultString = await result.Content.ReadAsStringAsync();
        var response = JsonConvert.DeserializeObject<DelayedResponse>(resultString);

        return response!;
    }
}