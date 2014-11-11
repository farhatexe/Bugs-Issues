namespace ProjectTasks.Presentation.ApiControllers
{
    using ProjectTasks.Business.Domain.Entities;
    using ProjectTasks.Business.Services.Interfaces;
    using ProjectTasks.Crosscuttings.IoC;
    using System.Web.Http;

    /// <summary>
    /// Handles API actions for users.
    /// </summary>
    public class UserController : ApiController
    {
        IServices userServices = IoCContainer.Default.Resolve<IServices>();

        /// <summary>
        /// Gets user by the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>User.</returns>
        public IHttpActionResult Get(int id)
        {
            return Ok(this.userServices.GetUser(id));
        }

        /// <summary>
        /// Updates the specified user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>Updated user</returns>
        [HttpPost]
        public IHttpActionResult Update(User user)
        {
            if (!this.ModelState.IsValid)
                return BadRequest(this.ModelState);

           return Ok(this.userServices.UpdateUser(user));
        }

        /// <summary>
        /// Creates the specified user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>Ok result.</returns>
        [HttpPut]
        public IHttpActionResult Create(User user)
        {
            if (!this.ModelState.IsValid)
                return BadRequest(this.ModelState);

            this.userServices.CreateUser(user);
            return Ok();
        }

        /// <summary>
        /// Deletes the user that matches the specified identifier.
        /// </summary>
        /// <param name="id">The user identifier.</param>
        [HttpDelete]
        public void Delete(int id)
        {
            this.userServices.DeleteUser(id);
        }
    }
}