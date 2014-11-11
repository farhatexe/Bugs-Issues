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
    /// Handles user features.
    /// </summary>
    public class UserController : Controller
    {
        private IServices userServices = IoCContainer.Default.Resolve<IServices>();

        /// <summary>
        /// Return default view for user feature.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Gets all available users.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>A DataTables result that contains all available users.</returns>
        [HttpPost]
        public DataTablesResult<User> GetAll(DefaultDataTablesRequest request)
        {
            return new DataTablesResult<User>(this.userServices.GetAllUsers().AsQueryable().ToDataTablesSortedResponse(request), request, JsonRequestBehavior.DenyGet);
        }

        /// <summary>
        /// Return detail view for user feature.
        /// </summary>
        /// <returns></returns>
        public ActionResult Detail()
        {
            return View();
        }

        /// <summary>
        /// Return edit view for user feature.
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit()
        {
            return View();
        }

        /// <summary>
        /// Return create view for user feature.
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }
    }
}