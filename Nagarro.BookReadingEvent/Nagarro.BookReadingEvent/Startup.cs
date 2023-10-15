using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Nagarro.BookReadingEvent.Startup))]
namespace Nagarro.BookReadingEvent
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
