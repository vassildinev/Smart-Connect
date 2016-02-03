using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SmartConnect.Web.App.Startup))]
namespace SmartConnect.Web.App
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
