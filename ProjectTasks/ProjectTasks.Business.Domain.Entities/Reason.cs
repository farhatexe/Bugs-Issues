namespace ProjectTasks.Business.Domain.Entities
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Represents the reason linked to a bug.
    /// </summary>
    public class Reason : IEntity
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
        /// Gets or sets the label.
        /// </summary>
        /// <value>
        /// The label.
        /// </value>
        [Required, StringLength(64)]
        public string Label { get; set; }
    }
}
