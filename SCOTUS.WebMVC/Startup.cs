using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SCOTUS.WebMVC.Startup))]
namespace SCOTUS.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
