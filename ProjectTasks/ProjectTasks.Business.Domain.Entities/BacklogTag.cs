namespace ProjectTasks.Business.Domain.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Represents a many to many relation between tag and a backlog item.
    /// </summary>
    public class BacklogTag : IEntity
    {

        /// <summary>
        /// Gets or sets the backlog identifier.
        /// </summary>
        /// <value>
        /// The backlog identifier.
        /// </value>
        [Key, Column(Order = 0)]
        public int BacklogId { get; set; }

        /// <summary>
        /// Gets or sets the tag identifier.
        /// </summary>
        /// <value>
        /// The tag identifier.
        /// </value>
        [Key, Column(Order = 1)]
        public int TagId { get; set; }

        /// <summary>
        /// Gets or sets the backlog.
        /// </summary>
        /// <value>
        /// The backlog.
        /// </value>
        [ForeignKey("BacklogId")]
        public Backlog Backlog { get; set; }

        /// <summary>
        /// Gets or sets the tag.
        /// </summary>
        /// <value>
        /// The tag.
        /// </value>
        [ForeignKey("TagId")]
        public Tag Tag { get; set; }
    }
}
