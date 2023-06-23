using AutoMapper;
using Colibri.Configuration.AutoMapper;

namespace Colibri.Configuration.Services;

public static class ConfigureAutoMapper
{
    public static IServiceCollection AddAutoMapperServices(this IServiceCollection services)
    {
        var mapperConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new TeamMemberProfile());
        });

        var mapper = mapperConfig.CreateMapper();
        services.AddSingleton(mapper);

        return services;
    }
}