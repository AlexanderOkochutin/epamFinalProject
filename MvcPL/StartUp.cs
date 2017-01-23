using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(MvcPL.Startup))]
namespace MvcPL
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}