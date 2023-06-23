using Colibri.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;

namespace Colibri.Infrastructure.Services;

public class UserService
{
    private readonly IServiceProvider _serviceProvider;

    public UserService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task Execute()
    {
        Console.WriteLine("Executing user creation...");
        var userManager = _serviceProvider.CreateScope().ServiceProvider.GetRequiredService<UserManager<ColibriUser>>();
        // Не блокируем поток выполнения: StartAsync должен запустить выполнение фоновой задачи и завершить работу
        await FindAdmin(userManager, CancellationToken.None);
    }

    private async Task FindAdmin(UserManager<ColibriUser> userManager, CancellationToken stoppingToken)
    {
        var row = await userManager.FindByNameAsync("admin");
    
        if (row != null)
        {
            Console.WriteLine("User 'admin' already exists.");
            return;
        }

        var user = new ColibriUser("admin"); // передаём userName в конструктор

        var result = await userManager.CreateAsync(user, "mdmfPZLughWs1!");

        if (result.Succeeded)
        {
            Console.WriteLine("User created successfully.");
        }
        else
        {
            Console.WriteLine("User creation failed.");
            foreach (var error in result.Errors)
            {
                Console.WriteLine($"Code: {error.Code}. Description: {error.Description}");
            }
        }
    }
    
    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}