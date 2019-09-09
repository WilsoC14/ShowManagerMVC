using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ShowManager.Startup))]
namespace ShowManager
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
