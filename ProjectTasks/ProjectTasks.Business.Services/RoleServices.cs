namespace ProjectTasks.Business.Services
{
    using ProjectTasks.Business.Domain.Entities;
    using ProjectTasks.Data.Interfaces;
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Threading;

    /// <summary>
    /// Provides an implementation for IServices interface related to roles.
    /// </summary>
    public partial class Services
    {
        #region < Properties >

        /// <summary>
        /// Gets the role repository.
        /// </summary>
        /// <value>
        /// The role repository.
        /// </value>
        private IRepository<Role, IDataContext> roleRepository
        {
            get
            {
                return this.unitOfWork.GetRepository<Role>();
            }
        }

        #endregion < Properties >

        #region < Methods >

        /// <summary>
        /// Gets all roles.
        /// </summary>
        /// <returns>The entire collection of available roles.</returns>
        public IEnumerable<Role> GetAllRoles() 
        {
            return this.roleRepository.All();
        }

        /// <summary>
        /// Gets the role that matches the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// The role that matches the given identifier.
        /// </returns>
        public Role GetRole(int id)
        {
            return this.roleRepository.Single(a => a.Id == id);
        }

        /// <summary>
        /// Creates the specified role.
        /// </summary>
        /// <param name="role">The role.</param>
        /// <returns>The created role (with id, creation and update date and creation and update login set).</returns>
        public Role CreateRole(Role role)
        {
            role.CreationDate = DateTime.Now;
            role.CreationLogin = Thread.CurrentPrincipal.Identity.Name;
            role.UpdateDate = DateTime.Now;
            role.UpdateLogin = Thread.CurrentPrincipal.Identity.Name;
            this.roleRepository.Add(role);
            this.roleRepository.Context.SaveChanges();

            return role;
        }

        /// <summary>
        /// Updates the specified role.
        /// </summary>
        /// <param name="role">The role.</param>
        /// <returns>The updated role (with update date and update login set).</returns>
        public Role UpdateRole(Role role)
        {
            role.UpdateDate = DateTime.Now;
            role.UpdateLogin = Thread.CurrentPrincipal.Identity.Name;

            this.roleRepository.Update(role);
            this.roleRepository.Context.SaveChanges();

            return role;
        }

        /// <summary>
        /// Deletes role that matches the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void DeleteRole(int id)
        {
            var role = this.roleRepository.Single(a => a.Id == id);
            this.roleRepository.Delete(role);
            this.roleRepository.Context.SaveChanges();
        }

        #endregion < Methods >
    }
}
