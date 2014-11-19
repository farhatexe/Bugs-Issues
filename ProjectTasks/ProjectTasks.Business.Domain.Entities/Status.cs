namespace ProjectTasks.Business.Domain.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Threading;

    /// <summary>
    /// Represents a status of an item (e.g. New, Closed, Assigned, working, pending, etc.).
    /// </summary>
    public class Status : IEntity
    {
        #region < Properties >

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the label.
        /// </summary>
        /// <value>
        /// The label.
        /// </value>
        [Required, StringLength(64)]
        public string Label { get; set; }

        /// <summary>
        /// Gets or sets the creation date.
        /// </summary>
        /// <value>
        /// The creation date.
        /// </value>
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// Gets or sets the creation login.
        /// </summary>
        /// <value>
        /// The creation login.
        /// </value>
        [StringLength(64)]
        public string CreationLogin { get; set; }

        /// <summary>
        /// Gets or sets the update date.
        /// </summary>
        /// <value>
        /// The update date.
        /// </value>
        public DateTime UpdateDate { get; set; }

        /// <summary>
        /// Gets or sets the update login.
        /// </summary>
        /// <value>
        /// The update login.
        /// </value>
        [StringLength(64)]
        public string UpdateLogin { get; set; }

        #endregion < Properties >

        #region < Constructors >

        /// <summary>
        /// Initializes a new instance of the <see cref="Status"/> class.
        /// </summary>
        public Status()
        {
            this.CreationDate = DateTime.Now;
            this.CreationLogin = Thread.CurrentPrincipal.Identity.Name;

            this.UpdateDate = DateTime.Now;
            this.UpdateLogin = Thread.CurrentPrincipal.Identity.Name;
        }
    
        #endregion < Constructors >
    }
}
