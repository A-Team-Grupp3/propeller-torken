using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(PropellerTorkenMain.Areas.Identity.IdentityHostingStartup))]

namespace PropellerTorkenMain.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
            });
        }
    }
}