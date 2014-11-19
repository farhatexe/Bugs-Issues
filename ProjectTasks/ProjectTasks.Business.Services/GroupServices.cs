namespace ProjectTasks.Business.Services
{
    using ProjectTasks.Business.Domain.Entities;
    using ProjectTasks.Data.Interfaces;
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Threading;

    /// <summary>
    /// Provides an implementation for IServices interface related to groups.
    /// </summary>
    public partial class Services
    {
        #region < Properties >

        /// <summary>
        /// Gets the group repository.
        /// </summary>
        /// <value>
        /// The group repository.
        /// </value>
        private IRepository<Group, IDataContext> groupRepository
        {
            get
            {
                return this.unitOfWork.GetRepository<Group>();
            }
        }

        #endregion < Properties >

        #region < Methods >

        /// <summary>
        /// Gets all groups.
        /// </summary>
        /// <returns>The entire collection of available groups.</returns>
        public IEnumerable<Group> GetAllGroups() 
        {
            return this.groupRepository.All();
        }

        /// <summary>
        /// Gets the group that matches the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// The group that matches the given identifier.
        /// </returns>
        public Group GetGroup(int id)
        {
            return this.groupRepository.Single(a => a.Id == id);
        }

        /// <summary>
        /// Creates the specified group.
        /// </summary>
        /// <param name="group">The group.</param>
        /// <returns>The created group (with id, creation and update date and creation and update login set).</returns>
        public Group CreateGroup(Group group)
        {
            group.CreationDate = DateTime.Now;
            group.CreationLogin = Thread.CurrentPrincipal.Identity.Name;
            group.UpdateDate = DateTime.Now;
            group.UpdateLogin = Thread.CurrentPrincipal.Identity.Name;
            this.groupRepository.Add(group);
            this.groupRepository.Context.SaveChanges();

            return group;
        }

        /// <summary>
        /// Updates the specified group.
        /// </summary>
        /// <param name="group">The group.</param>
        /// <returns>The updated group (with update date and update login set).</returns>
        public Group UpdateGroup(Group group)
        {
            group.UpdateDate = DateTime.Now;
            group.UpdateLogin = Thread.CurrentPrincipal.Identity.Name;

            this.groupRepository.Update(group);
            this.groupRepository.Context.SaveChanges();

            return group;
        }

        /// <summary>
        /// Deletes group that matches the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void DeleteGroup(int id)
        {
            var group = this.groupRepository.Single(a => a.Id == id);
            this.groupRepository.Delete(group);
            this.groupRepository.Context.SaveChanges();
        }

        #endregion < Methods >
    }
}
