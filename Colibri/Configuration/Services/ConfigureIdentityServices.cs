using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Colibri.Areas.Identity.Data;
using Colibri.Infrastructure.Services;
using Colibri.Data;

namespace Colibri.Configuration.Services;

public static class ConfigureIdentityServices
{
    public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ColibriAuthContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("ColibriAuthContextConnection")));

        services.AddDefaultIdentity<ColibriUser>()
            .AddEntityFrameworkStores<ColibriAuthContext>()
            .AddUserManager<UserManager<ColibriUser>>()
            .AddSignInManager<SignInManager<ColibriUser>>();        
        services.AddTransient<UserService>();
        
        services.AddRazorPages();

        services.Configure<IdentityOptions>(options =>
        {
            // Password settings.
            options.Password.RequireDigit = true;
            options.Password.RequireLowercase = true;
            options.Password.RequireNonAlphanumeric = true;
            options.Password.RequireUppercase = true;
            options.Password.RequiredLength = 6;
            options.Password.RequiredUniqueChars = 1;

            // Lockout settings.
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            options.Lockout.MaxFailedAccessAttempts = 5;
            options.Lockout.AllowedForNewUsers = true;

            // User settings.
            options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
            options.User.RequireUniqueEmail = false;

            options.SignIn.RequireConfirmedAccount = false;
            options.SignIn.RequireConfirmedEmail = false;
            options.SignIn.RequireConfirmedPhoneNumber = false;
        });

        services.ConfigureApplicationCookie(options =>
        {
            // Cookie settings
            options.Cookie.HttpOnly = true;
            options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

            options.LoginPath = "/Identity/Account/Login";
            options.AccessDeniedPath = "/Identity/Account/AccessDenied";
            options.SlidingExpiration = true;
        });

        return services;
    }
}