using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MnuMain.Startup))]
namespace MnuMain
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
