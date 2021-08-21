using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AINI_Fluxo_de_caixa.Startup))]
namespace AINI_Fluxo_de_caixa
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
