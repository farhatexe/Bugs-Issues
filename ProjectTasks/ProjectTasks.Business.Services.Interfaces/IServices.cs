namespace ProjectTasks.Business.Services.Interfaces
{
    using ProjectTasks.Business.Domain.Entities;
    using System.Collections.Generic;

    /// <summary>
    /// Services for whole projects.
    /// </summary>
    public interface IServices
    {
        #region < Area >

        /// <summary>
        /// Gets all areas.
        /// </summary>
        /// <returns>
        /// The entire collection of available areas
        /// </returns>
        IEnumerable<Area> GetAllAreas();

        /// <summary>
        /// Gets the area that matches the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// The area that matches the given identifier.
        /// </returns>
        Area GetArea(int id);

        /// <summary>
        /// Creates the specified area.
        /// </summary>
        /// <param name="area">The area.</param>
        /// <returns>The created area (with id, creation and update date and creation and update login set).</returns>
        Area CreateArea(Area area);

        /// <summary>
        /// Updates the specified area.
        /// </summary>
        /// <param name="area">The area.</param>
        /// <returns>The updated area (with update date and update login set).</returns>
        Area UpdateArea(Area area);

        /// <summary>
        /// Deletes area that matches the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        void DeleteArea(int id);

        #endregion < Area >

        #region < Group >

        /// <summary>
        /// Gets all groups.
        /// </summary>
        /// <returns>The entire collection of available groups.</returns>
        IEnumerable<Group> GetAllGroups();

        /// <summary>
        /// Gets the group that matches the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// The group that matches the given identifier.
        /// </returns>
        Group GetGroup(int id);

        /// <summary>
        /// Creates the specified group.
        /// </summary>
        /// <param name="area">The group.</param>
        /// <returns>The created group (with id, creation and update date and creation and update login set).</returns>
        Group CreateGroup(Group group);

        /// <summary>
        /// Updates the specified group.
        /// </summary>
        /// <param name="area">The group.</param>
        /// <returns>The updated group (with update date and update login set).</returns>
        Group UpdateGroup(Group group);

        /// <summary>
        /// Deletes group that matches the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        void DeleteGroup(int id);

        #endregion < Group >

        #region < User >

        /// <summary>
        /// Gets all users.
        /// </summary>
        /// <returns>The entire collection of available users.</returns>
        IEnumerable<User> GetAllUsers();

        /// <summary>
        /// Gets the user that matches the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// The user that matches the given identifier.
        /// </returns>
        User GetUser(int id);

        /// <summary>
        /// Creates the specified user.
        /// </summary>
        /// <param name="area">The user.</param>
        /// <returns>The created user (with id, creation and update date and creation and update login set).</returns>
        User CreateUser(User user);

        /// <summary>
        /// Updates the specified user.
        /// </summary>
        /// <param name="area">The user.</param>
        /// <returns>The updated user (with update date and update login set).</returns>
        User UpdateUser(User user);

        /// <summary>
        /// Deletes user that matches the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        void DeleteUser(int id);

        #endregion < User >
    }
}
