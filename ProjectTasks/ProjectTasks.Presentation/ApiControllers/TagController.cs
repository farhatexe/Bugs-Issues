namespace ProjectTasks.Presentation.ApiControllers
{
    using ProjectTasks.Business.Domain.Entities;
    using ProjectTasks.Business.Services.Interfaces;
    using ProjectTasks.Crosscuttings.IoC;
    using System.Web.Http;

    /// <summary>
    /// Handles API actions for tags.
    /// </summary>
    public class TagController : ApiController
    {
        IServices tagServices = IoCContainer.Default.Resolve<IServices>();

        /// <summary>
        /// Gets tag by the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Tag.</returns>
        public IHttpActionResult Get(int id)
        {
            return Ok(this.tagServices.GetTag(id));
        }

        /// <summary>
        /// Updates the specified tag.
        /// </summary>
        /// <param name="tag">The tag.</param>
        /// <returns>Updated tag</returns>
        [HttpPost]
        public IHttpActionResult Update(Tag tag)
        {
            if (!this.ModelState.IsValid)
                return BadRequest(this.ModelState);

           return Ok(this.tagServices.UpdateTag(tag));
        }

        /// <summary>
        /// Creates the specified tag.
        /// </summary>
        /// <param name="tag">The tag.</param>
        /// <returns>Ok result.</returns>
        [HttpPut]
        public IHttpActionResult Create(Tag tag)
        {
            if (!this.ModelState.IsValid)
                return BadRequest(this.ModelState);

            this.tagServices.CreateTag(tag);
            return Ok();
        }

        /// <summary>
        /// Deletes the tag that matches the specified identifier.
        /// </summary>
        /// <param name="id">The tag identifier.</param>
        [HttpDelete]
        public void Delete(int id)
        {
            this.tagServices.DeleteTag(id);
        }
    }
}