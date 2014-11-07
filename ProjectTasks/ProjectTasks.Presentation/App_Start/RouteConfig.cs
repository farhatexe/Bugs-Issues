namespace ProjectTasks.Presentation
{
    using System.Web.Mvc;
    using System.Web.Routing;

    /// <summary>
    /// Route configuration for web application.
    /// </summary>
    public class RouteConfig
    {
        /// <summary>
        /// Registers the routes.
        /// </summary>
        /// <remarks>Default routes have been used.</remarks>
        /// <param name="routes">The routes.</param>
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "template",
                url: "template/{module}/{template}",
                defaults: new { controller = "Template", action = "Index" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

        }
    }
}
