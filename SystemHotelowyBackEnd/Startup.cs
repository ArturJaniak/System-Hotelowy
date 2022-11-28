using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SystemHotelowyBackEnd.Startup))]
namespace SystemHotelowyBackEnd
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
