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

    public async Task<ListUserResponse?> GetListUsersAsync(string page)
    {
        return await _httpService.SendAsync<ListUserResponse>($"{_configUrl}/{_urlUser}?page={page}", HttpMethod.Get);
    }

    public async Task<SingleUserResponse?> GetUserAsync(string id)
    {
        return await _httpService.SendAsync<SingleUserResponse>($"{_configUrl}/{_urlUser}/{id}", HttpMethod.Get);
    }

    public async Task<PostCreateResponse?> CreateAsync(PostCreateRequest user)
    {
        return await _httpService.SendAsync<PostCreateResponse>($"{_configUrl}/{_urlUser}", HttpMethod.Post, user);
    }

    public async Task<PutUpdateResponse?> PutUpdateAsync(PutUpdateRequest user, string id)
    {
        return await _httpService.SendAsync<PutUpdateResponse>($"{_configUrl}/{_urlUser}/{id}", HttpMethod.Put, user);
    }

    public async Task<PatchUpdateResponse?> PatchUpdateAsync(PatchUpdateRequest user, string id)
    {
        return await _httpService.SendAsync<PatchUpdateResponse>($"{_configUrl}/{_urlUser}/{id}", HttpMethod.Patch, user);
    }

    public async Task<DeleteResponse?> DeleteAsync(string id)
    {
        return await _httpService.SendAsync<DeleteResponse>($"{_configUrl}/{_urlUser}/{id}", HttpMethod.Delete);
    }

    public async Task<DelayedResponse?> DelayedAsync(string delay)
    {
        return await _httpService.SendAsync<DelayedResponse>($"{_configUrl}/{_urlUser}?{delay}", HttpMethod.Get);
    }
}