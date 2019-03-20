using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FinalAssingment.Startup))]
namespace FinalAssingment
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
