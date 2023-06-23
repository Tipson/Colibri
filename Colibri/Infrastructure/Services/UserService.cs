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

    public void Execute()
    {
        var userManager = _serviceProvider.CreateScope().ServiceProvider.GetRequiredService<UserManager<ColibriUser>>();
        // Не блокируем поток выполнения: StartAsync должен запустить выполнение фоновой задачи и завершить работу
        FindAdmin(userManager, CancellationToken.None);
    }

    private async Task FindAdmin(UserManager<ColibriUser> userManager, CancellationToken stoppingToken)
    {
        var row = await userManager.FindByNameAsync("admin");
        if (row is null)
        {
            var result = await userManager.CreateAsync(new ColibriUser("admin"), "mdmfPZLughWs1!");
            var i = 0;
        }
    }
    
    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}