using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BeerBrewingApp2017.Startup))]
namespace BeerBrewingApp2017
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
