using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Bunch.Startup))]
namespace Bunch
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
