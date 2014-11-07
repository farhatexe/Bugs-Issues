namespace ProjectTasks.Presentation.Controllers
{
    using System.Web.Mvc;

    /// <summary>
    /// Represents the template MVC controller to server static template (with no data).
    /// </summary>
    public class TemplateController : Controller
    {
        /// <summary>
        /// Indexes the specified module.
        /// </summary>
        /// <param name="module">The module.</param>
        /// <param name="template">The template.</param>
        /// <returns></returns>
        public ActionResult Index(string module, string template)
        {
            return RedirectPermanent("/Static/templates/" + module + "/" + template);
        }

        /// <summary>
        /// Confirms this instance.
        /// </summary>
        /// <returns></returns>
        public ActionResult Confirm()
        {
            return this.View();
        }
    }
}