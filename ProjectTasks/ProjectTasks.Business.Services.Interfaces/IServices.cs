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
        /// Gets all.
        /// </summary>
        /// <returns>The entire collection of available areas</returns>
        IEnumerable<Area> GetAll();

        /// <summary>
        /// Gets the area that matches the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The area that matches the given identifier.</returns>
        Area Get(int id);

        /// <summary>
        /// Creates the specified area.
        /// </summary>
        /// <param name="area">The area.</param>
        /// <returns>The created area (with id, creation and update date and creation and update login set).</returns>
        Area Create(Area area);

        /// <summary>
        /// Updates the specified area.
        /// </summary>
        /// <param name="area">The area.</param>
        /// <returns>The updated area (with update date and update login set).</returns>
        Area Update(Area area);

        /// <summary>
        /// Deletes area that matches the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        void Delete(int id);

        #endregion < Area >
    }
}
