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
    /// Handles status features.
    /// </summary>
    public class StatusController : Controller
    {
        private IServices statusServices = IoCContainer.Default.Resolve<IServices>();

        /// <summary>
        /// Return default view for status feature.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Gets all available statuses.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>A DataTables result that contains all available status.</returns>
        [HttpPost]
        public DataTablesResult<Status> GetAll(DefaultDataTablesRequest request)
        {
            return new DataTablesResult<Status>(
                this.statusServices.GetAllStatus().AsQueryable().ToDataTablesSortedResponse(request), 
                request, 
                JsonRequestBehavior.DenyGet);
        }

        /// <summary>
        /// Return detail view for status feature.
        /// </summary>
        /// <returns></returns>
        public ActionResult Detail()
        {
            return View();
        }

        /// <summary>
        /// Return edit view for status feature.
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit()
        {
            return View();
        }

        /// <summary>
        /// Return create view for status feature.
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }
    }
}