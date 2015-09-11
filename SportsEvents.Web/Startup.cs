using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SportsEvents.Web.Startup))]
namespace SportsEvents.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
