using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OnlineFoodOrderManagment.Startup))]
namespace OnlineFoodOrderManagment
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
