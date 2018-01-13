using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Yarly_s_Inside_Solutions.Startup))]
namespace Yarly_s_Inside_Solutions
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
