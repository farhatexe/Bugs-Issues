namespace ProjectTasks.Business.Services
{
    using ProjectTasks.Business.Domain.Entities;
    using ProjectTasks.Data.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
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
        private IRepository<User, IDataContext> userRepository
        {
            get
            {
                return this.unitOfWork.GetRepository<User>();
            }
        }

        #endregion < Properties >

        #region < Methods >

        /// <summary>
        /// Gets all users.
        /// </summary>
        /// <returns>The entire collection of available users.</returns>
        public IEnumerable<User> GetAllUsers() 
        {
            return this.userRepository.All(u => u.Group);
        }

        /// <summary>
        /// Gets the user that matches the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// The user that matches the given identifier.
        /// </returns>
        public User GetUser(int id)
        {
            return this.userRepository.Single(a => a.Id == id, u => u.Group);
        }

        /// <summary>
        /// Creates the specified group.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>The created user (with id, creation and update date and creation and update login set).</returns>
        public User CreateUser(User user)
        {
            user.CreationDate = DateTime.Now;
            user.CreationLogin = Thread.CurrentPrincipal.Identity.Name;
            user.UpdateDate = DateTime.Now;
            user.UpdateLogin = Thread.CurrentPrincipal.Identity.Name;
            this.userRepository.Add(user);
            this.groupRepository.Context.SaveChanges();

            return user;
        }

        /// <summary>
        /// Updates the specified user.
        /// </summary>
        /// <param name="area">The user.</param>
        /// <returns>The updated user (with update date and update login set).</returns>
        public User UpdateUser(User user)
        {
            user.UpdateDate = DateTime.Now;
            user.UpdateLogin = Thread.CurrentPrincipal.Identity.Name;

            this.userRepository.Update(user);
            this.userRepository.Context.SaveChanges();

            return user;
        }

        /// <summary>
        /// Deletes user that matches the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void DeleteUser(int id)
        {
            var user = this.userRepository.Single(a => a.Id == id);
            this.userRepository.Delete(user);
            this.userRepository.Context.SaveChanges();
        }

        #endregion < Methods >
    }
}
