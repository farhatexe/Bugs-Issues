namespace ProjectTasks.Presentation
{
    using System;
    using System.Security.Principal;
    using System.Threading;
    using System.Web;
    using System.Web.Http;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;

    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            MvcSiteMapProvider.DI.Composer.Compose();
            GlobalConfiguration.Configure(RouteApiConfig.Register);
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ModelBinderConfig.RegisterModelBinders();
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            HttpContext.Current.User = Thread.CurrentPrincipal as WindowsPrincipal;
        }
    }
}
