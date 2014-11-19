namespace ProjectTasks.Presentation.ApiControllers
{
    using ProjectTasks.Business.Domain.Entities;
    using ProjectTasks.Business.Services.Interfaces;
    using ProjectTasks.Crosscuttings.IoC;
    using System.Web.Http;

    /// <summary>
    /// Handles API actions for roles.
    /// </summary>
    public class RoleController : ApiController
    {
        IServices roleServices = IoCContainer.Default.Resolve<IServices>();

        /// <summary>
        /// Gets role by the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Role.</returns>
        public IHttpActionResult Get(int id)
        {
            return Ok(this.roleServices.GetRole(id));
        }

        /// <summary>
        /// Updates the specified role.
        /// </summary>
        /// <param name="role">The role.</param>
        /// <returns>Updated role</returns>
        [HttpPost]
        public IHttpActionResult Update(Role role)
        {
            if (!this.ModelState.IsValid)
                return BadRequest(this.ModelState);

           return Ok(this.roleServices.UpdateRole(role));
        }

        /// <summary>
        /// Creates the specified role.
        /// </summary>
        /// <param name="role">The role.</param>
        /// <returns>Ok result.</returns>
        [HttpPut]
        public IHttpActionResult Create(Role role)
        {
            if (!this.ModelState.IsValid)
                return BadRequest(this.ModelState);

            this.roleServices.CreateRole(role);
            return Ok();
        }

        /// <summary>
        /// Deletes the role that matches the specified identifier.
        /// </summary>
        /// <param name="id">The role identifier.</param>
        [HttpDelete]
        public void Delete(int id)
        {
            this.roleServices.DeleteRole(id);
        }
    }
}