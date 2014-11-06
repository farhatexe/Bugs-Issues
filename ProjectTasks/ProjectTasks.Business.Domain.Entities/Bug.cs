namespace ProjectTasks.Business.Domain.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Represents a bug discovered in the project.
    /// </summary>
    public class Bug : Item, IEntity
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
        public Reason Reason { get; set; }

    }
}
