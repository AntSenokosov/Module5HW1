using Module5HW1.Models.Request;
using Module5HW1.Models.Response;

namespace Module5HW1.Services.Abstract;

public interface IUserService
{
    public Task<ListUserResponse> GetListUsersAsync(string page);
    public Task<SingleUserResponse> GetUserAsync(string id);
    public Task<PostCreateResponse> CreateAsync(PostCreateRequest user);
    public Task<PutUpdateResponse> PutUpdateAsync(PutUpdateRequest user, string id);
    public Task<PatchUpdateResponse> PatchUpdateAsync(PatchUpdateRequest user, string id);
    public Task<DeleteResponse> DeleteAsync(string id);
    public Task<DelayedResponse> DelayedAsync(string delay);
}