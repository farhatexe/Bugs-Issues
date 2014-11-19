namespace ProjectTasks.Presentation.Controllers
{
    using ProjectTasks.Business.Domain.Entities;
    using ProjectTasks.Business.Services.Interfaces;
    using ProjectTasks.Crosscuttings.IoC;
    using ProjectTasks.Presentation.Core.Bootstrap.Component.DataTables;
    using ProjectTasks.Presentation.Core.Bootstrap.Extensions;
    using System.Linq;
    using System.Web.Mvc;

    /// <summary>
    /// Handles tag features.
    /// </summary>
    public class TagController : Controller
    {
        private IServices tagServices = IoCContainer.Default.Resolve<IServices>();

        /// <summary>
        /// Return default view for tag feature.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Gets all available tags.
        /// </summary>
        /// <returns>A Json result that contains all available tags.</returns>
        public JsonResult GetAllReferential(string term)
        {
            return Json(this.tagServices.GetAllTags().OrderBy(tag => tag.Label).ToList(), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Gets all available tags.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>A DataTables result that contains all available tags.</returns>
        [HttpPost]
        public DataTablesResult<Tag> GetAll(DefaultDataTablesRequest request)
        {
            return new DataTablesResult<Tag>(this.tagServices.GetAllTags().AsQueryable().ToDataTablesSortedResponse(request), request, JsonRequestBehavior.DenyGet);
        }

        /// <summary>
        /// Return detail view for tag feature.
        /// </summary>
        /// <returns></returns>
        public ActionResult Detail()
        {
            return View();
        }

        /// <summary>
        /// Return edit view for tag feature.
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit()
        {
            return View();
        }

        /// <summary>
        /// Return create view for tag feature.
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }
    }
}