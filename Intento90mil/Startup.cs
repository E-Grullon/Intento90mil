using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Intento90mil.Startup))]
namespace Intento90mil
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
