namespace ProjectTasks.Business.Domain.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Represents a bug discovered in the project.
    /// </summary>
    public class Bug : Backlog, IEntity
    {
        /// <summary>
        /// Gets or sets the reason identifier.
        /// </summary>
        /// <value>
        /// The reason identifier.
        /// </value>
        [Required]
        public int ReasonId { get; set; }

        /// <summary>
        /// Gets or sets the task identifier.
        /// </summary>
        /// <value>
        /// The task identifier.
        /// </value>
        [Required]
        public int TaskId { get; set; }

        /// <summary>
        /// Gets or sets the acceptance criteria.
        /// </summary>
        /// <value>
        /// The acceptance criteria.
        /// </value>
        public string AcceptanceCriteria { get; set; }

        /// <summary>
        /// Gets or sets the reason.
        /// </summary>
        /// <value>
        /// The reason.
        /// </value>
        [ForeignKey("ReasonId")]
        public virtual Reason Reason { get; set; }

        /// <summary>
        /// Gets or sets the task.
        /// </summary>
        /// <value>
        /// The task.
        /// </value>
        [ForeignKey("TaskId")]
        public virtual Task Task { get; set; }
    }
}
