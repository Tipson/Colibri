using System.Text.Json.Serialization;
using Colibri.Areas.Identity.Data;
using Colibri.Configuration.Services;
using Colibri.Infrastructure.DbContext;
using Colibri.Infrastructure.Services;
using Colibri.Middleware;
using Microsoft.EntityFrameworkCore;
using NJsonSchema.Generation;

namespace Colibri;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    
    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddAutoMapperServices();
        services.AddIdentityServices(Configuration);
        services.AddInfrastructureServices();
        services.AddColibriDbContext(Configuration);
        services.AddLocalizationServices();

        services.AddDistributedMemoryCache();

        services
            .AddControllers()
            .AddJsonOptions(
                options =>
                {
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                    options.JsonSerializerOptions.AllowTrailingCommas = true;
                });

        services.AddOpenApiDocument(
            settings =>
            {
                settings.DocumentName = "openapi";
                settings.SchemaGenerator.Settings.DefaultReferenceTypeNullHandling = ReferenceTypeNullHandling.NotNull;
            });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
    {
        app.UseMiddleware<EnsureUserExistsMiddleware>();
        
        if (env.IsDevelopment())
        {
            app.UseOpenApi(settings => settings.Path = "/api/swagger/{documentName}/swagger.json");
            app.UseSwaggerUi3(
                settings =>
                {
                    settings.Path = "/api/swagger";
                    settings.DocumentPath = "/api/swagger/{documentName}/swagger.json";
                });
            app.UseReDoc(
                settings =>
                {
                    settings.Path = "/api/redoc";
                    settings.DocumentPath = "/api/swagger/{documentName}/swagger.json"; 
                });
            
            app.UseDeveloperExceptionPage();

            using var scope = serviceProvider.CreateScope();
            var colibriDbContext = scope.ServiceProvider.GetRequiredService<ColibriDbContext>();
            colibriDbContext.Database.Migrate();
            var colibriAuthDbContext = scope.ServiceProvider.GetRequiredService<ColibriAuthContext>();
            colibriAuthDbContext.Database.Migrate();
        }
        
        app.UseHttpsRedirection();
        
        app.UseRequestLocalization();
        app.UseStaticFiles();
        
        app.UseRouting();
        
        app.UseAuthentication();
        app.UseAuthorization();
        
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}");
            endpoints.MapControllers();
            endpoints.MapRazorPages();
        });
        
        app.UseOpenApi(settings => settings.Path = "/api/swagger/{documentName}/swagger.json");
        app.UseSwaggerUi3(
            settings =>
            {
                settings.Path = "/api/swagger";
                settings.DocumentPath = "/api/swagger/{documentName}/swagger.json";
            });
        app.UseReDoc(
            settings =>
            {
                settings.Path = "/api/redoc";
                settings.DocumentPath = "/api/swagger/{documentName}/swagger.json"; 
            });
    }
}
