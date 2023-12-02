using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcCreditApp1.Startup))]
namespace MvcCreditApp1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
