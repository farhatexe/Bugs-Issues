namespace ProjectTasks.Business.Services
{
    using ProjectTasks.Business.Domain.Entities;
    using ProjectTasks.Data.Interfaces;
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Threading;

    /// <summary>
    /// Provides an implementation for IServices interface related to status.
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
        private IRepository<Status, IDataContext> statusRepository
        {
            get
            {
                return this.unitOfWork.GetRepository<Status>();
            }
        }

        #endregion < Properties >

        #region < Methods >

        /// <summary>
        /// Gets all status.
        /// </summary>
        /// <returns>The entire collection of available status.</returns>
        public IEnumerable<Status> GetAllStatus() 
        {
            return this.statusRepository.All();
        }

        /// <summary>
        /// Gets the status that matches the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// The status that matches the given identifier.
        /// </returns>
        public Status GetStatus(int id)
        {
            return this.statusRepository.Single(a => a.Id == id);
        }

        /// <summary>
        /// Creates the specified status.
        /// </summary>
        /// <param name="status">The status.</param>
        /// <returns>The created status (with id, creation and update date and creation and update login set).</returns>
        public Status CreateStatus(Status status)
        {
            status.CreationDate = DateTime.Now;
            status.CreationLogin = Thread.CurrentPrincipal.Identity.Name;
            status.UpdateDate = DateTime.Now;
            status.UpdateLogin = Thread.CurrentPrincipal.Identity.Name;
            this.statusRepository.Add(status);
            this.statusRepository.Context.SaveChanges();

            return status;
        }

        /// <summary>
        /// Updates the specified status.
        /// </summary>
        /// <param name="status">The status.</param>
        /// <returns>The updated status (with update date and update login set).</returns>
        public Status UpdateStatus(Status status)
        {
            status.UpdateDate = DateTime.Now;
            status.UpdateLogin = Thread.CurrentPrincipal.Identity.Name;

            this.statusRepository.Update(status);
            this.statusRepository.Context.SaveChanges();

            return status;
        }

        /// <summary>
        /// Deletes status that matches the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void DeleteStatus(int id)
        {
            var status = this.statusRepository.Single(a => a.Id == id);
            this.statusRepository.Delete(status);
            this.statusRepository.Context.SaveChanges();
        }

        #endregion < Methods >
    }
}
