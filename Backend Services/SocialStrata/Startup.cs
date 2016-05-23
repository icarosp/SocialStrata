using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SocialStrata.Startup))]
namespace SocialStrata
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
