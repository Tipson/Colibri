using Colibri.Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;

namespace Colibri.Configuration.Services;

public static class ConfigureDbContext
{
    public static IServiceCollection AddColibriDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContextPool<Infrastructure.DbContext.ColibriDbContext>(
            (s, b) =>
                b.UseSqlServer(configuration.GetConnectionString("ColibriDb")));

        return services;
    }
}