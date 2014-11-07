namespace ProjectTasks.Presentation
{
    using ProjectTasks.Presentation.Core.Validation.Attributes;
    using System.Web.Mvc;

    /// <summary>
    /// Handle pre and post actions behavior to controller action methods.
    /// </summary>
    public class FilterConfig
    {
        /// <summary>
        /// Registers the global filters.
        /// </summary>
        /// <param name="filters">The filters.</param>
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new JsonExceptionFilterAttribute());
            filters.Add(new HandleErrorAttribute());
        }
    }
}
