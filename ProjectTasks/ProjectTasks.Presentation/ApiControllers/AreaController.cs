namespace ProjectTasks.Presentation.ApiControllers
{
    using ProjectTasks.Business.Domain.Entities;
    using ProjectTasks.Business.Services.Interfaces;
    using ProjectTasks.Crosscuttings.IoC;
    using System.Web.Http;

    /// <summary>
    /// Handles API actions for areas.
    /// </summary>
    public class AreaController : ApiController
    {
        IServices areaServices = IoCContainer.Default.Resolve<IServices>();

        /// <summary>
        /// Gets area by the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Area.</returns>
        public IHttpActionResult Get(int id)
        {
            return Ok(this.areaServices.GetArea(id));
        }

        /// <summary>
        /// Updates the specified area.
        /// </summary>
        /// <param name="area">The area.</param>
        /// <returns>Updated area</returns>
        [HttpPost]
        public IHttpActionResult Update(Area area)
        {
            if (!this.ModelState.IsValid)
                return BadRequest(this.ModelState);

           return Ok(this.areaServices.UpdateArea(area));
        }

        /// <summary>
        /// Creates the specified area.
        /// </summary>
        /// <param name="area">The area.</param>
        /// <returns>Ok result.</returns>
        [HttpPut]
        public IHttpActionResult Create(Area area)
        {
            if (!this.ModelState.IsValid)
                return BadRequest(this.ModelState);

            this.areaServices.CreateArea(area);
            return Ok();
        }

        /// <summary>
        /// Deletes the area that matches the specified identifier.
        /// </summary>
        /// <param name="id">The area identifier.</param>
        [HttpDelete]
        public void Delete(int id)
        {
            this.areaServices.DeleteArea(id);
        }
    }
}