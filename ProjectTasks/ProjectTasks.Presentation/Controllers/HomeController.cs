namespace Mercato.Presentation.Controllers
{
    using System.Web.Mvc;

    /// <summary>
    /// Controller for welcome page.
    /// </summary>
    [Authorize]
    public class HomeController : Controller
    {
        /// <summary>
        /// Action to load dashboard view.
        /// </summary>
        /// <returns></returns>
        public ActionResult Dashboard()
        {
            return View();
        }

        /// <summary>
        /// Action to load index view.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }
    }
}