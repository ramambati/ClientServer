using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Demo_5.Startup))]
namespace Demo_5
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
