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
            mc.AddProfile(new ErrorProfile());
            mc.AddProfile(new PorfolioProfile());
            mc.AddProfile(new ProductProfile());
            mc.AddProfile(new ReviewProfile());
            mc.AddProfile(new StatisticProfile());
        });

        var mapper = mapperConfig.CreateMapper();
        services.AddSingleton(mapper);

        return services;
    }
}