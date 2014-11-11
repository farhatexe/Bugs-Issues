namespace ProjectTasks.Business.Services
{
    using ProjectTasks.Business.Domain.Entities;
    using ProjectTasks.Data.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Threading;

    /// <summary>
    /// Provides an implementation for IServices interface related to areas.
    /// </summary>
    public partial class Services
    {
        #region < Properties >

        /// <summary>
        /// Gets the area repository.
        /// </summary>
        /// <value>
        /// The area repository.
        /// </value>
        private IRepository<Area, IDataContext> areaRepository
        {
            get
            {
                return this.unitOfWork.GetRepository<Area>();
            }
        }

        #endregion < Properties >

        #region < Methods >

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>The entire collection of available areas</returns>
        public IEnumerable<Area> GetAllAreas()
        {
            return this.areaRepository.All();
        }

        /// <summary>
        /// Gets the area that matches the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The area that matches the given identifier.</returns>
        public Area GetArea(int id)
        {
            return this.areaRepository.Single(a => a.Id == id);
        }

        /// <summary>
        /// Creates the specified area.
        /// </summary>
        /// <param name="area">The area.</param>
        /// <returns>The created area (with id, creation and update date and creation and update login set).</returns>
        public Area CreateArea(Area area)
        {
            area.CreationDate = DateTime.Now;
            area.CreationLogin = Thread.CurrentPrincipal.Identity.Name;
            area.UpdateDate = DateTime.Now;
            area.UpdateLogin = Thread.CurrentPrincipal.Identity.Name;
            this.areaRepository.Add(area);
            this.areaRepository.Context.SaveChanges();

            return area;
        }

        /// <summary>
        /// Updates the specified area.
        /// </summary>
        /// <param name="area">The area.</param>
        /// <returns>The updated area (with update date and update login set).</returns>
        public Area UpdateArea(Area area)
        {
            area.UpdateDate = DateTime.Now;
            area.UpdateLogin = Thread.CurrentPrincipal.Identity.Name;

            this.areaRepository.Update(area);
            this.areaRepository.Context.SaveChanges();

            return area;
        }

        /// <summary>
        /// Deletes area that matches the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void DeleteArea(int id)
        {
            var area = this.areaRepository.Single(a => a.Id == id);
            this.areaRepository.Delete(area);
            this.areaRepository.Context.SaveChanges();
        }

        #endregion < Methods >
    }
}
