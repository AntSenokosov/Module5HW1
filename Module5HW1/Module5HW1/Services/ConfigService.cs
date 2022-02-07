using Module5HW1.Services.Abstract;
using Newtonsoft.Json;

namespace Module5HW1.Services;

public class ConfigService : IConfigService
{
    private readonly string _config = @"Config/config.json";

    public async Task<string> GetConfig()
    {
        var configFile = await File.ReadAllTextAsync(_config);
        var config = JsonConvert.DeserializeObject<Config.Config>(configFile);

        return config!.Url;
    }
}