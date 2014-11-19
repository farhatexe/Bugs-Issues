namespace ProjectTasks.Presentation.ApiControllers
{
    using ProjectTasks.Business.Domain.Entities;
    using ProjectTasks.Business.Services.Interfaces;
    using ProjectTasks.Crosscuttings.IoC;
    using System.Web.Http;

    /// <summary>
    /// Handles API actions for reasons.
    /// </summary>
    public class ReasonController : ApiController
    {
        IServices reasonServices = IoCContainer.Default.Resolve<IServices>();

        /// <summary>
        /// Gets reason by the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Reason.</returns>
        public IHttpActionResult Get(int id)
        {
            return Ok(this.reasonServices.GetReason(id));
        }

        /// <summary>
        /// Updates the specified reason.
        /// </summary>
        /// <param name="reason">The reason.</param>
        /// <returns>Updated reason</returns>
        [HttpPost]
        public IHttpActionResult Update(Reason reason)
        {
            if (!this.ModelState.IsValid)
                return BadRequest(this.ModelState);

           return Ok(this.reasonServices.UpdateReason(reason));
        }

        /// <summary>
        /// Creates the specified reason.
        /// </summary>
        /// <param name="reason">The reason.</param>
        /// <returns>Ok result.</returns>
        [HttpPut]
        public IHttpActionResult Create(Reason reason)
        {
            if (!this.ModelState.IsValid)
                return BadRequest(this.ModelState);

            this.reasonServices.CreateReason(reason);
            return Ok();
        }

        /// <summary>
        /// Deletes the reason that matches the specified identifier.
        /// </summary>
        /// <param name="id">The reason identifier.</param>
        [HttpDelete]
        public void Delete(int id)
        {
            this.reasonServices.DeleteReason(id);
        }
    }
}