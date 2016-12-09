using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TheNorthernHandyman.Startup))]
namespace TheNorthernHandyman
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
