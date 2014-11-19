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
    /// Handles role features.
    /// </summary>
    public class RoleController : Controller
    {
        private IServices roleServices = IoCContainer.Default.Resolve<IServices>();

        /// <summary>
        /// Return default view for role feature.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Gets all available roles.
        /// </summary>
        /// <returns>A Json result that contains all available roles.</returns>
        public JsonResult GetAllReferential(string term)
        {
            return Json(this.roleServices.GetAllRoles().OrderBy(role => role.Label).ToList(), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Gets all available roles.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>A DataTables result that contains all available roles.</returns>
        [HttpPost]
        public DataTablesResult<Role> GetAll(DefaultDataTablesRequest request)
        {
            return new DataTablesResult<Role>(this.roleServices.GetAllRoles().AsQueryable().ToDataTablesSortedResponse(request), request, JsonRequestBehavior.DenyGet);
        }

        /// <summary>
        /// Return detail view for role feature.
        /// </summary>
        /// <returns></returns>
        public ActionResult Detail()
        {
            return View();
        }

        /// <summary>
        /// Return edit view for role feature.
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit()
        {
            return View();
        }

        /// <summary>
        /// Return create view for role feature.
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }
    }
}