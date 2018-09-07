using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Odontology.Backend.Startup))]
namespace Odontology.Backend
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
