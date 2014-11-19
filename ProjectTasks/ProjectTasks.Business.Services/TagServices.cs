namespace ProjectTasks.Business.Services
{
    using ProjectTasks.Business.Domain.Entities;
    using ProjectTasks.Data.Interfaces;
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Threading;

    /// <summary>
    /// Provides an implementation for IServices interface related to tags.
    /// </summary>
    public partial class Services
    {
        #region < Properties >

        /// <summary>
        /// Gets the tag repository.
        /// </summary>
        /// <value>
        /// The tag repository.
        /// </value>
        private IRepository<Tag, IDataContext> tagRepository
        {
            get
            {
                return this.unitOfWork.GetRepository<Tag>();
            }
        }

        #endregion < Properties >

        #region < Methods >

        /// <summary>
        /// Gets all tags.
        /// </summary>
        /// <returns>The entire collection of available tags.</returns>
        public IEnumerable<Tag> GetAllTags() 
        {
            return this.tagRepository.All();
        }

        /// <summary>
        /// Gets the tag that matches the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// The tag that matches the given identifier.
        /// </returns>
        public Tag GetTag(int id)
        {
            return this.tagRepository.Single(a => a.Id == id);
        }

        /// <summary>
        /// Creates the specified tag.
        /// </summary>
        /// <param name="tag">The tag.</param>
        /// <returns>The created tag (with id, creation and update date and creation and update login set).</returns>
        public Tag CreateTag(Tag tag)
        {
            tag.CreationDate = DateTime.Now;
            tag.CreationLogin = Thread.CurrentPrincipal.Identity.Name;
            tag.UpdateDate = DateTime.Now;
            tag.UpdateLogin = Thread.CurrentPrincipal.Identity.Name;
            this.tagRepository.Add(tag);
            this.tagRepository.Context.SaveChanges();

            return tag;
        }

        /// <summary>
        /// Updates the specified tag.
        /// </summary>
        /// <param name="tag">The tag.</param>
        /// <returns>The updated tag (with update date and update login set).</returns>
        public Tag UpdateTag(Tag tag)
        {
            tag.UpdateDate = DateTime.Now;
            tag.UpdateLogin = Thread.CurrentPrincipal.Identity.Name;

            this.tagRepository.Update(tag);
            this.tagRepository.Context.SaveChanges();

            return tag;
        }

        /// <summary>
        /// Deletes tag that matches the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void DeleteTag(int id)
        {
            var tag = this.tagRepository.Single(a => a.Id == id);
            this.tagRepository.Delete(tag);
            this.tagRepository.Context.SaveChanges();
        }

        #endregion < Methods >
    }
}
