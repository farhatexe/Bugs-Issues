namespace ProjectTasks.Business.Services
{
    using ProjectTasks.Business.Domain.Entities;
    using ProjectTasks.Data.Interfaces;
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Threading;

    /// <summary>
    /// Provides an implementation for IServices interface related to reason.
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
        private IRepository<Reason, IDataContext> reasonRepository
        {
            get
            {
                return this.unitOfWork.GetRepository<Reason>();
            }
        }

        #endregion < Properties >

        #region < Methods >

        /// <summary>
        /// Gets all reason.
        /// </summary>
        /// <returns>The entire collection of available reason.</returns>
        public IEnumerable<Reason> GetAllReasons() 
        {
            return this.reasonRepository.All();
        }

        /// <summary>
        /// Gets the reason that matches the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// The reason that matches the given identifier.
        /// </returns>
        public Reason GetReason(int id)
        {
            return this.reasonRepository.Single(a => a.Id == id);
        }

        /// <summary>
        /// Creates the specified reason.
        /// </summary>
        /// <param name="reason">The reason.</param>
        /// <returns>The created reason (with id, creation and update date and creation and update login set).</returns>
        public Reason CreateReason(Reason reason)
        {
            reason.CreationDate = DateTime.Now;
            reason.CreationLogin = Thread.CurrentPrincipal.Identity.Name;
            reason.UpdateDate = DateTime.Now;
            reason.UpdateLogin = Thread.CurrentPrincipal.Identity.Name;
            this.reasonRepository.Add(reason);
            this.reasonRepository.Context.SaveChanges();

            return reason;
        }

        /// <summary>
        /// Updates the specified reason.
        /// </summary>
        /// <param name="reason">The reason.</param>
        /// <returns>The updated reason (with update date and update login set).</returns>
        public Reason UpdateReason(Reason reason)
        {
            reason.UpdateDate = DateTime.Now;
            reason.UpdateLogin = Thread.CurrentPrincipal.Identity.Name;

            this.reasonRepository.Update(reason);
            this.reasonRepository.Context.SaveChanges();

            return reason;
        }

        /// <summary>
        /// Deletes reason that matches the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void DeleteReason(int id)
        {
            var reason = this.reasonRepository.Single(a => a.Id == id);
            this.reasonRepository.Delete(reason);
            this.reasonRepository.Context.SaveChanges();
        }

        #endregion < Methods >
    }
}
