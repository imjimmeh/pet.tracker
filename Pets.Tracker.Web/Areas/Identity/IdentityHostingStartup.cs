using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(Pets.Tracker.Web.Areas.Identity.IdentityHostingStartup))]
namespace Pets.Tracker.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
        }
    }
}