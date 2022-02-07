using Module5HW1.Models.Request;
using Module5HW1.Models.Response;

namespace Module5HW1.Services.Abstract;

public interface IAuthorizationService
{
    public Task<LoginSuccessfulResponse> LoginSuccessfullAsync(LoginSuccessfulRequest login);
    public Task<LoginUnsuccessfulResponse> LoginUnsuccessfullAsync(LoginUnsuccessfulRequest login);
    public Task<RegisterSuccessfulResponse> RegisterSuccessfullAsync(RegisterSuccessfulRequest register);
    public Task<RegisterUnsuccessfulResponse> RegisterUnsuccessfullAsync(RegisterUnsuccessfulRequest register);
}