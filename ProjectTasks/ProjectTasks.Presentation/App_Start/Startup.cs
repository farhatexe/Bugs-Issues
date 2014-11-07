[assembly: Microsoft.Owin.OwinStartup(typeof(ProjectTasks.Presentation.Startup))]

namespace ProjectTasks.Presentation
{
    using Microsoft.Owin;
    using Owin;

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}