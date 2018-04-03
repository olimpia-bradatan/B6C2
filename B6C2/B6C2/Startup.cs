using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(B6C2.Startup))]
namespace B6C2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
