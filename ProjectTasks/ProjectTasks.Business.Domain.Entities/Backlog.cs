namespace ProjectTasks.Business.Domain.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Threading;

    /// <summary>
    /// Represents an item 
    /// </summary>
    public abstract class Backlog : IEntity
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
        /// Gets or sets the status identifier.
        /// </summary>
        /// <value>
        /// The status identifier.
        /// </value>
        [Required]
        public int StatusId { get; set; }

        /// <summary>
        /// Gets or sets the complexity.
        /// </summary>
        /// <value>
        /// The complexity.
        /// </value>
        public int Complexity { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public int? UserId { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        [Required, StringLength(64)]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the assign to.
        /// </summary>
        /// <value>
        /// The assign to.
        /// </value>
        [ForeignKey("UserId")]
        public User AssignTo { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        [ForeignKey("StatusId")]
        public Status Status { get; set; }

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
        /// Initializes a new instance of the <see cref="Backlog"/> class.
        /// </summary>
        public Backlog()
        {
            this.CreationDate = DateTime.Now;
            this.CreationLogin = Thread.CurrentPrincipal.Identity.Name;

            this.UpdateDate = DateTime.Now;
            this.UpdateLogin = Thread.CurrentPrincipal.Identity.Name;
        }

        #endregion < Contructors >
    }
}
