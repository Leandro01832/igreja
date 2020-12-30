using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SiteLgpd.Startup))]
namespace SiteLgpd
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
