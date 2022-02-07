using Microsoft.Extensions.DependencyInjection;
using Module5HW1.Services;
using Module5HW1.Services.Abstract;

namespace Module5HW1;

public class Startup
{
    public async Task Run()
    {
        var serviceProvider = new ServiceCollection()
            .AddSingleton<IHttpService, HttpService>()
            .AddTransient<IAuthorizationService, AuthorizationService>()
            .AddTransient<IResourceService, ResourceService>()
            .AddTransient<IUserService, UserService>()
            .AddTransient<IConfigService, ConfigService>()
            .AddTransient<App>()
            .BuildServiceProvider();

        var start = serviceProvider.GetService<App>();
        await start!.Run();
    }
}