using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SystemHotelowyVer3.Startup))]
namespace SystemHotelowyVer3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
