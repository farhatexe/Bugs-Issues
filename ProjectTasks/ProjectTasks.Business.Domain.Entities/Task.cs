namespace ProjectTasks.Business.Domain.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Represents a task to do included in the project.
    /// </summary>
    public class Task : Item, IEntity
    {
        /// <summary>
        /// Gets or sets the run identifier.
        /// </summary>
        /// <value>
        /// The run identifier.
        /// </value>
        [Required]
        public int RunId { get; set; }

        /// <summary>
        /// Gets or sets the effort (in hours).
        /// </summary>
        /// <value>
        /// The effort.
        /// </value>
        [Required]
        public int Effort { get; set; }

        /// <summary>
        /// Gets or sets the run.
        /// </summary>
        /// <value>
        /// The run.
        /// </value>
        [ForeignKey("RunId")]
        public Run Run { get; set; }
    }
}
