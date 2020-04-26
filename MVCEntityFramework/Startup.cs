using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCEntityFramework.Startup))]
namespace MVCEntityFramework
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
