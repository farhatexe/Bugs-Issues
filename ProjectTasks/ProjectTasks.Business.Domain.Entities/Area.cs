namespace ProjectTasks.Business.Domain.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Represents an area to split the project in few functional / technical parts.
    /// </summary>
    public class Area : IEntity
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the parent identifier.
        /// </summary>
        /// <value>
        /// The parent identifier.
        /// </value>
        public int? ParentId { get; set; }

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
        [Required]
        public DateTime CreationDate{ get; set; }

        /// <summary>
        /// Gets or sets the creation login.
        /// </summary>
        /// <value>
        /// The creation login.
        /// </value>
        [Required, StringLength(64)]
        public string CreationLogin { get; set; }

        /// <summary>
        /// Gets or sets the update date.
        /// </summary>
        /// <value>
        /// The update date.
        /// </value>
        [Required]
        public DateTime UpdateDate { get; set; }

        /// <summary>
        /// Gets or sets the update login.
        /// </summary>
        /// <value>
        /// The update login.
        /// </value>
        [Required, StringLength(64)]
        public string UpdateLogin { get; set; }

        /// <summary>
        /// Gets or sets the parent.
        /// </summary>
        /// <value>
        /// The parent.
        /// </value>
        [ForeignKey("ParentId")]
        public Area Parent { get; set; }
    }
}
