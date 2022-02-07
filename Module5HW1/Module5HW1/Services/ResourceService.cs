using Module5HW1.Models.Response;
using Module5HW1.Services.Abstract;
using Newtonsoft.Json;

namespace Module5HW1.Services;

public class ResourceService : IResourceService
{
    private readonly IHttpService _httpService;
    private readonly string _configUrl;
    private readonly string _urlResource = @"api/unknown";

    public ResourceService(IHttpService httpService, IConfigService config)
    {
        _httpService = httpService;
        _configUrl = config.GetConfig().Result;
    }

    public async Task<ListResourceResponse?> GetListResourceAsync()
    {
        return await _httpService.SendAsync<ListResourceResponse>($"{_configUrl}/{_urlResource}", HttpMethod.Get);
    }

    public async Task<SingleResourceResponse?> GetResourceAsync(string id)
    {
        return await _httpService.SendAsync<SingleResourceResponse>($"{_configUrl}/{_urlResource}/{id}", HttpMethod.Get);
    }
}