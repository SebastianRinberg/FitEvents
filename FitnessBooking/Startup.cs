using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FitnessBooking.Startup))]
namespace FitnessBooking
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
