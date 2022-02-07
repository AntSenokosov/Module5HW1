using System.Net;
using System.Text;
using Module5HW1.Models;
using Module5HW1.Models.Request;
using Module5HW1.Models.Response;
using Module5HW1.Services.Abstract;
using Newtonsoft.Json;

namespace Module5HW1.Services;

public class AuthorizationService : IAuthorizationService
{
    private readonly IHttpService _service;
    private readonly string _urlLogin;
    private readonly string _urlRegister;
    private readonly string _configUrl;

    public AuthorizationService(IHttpService service, IConfigService config)
    {
        _service = service;
        _configUrl = config.GetConfig().Result;
        _urlLogin = @"api/login";
        _urlRegister = @"api/register";
    }

    public async Task<LoginSuccessfulResponse> LoginSuccessfullAsync(LoginSuccessfulRequest login)
    {
        var httpContent = new StringContent(JsonConvert.SerializeObject(login), Encoding.UTF8);
        var result = await _service.SendAsync($"{_configUrl}/{_urlLogin}", HttpMethod.Post, httpContent);

        var resultString = await result.Content.ReadAsStringAsync();
        var response = JsonConvert.DeserializeObject<LoginSuccessfulResponse>(resultString);

        return response!;
    }

    public async Task<LoginUnsuccessfulResponse> LoginUnsuccessfullAsync(LoginUnsuccessfulRequest login)
    {
        var httpContent = new StringContent(JsonConvert.SerializeObject(login), Encoding.UTF8);
        var result = await _service.SendAsync($"{_configUrl}/{_urlLogin}", HttpMethod.Post, httpContent);

        var resultString = await result.Content.ReadAsStringAsync();
        var response = JsonConvert.DeserializeObject<LoginUnsuccessfulResponse>(resultString);

        return response!;
    }

    public async Task<RegisterSuccessfulResponse> RegisterSuccessfullAsync(RegisterSuccessfulRequest register)
    {
        var httpContent = new StringContent(JsonConvert.SerializeObject(_urlRegister), Encoding.UTF8);
        var result = await _service.SendAsync($"{_configUrl}/{_urlRegister}", HttpMethod.Post, httpContent);

        var resultString = await result.Content.ReadAsStringAsync();
        var response = JsonConvert.DeserializeObject<RegisterSuccessfulResponse>(resultString);

        return response!;
    }

    public async Task<RegisterUnsuccessfulResponse> RegisterUnsuccessfullAsync(RegisterUnsuccessfulRequest register)
    {
        var httpContent = new StringContent(JsonConvert.SerializeObject(_urlRegister), Encoding.UTF8);
        var result = await _service.SendAsync($"{_configUrl}/{_urlRegister}", HttpMethod.Post, httpContent);

        var resultString = await result.Content.ReadAsStringAsync();
        var response = JsonConvert.DeserializeObject<RegisterUnsuccessfulResponse>(resultString);

        return response!;
    }
}