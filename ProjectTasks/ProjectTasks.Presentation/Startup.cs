using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProjectTasks.Presentation.Startup))]
namespace ProjectTasks.Presentation
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
