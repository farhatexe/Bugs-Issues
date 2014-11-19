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
    /// Handles reason features.
    /// </summary>
    public class ReasonController : Controller
    {
        private IServices reasonServices = IoCContainer.Default.Resolve<IServices>();

        /// <summary>
        /// Return default view for reason feature.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Gets all available reasons.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>A DataTables result that contains all available reason.</returns>
        [HttpPost]
        public DataTablesResult<Reason> GetAll(DefaultDataTablesRequest request)
        {
            return new DataTablesResult<Reason>(
                this.reasonServices.GetAllReasons().AsQueryable().ToDataTablesSortedResponse(request),
                request,
                JsonRequestBehavior.DenyGet);
        }

        /// <summary>
        /// Return detail view for reason feature.
        /// </summary>
        /// <returns></returns>
        public ActionResult Detail()
        {
            return View();
        }

        /// <summary>
        /// Return edit view for reason feature.
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit()
        {
            return View();
        }

        /// <summary>
        /// Return create view for reason feature.
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }
    }
}