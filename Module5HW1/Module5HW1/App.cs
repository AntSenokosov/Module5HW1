using Module5HW1.Models.Request;
using Module5HW1.Services.Abstract;

namespace Module5HW1;

public class App
{
    private readonly IAuthorizationService _authorization;
    private readonly IResourceService _resource;
    private readonly IUserService _user;

    public App(IAuthorizationService authorization, IResourceService resource, IUserService user)
    {
        _authorization = authorization;
        _resource = resource;
        _user = user;
    }

    public async Task Run()
    {
        var loginSuccessful = new LoginSuccessfulRequest
        {
            Email = "eve.holt@reqres.in",
            Password = "cityslicka"
        };

        var loginUnsuccessfull = new LoginUnsuccessfulRequest()
        {
            Email = "sydney@fife"
        };

        var patchUpdate = new PatchUpdateRequest()
        {
            Name = "morpheus",
            Job = "zion resident"
        };

        var postCreate = new PostCreateRequest()
        {
            Name = "morpheus",
            Job = "leader"
        };

        var putUpdate = new PutUpdateRequest()
        {
            Name = "morpheus",
            Job = "zion resident"
        };

        var registerSuccessful = new RegisterSuccessfulRequest()
        {
            Email = "eve.holt@reqres.in",
            Password = "pistol"
        };

        var registerUnsuccessful = new RegisterUnsuccessfulRequest()
        {
            Email = "sydney@fife"
        };

        var listTask = new List<Task>();

        listTask.Add(Task.Run(async () =>
        {
            var result = await _authorization.LoginSuccessfullAsync(loginSuccessful);
            Console.WriteLine(result!.Token);
        }));
        listTask.Add(Task.Run(async () =>
        {
            var result = await _authorization.LoginUnsuccessfullAsync(loginUnsuccessfull);
            Console.WriteLine(result!.Error);
        }));
        listTask.Add(Task.Run(async () =>
        {
            var result = await _authorization.RegisterSuccessfullAsync(registerSuccessful);
            Console.WriteLine($"{result!.Id} {result.Token}");
        }));
        listTask.Add(Task.Run(async () =>
        {
            var result = await _authorization.RegisterUnsuccessfullAsync(registerUnsuccessful);
            Console.WriteLine(result!.Error);
        }));
        listTask.Add(Task.Run(async () =>
        {
            var result = await _resource.GetResourceAsync("2");
            Console.WriteLine($"Resource: {result!.Resource.Id} {result.Resource.Name} {result.Resource.Year} {result.Resource.Color} {result.Resource.PantoneValue} Support: {result.Support.Text} {result.Support.Url}");
        }));
        listTask.Add(Task.Run(async () =>
        {
            var result = await _resource.GetListResourceAsync();
            Console.WriteLine($"{result!.Page} {result.PerPage} {result.TotalPages} {result.Total} {result.Support.Text} {result.Support.Url}");
            foreach (var item in result.Resources)
            {
                Console.WriteLine($"{item.Id} {item.Name} {item.Year} {item.Color} {item.PantoneValue}");
            }
        }));
        listTask.Add(Task.Run(async () =>
        {
            var result = await _user.CreateAsync(postCreate);
            Console.WriteLine($"{result!.Id} {result.Job} {result.Name} {result.CreatedAt}");
        }));
        listTask.Add(Task.Run(async () =>
        {
            var result = await _user.PutUpdateAsync(putUpdate, "2");
            Console.WriteLine($"{result!.Job} {result.Name} {result.UpdatedAt}");
        }));
        listTask.Add(Task.Run(async () =>
        {
            var result = await _user.PatchUpdateAsync(patchUpdate, "2");
            Console.WriteLine($"{result!.Job} {result.Name} {result.UpdatedAt}");
        }));
        listTask.Add(Task.Run(async () =>
        {
            var result = await _user.DeleteAsync("2");
        }));
        listTask.Add(Task.Run(async () =>
        {
            var result = await _user.DelayedAsync("delay=3");
            Console.WriteLine($"Page: {result!.Page} {result.PerPage} {result.TotalPages} {result.Total} Support: {result.Support.Text} {result.Support.Url} Users:");
            foreach (var item in result.Users)
            {
                Console.WriteLine($"{item.Id} {item.FirstName} {item.LastName} {item.Email} {item.Avatar}");
            }
        }));
        listTask.Add(Task.Run(async () =>
        {
            var result = await _user.GetUserAsync("2");
            Console.WriteLine($"User: {result!.User.Id} {result.User.FirstName} {result.User.Email} {result.User.Avatar} Support: {result.Support.Text} {result.Support.Url}");
        }));
        listTask.Add(Task.Run(async () =>
        {
            var result = await _user.GetListUsersAsync("2");
            Console.WriteLine($"Page: {result!.Page} {result.PerPage} {result.TotalPages} {result.Total} Support: {result.Support.Text} {result.Support.Url} Users:");
            foreach (var item in result.Users)
            {
                Console.WriteLine($"{item.Id} {item.FirstName} {item.LastName} {item.Email} {item.Avatar}");
            }
        }));

        await Task.WhenAll(listTask);
    }
}