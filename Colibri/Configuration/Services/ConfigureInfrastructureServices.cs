using Colibri.Infrastructure;
using Colibri.Infrastructure.Services;

namespace Colibri.Configuration.Services;

public static class ConfigureInfrastructureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<ITeamMemberService, TeamMemberService>();
        services.AddScoped<IErrorService, ErrorService>();


        return services;
    }
}