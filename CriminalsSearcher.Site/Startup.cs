using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CriminalsSearcher.Site.Startup))]
namespace CriminalsSearcher.Site {
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}