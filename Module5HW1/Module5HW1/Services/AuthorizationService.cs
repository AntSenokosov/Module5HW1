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

    public async Task<LoginSuccessfulResponse?> LoginSuccessfullAsync(LoginSuccessfulRequest login)
    {
        return await _service.SendAsync<LoginSuccessfulResponse>($"{_configUrl}/{_urlLogin}", HttpMethod.Post, login);
    }

    public async Task<LoginUnsuccessfulResponse?> LoginUnsuccessfullAsync(LoginUnsuccessfulRequest login)
    {
        return await _service.SendAsync<LoginUnsuccessfulResponse>($"{_configUrl}/{_urlLogin}", HttpMethod.Post, login);
    }

    public async Task<RegisterSuccessfulResponse?> RegisterSuccessfullAsync(RegisterSuccessfulRequest register)
    {
        return await _service.SendAsync<RegisterSuccessfulResponse>($"{_configUrl}/{_urlRegister}", HttpMethod.Post, register);
    }

    public async Task<RegisterUnsuccessfulResponse?> RegisterUnsuccessfullAsync(RegisterUnsuccessfulRequest register)
    {
        return await _service.SendAsync<RegisterUnsuccessfulResponse>($"{_configUrl}/{_urlRegister}", HttpMethod.Post, register);
    }
}