namespace ProjectTasks.Presentation
{
    using System.Web.Http;

    /// <summary>
    /// API Route configuration for web application.
    /// </summary>
    public class RouteApiConfig
    {
        /// <summary>
        /// Registers routes from the specified http configuration.
        /// </summary>
        /// <param name="config">The configuration.</param>
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}