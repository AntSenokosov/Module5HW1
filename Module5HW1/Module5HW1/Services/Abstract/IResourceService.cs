using Module5HW1.Models.Response;

namespace Module5HW1.Services.Abstract;

public interface IResourceService
{
    public Task<ListResourceResponse> GetListResourceAsync();
    public Task<SingleResourceResponse> GetResourceAsync(string id);
}