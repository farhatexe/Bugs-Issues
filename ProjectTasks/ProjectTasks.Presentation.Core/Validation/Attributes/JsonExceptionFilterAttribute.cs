namespace ProjectTasks.Presentation.Core.Validation.Attributes
{
    using System.Net;
    using System.Web.Mvc;

    /// <summary>
    /// Custom attribute to indicate how to handle JSON exceptions.
    /// </summary>
    public class JsonExceptionFilterAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// Called by the ASP.NET MVC framework after the action method executes.
        /// Format an exception to a proper JSON object.
        /// </summary>
        /// <param name="filterContext">The filter context</param>
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);

            if (filterContext.Exception != null)
            {
                if (filterContext.HttpContext.Request.IsAjaxRequest())
                {
                    filterContext.Result = new JsonResult()
                    {
                        Data = new
                        {
                            Message = filterContext.Exception.Message,
                            StackTrace = filterContext.Exception.StackTrace.ToString()
                        }
                    };

                    filterContext.ExceptionHandled = true;
                    filterContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                }
            }
        }
    }
}
