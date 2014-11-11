namespace ProjectTasks.Presentation.ApiControllers
{
    using ProjectTasks.Business.Domain.Entities;
    using ProjectTasks.Business.Services.Interfaces;
    using ProjectTasks.Crosscuttings.IoC;
    using System.Web.Http;

    /// <summary>
    /// Handles API actions for groups.
    /// </summary>
    public class GroupController : ApiController
    {
        IServices groupServices = IoCContainer.Default.Resolve<IServices>();

        /// <summary>
        /// Gets group by the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Group.</returns>
        public IHttpActionResult Get(int id)
        {
            return Ok(this.groupServices.GetGroup(id));
        }

        /// <summary>
        /// Updates the specified group.
        /// </summary>
        /// <param name="group">The group.</param>
        /// <returns>Updated group</returns>
        [HttpPost]
        public IHttpActionResult Update(Group group)
        {
            if (!this.ModelState.IsValid)
                return BadRequest(this.ModelState);

           return Ok(this.groupServices.UpdateGroup(group));
        }

        /// <summary>
        /// Creates the specified group.
        /// </summary>
        /// <param name="group">The group.</param>
        /// <returns>Ok result.</returns>
        [HttpPut]
        public IHttpActionResult Create(Group group)
        {
            if (!this.ModelState.IsValid)
                return BadRequest(this.ModelState);

            this.groupServices.CreateGroup(group);
            return Ok();
        }

        /// <summary>
        /// Deletes the group that matches the specified identifier.
        /// </summary>
        /// <param name="id">The group identifier.</param>
        [HttpDelete]
        public void Delete(int id)
        {
            this.groupServices.DeleteGroup(id);
        }
    }
}