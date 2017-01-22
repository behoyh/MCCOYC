using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MCCOYC.Startup))]
namespace MCCOYC
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
