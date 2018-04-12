using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NovoRumoProjeto.Startup))]
namespace NovoRumoProjeto
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
