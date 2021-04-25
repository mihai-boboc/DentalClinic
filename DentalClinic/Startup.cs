using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DentalClinic.Startup))]
namespace DentalClinic
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
