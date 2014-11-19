namespace ProjectTasks.Business.Domain.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Represents a task to do included in the project.
    /// </summary>
    public class Task : Backlog, IEntity
    {
        /// <summary>
        /// Gets or sets the sprint identifier.
        /// </summary>
        /// <value>
        /// The sprint identifier.
        /// </value>
        [Required]
        public int SprintId { get; set; }

        /// <summary>
        /// Gets or sets the effort (in hours).
        /// </summary>
        /// <value>
        /// The effort.
        /// </value>
        [Required]
        public int Effort { get; set; }

        /// <summary>
        /// Gets or sets the sprint.
        /// </summary>
        /// <value>
        /// The sprint.
        /// </value>
        [ForeignKey("SprintId")]
        public Sprint Sprint { get; set; }
    }
}
