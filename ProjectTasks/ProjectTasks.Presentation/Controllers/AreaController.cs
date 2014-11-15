namespace ProjectTasks.Presentation.Controllers
{
    using ProjectTasks.Business.Domain.Entities;
    using ProjectTasks.Business.Services.Interfaces;
    using ProjectTasks.Crosscuttings.IoC;
    using ProjectTasks.Crosscuttings.Extensions;
    using ProjectTasks.Presentation.Core.Bootstrap.Component.DataTables;
    using ProjectTasks.Presentation.Core.Bootstrap.Extensions;
    using System.Linq;
    using System.Web.Mvc;
    using System.Collections.Generic;

    /// <summary>
    /// Handles area features.
    /// </summary>
    public class AreaController : Controller
    {
        private IServices areaServices = IoCContainer.Default.Resolve<IServices>();

        /// <summary>
        /// Return default view for area feature.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetAll()
        {
            var flattenAreas = new List<Area>();
            this.areaServices.GetAllAreas().Where(a => a.ParentId == null).ToList().Flatten(a => a.SortedChildren, ref flattenAreas);

            return Json(flattenAreas.Select(a => new { Id = a.Id, ParentId = a.ParentId, Label = a.Label }), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Gets all available areas.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>A DataTables result that contains all available areas.</returns>
        [HttpPost]
        public DataTablesResult<Area> GetAll(DefaultDataTablesRequest request)
        {
            return new DataTablesResult<Area>(this.areaServices.GetAllAreas().AsQueryable().ToDataTablesSortedResponse(request), request, JsonRequestBehavior.DenyGet);
        }

        /// <summary>
        /// Return detail view for area feature.
        /// </summary>
        /// <returns></returns>
        public ActionResult Detail()
        {
            return View();
        }

        /// <summary>
        /// Return edit view for area feature.
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit()
        {
            return View();
        }

        /// <summary>
        /// Return create view for area feature.
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }
    }
}