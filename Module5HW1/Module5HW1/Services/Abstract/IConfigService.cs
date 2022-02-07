using Module5HW1.Config;
namespace Module5HW1.Services.Abstract;

public interface IConfigService
{
    public Task<string> GetConfig();
}