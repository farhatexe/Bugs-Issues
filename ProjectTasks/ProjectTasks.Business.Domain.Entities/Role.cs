namespace ProjectTasks.Business.Domain.Entities
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Represents a role that contains right for the application.
    /// </summary>
    public class Role: IEntity
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
