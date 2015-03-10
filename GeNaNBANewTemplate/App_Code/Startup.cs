using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GeNaNBA.Startup))]
namespace GeNaNBA
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
