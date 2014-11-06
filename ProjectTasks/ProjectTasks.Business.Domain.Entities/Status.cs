namespace ProjectTasks.Business.Domain.Entities
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Represents a status of an item (e.g. New, Closed, Assigned, working, pending, etc.).
    /// </summary>
    public class Status : IEntity
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
        /// Gets or sets the code.
        /// </summary>
        /// <value>
        /// The code.
        /// </value>
        [Required, StringLength(16)]
        public string Code { get; set; }

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
