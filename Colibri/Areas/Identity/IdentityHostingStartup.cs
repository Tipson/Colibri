using Colibri.Areas.Identity;

[assembly: HostingStartup(typeof(IdentityHostingStartup))]
namespace Colibri.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                

            });
        }
    }
}
