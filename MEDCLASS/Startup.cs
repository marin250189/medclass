using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MEDCLASS.Startup))]
namespace MEDCLASS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
