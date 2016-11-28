using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StringManipulation.Startup))]
namespace StringManipulation
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
