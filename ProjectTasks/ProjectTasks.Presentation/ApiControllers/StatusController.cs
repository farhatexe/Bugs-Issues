namespace ProjectTasks.Presentation.ApiControllers
{
    using ProjectTasks.Business.Domain.Entities;
    using ProjectTasks.Business.Services.Interfaces;
    using ProjectTasks.Crosscuttings.IoC;
    using System.Web.Http;

    /// <summary>
    /// Handles API actions for statuses.
    /// </summary>
    public class StatusController : ApiController
    {
        IServices statusServices = IoCContainer.Default.Resolve<IServices>();

        /// <summary>
        /// Gets status by the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>status.</returns>
        public IHttpActionResult Get(int id)
        {
            return Ok(this.statusServices.GetStatus(id));
        }

        /// <summary>
        /// Updates the specified status.
        /// </summary>
        /// <param name="status">The status.</param>
        /// <returns>Updated status</returns>
        [HttpPost]
        public IHttpActionResult Update(Status status)
        {
            if (!this.ModelState.IsValid)
                return BadRequest(this.ModelState);

            return Ok(this.statusServices.UpdateStatus(status));
        }

        /// <summary>
        /// Creates the specified status.
        /// </summary>
        /// <param name="status">The status.</param>
        /// <returns>Ok result.</returns>
        [HttpPut]
        public IHttpActionResult Create(Status status)
        {
            if (!this.ModelState.IsValid)
                return BadRequest(this.ModelState);

            this.statusServices.CreateStatus(status);
            return Ok();
        }

        /// <summary>
        /// Deletes the status that matches the specified identifier.
        /// </summary>
        /// <param name="id">The status identifier.</param>
        [HttpDelete]
        public void Delete(int id)
        {
            this.statusServices.DeleteStatus(id);
        }
    }
}