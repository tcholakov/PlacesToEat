using Microsoft.Owin;

using Owin;

[assembly: OwinStartupAttribute(typeof(PlacesToEat.Web.Startup))]

namespace PlacesToEat.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
        }
    }
}
