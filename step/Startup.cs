using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(step.Startup))]
namespace step
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
