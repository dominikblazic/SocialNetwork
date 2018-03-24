using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MiniFacebook.Startup))]
namespace MiniFacebook
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
