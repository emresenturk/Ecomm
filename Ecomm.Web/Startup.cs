using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Ecomm.Web.Startup))]
namespace Ecomm.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
