using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FHL.Admin.Startup))]
namespace FHL.Admin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
