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

    public async Task<ListResourceResponse> GetListResourceAsync()
    {
        var result = await _httpService.SendAsync($"{_configUrl}/{_urlResource}", HttpMethod.Get);

        var resultString = await result.Content.ReadAsStringAsync();
        var response = JsonConvert.DeserializeObject<ListResourceResponse>(resultString);

        return response!;
    }

    public async Task<SingleResourceResponse> GetResourceAsync(string id)
    {
        var result = await _httpService.SendAsync($"{_configUrl}/{_urlResource}/{id}", HttpMethod.Get);

        var resultString = await result.Content.ReadAsStringAsync();
        var response = JsonConvert.DeserializeObject<SingleResourceResponse>(resultString);

        return response!;
    }
}