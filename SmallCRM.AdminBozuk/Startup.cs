using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SmallCRM.Admin.Startup))]
namespace SmallCRM.Admin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
