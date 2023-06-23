using System.Globalization;
using Microsoft.AspNetCore.Localization;

namespace Colibri.Configuration.Services;

public static class ConfigureLocalizationServices
{
    public static IServiceCollection AddLocalizationServices(this IServiceCollection services)
    {
        services.Configure<RequestLocalizationOptions>(options =>
        {
            var supportedCultures = new[]
            {
                new CultureInfo("en"),
                new CultureInfo("ru")
            };
 
            options.DefaultRequestCulture = new RequestCulture("ru");
            options.SupportedCultures = supportedCultures;
            options.SupportedUICultures = supportedCultures;
        });
        
        services.AddLocalization(options => options.ResourcesPath = "Resources");
        services.AddControllersWithViews()
            .AddViewLocalization();

        return services;
    }
}