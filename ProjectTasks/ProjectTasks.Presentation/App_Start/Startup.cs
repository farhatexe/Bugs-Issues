[assembly: Microsoft.Owin.OwinStartup(typeof(ProjectTasks.Presentation.Startup))]

namespace ProjectTasks.Presentation
{
    using Owin;

    /// <summary>
    /// Application initialization.
    /// Owin registration (Signalr support).
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Configurations the specified application.
        /// </summary>
        /// <param name="app">The application.</param>
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}