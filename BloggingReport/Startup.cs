using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BloggingReport.Startup))]
namespace BloggingReport
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
