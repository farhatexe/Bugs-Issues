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

        #region < Reason >

        /// <summary>
        /// Gets all reasons.
        /// </summary>
        /// <returns>The entire collection of available reasons.</returns>
        IEnumerable<Reason> GetAllReasons();

        /// <summary>
        /// Gets the reason that matches the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// The reason that matches the given identifier.
        /// </returns>
        Reason GetReason(int id);

        /// <summary>
        /// Creates the specified reason.
        /// </summary>
        /// <param name="area">The reason.</param>
        /// <returns>The created reason (with id, creation and update date and creation and update login set).</returns>
        Reason CreateReason(Reason reason);

        /// <summary>
        /// Updates the specified reason.
        /// </summary>
        /// <param name="area">The reason.</param>
        /// <returns>The updated reason (with update date and update login set).</returns>
        Reason UpdateReason(Reason reason);

        /// <summary>
        /// Deletes reason that matches the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        void DeleteReason(int id);

        #endregion < Reason >

        #region < Role >

        /// <summary>
        /// Gets all roles.
        /// </summary>
        /// <returns>The entire collection of available roles.</returns>
        IEnumerable<Role> GetAllRoles();

        /// <summary>
        /// Gets the role that matches the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// The role that matches the given identifier.
        /// </returns>
        Role GetRole(int id);

        /// <summary>
        /// Creates the specified role.
        /// </summary>
        /// <param name="role">The role.</param>
        /// <returns>The created role (with id, creation and update date and creation and update login set).</returns>
        Role CreateRole(Role role);

        /// <summary>
        /// Updates the specified role.
        /// </summary>
        /// <param name="role">The role.</param>
        /// <returns>The updated role (with update date and update login set).</returns>
        Role UpdateRole(Role role);

        /// <summary>
        /// Deletes role that matches the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        void DeleteRole(int id);

        #endregion < Role >

        #region < Status >

        /// <summary>
        /// Gets all statuses.
        /// </summary>
        /// <returns>The entire collection of available statuses.</returns>
        IEnumerable<Status> GetAllStatus();

        /// <summary>
        /// Gets the status that matches the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// The status that matches the given identifier.
        /// </returns>
        Status GetStatus(int id);

        /// <summary>
        /// Creates the specified status.
        /// </summary>
        /// <param name="area">The status.</param>
        /// <returns>The created status (with id, creation and update date and creation and update login set).</returns>
        Status CreateStatus(Status status);

        /// <summary>
        /// Updates the specified status.
        /// </summary>
        /// <param name="area">The status.</param>
        /// <returns>The updated status (with update date and update login set).</returns>
        Status UpdateStatus(Status status);

        /// <summary>
        /// Deletes status that matches the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        void DeleteStatus(int id);

        #endregion < Status >

        #region < Tag >

        /// <summary>
        /// Gets all tags.
        /// </summary>
        /// <returns>The entire collection of available tags.</returns>
        IEnumerable<Tag> GetAllTags();

        /// <summary>
        /// Gets the tag that matches the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// The tag that matches the given identifier.
        /// </returns>
        Tag GetTag(int id);

        /// <summary>
        /// Creates the specified tag.
        /// </summary>
        /// <param name="tag">The tag.</param>
        /// <returns>The created tag (with id, creation and update date and creation and update login set).</returns>
        Tag CreateTag(Tag tag);

        /// <summary>
        /// Updates the specified tag.
        /// </summary>
        /// <param name="tag">The tag.</param>
        /// <returns>The updated tag (with update date and update login set).</returns>
        Tag UpdateTag(Tag tag);

        /// <summary>
        /// Deletes tag that matches the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        void DeleteTag(int id);

        #endregion < Tag >

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
