namespace ProjectTasks.Business.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Threading;
    using System.Linq;
    using Newtonsoft.Json;

    /// <summary>
    /// Represents an area to split the project in few functional / technical parts.
    /// </summary>
    public class Area : IEntity
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

        /// <summary>
        /// Gets or sets the parent.
        /// </summary>
        /// <value>
        /// The parent.
        /// </value>
        [ForeignKey("ParentId"), JsonIgnore]
        public Area Parent { get; set; }

        /// <summary>
        /// Gets or sets the children.
        /// </summary>
        /// <value>
        /// The children.
        /// </value>
        [JsonIgnore]
        public ICollection<Area> Children { get; set; }

        /// <summary>
        /// Gets the sorted children items.
        /// </summary>
        public IEnumerable<Area> SortedChildren
        {
            get
            {
                if (this.Children == null) 
                    return Enumerable.Empty<Area>();
                
                return this.Children.OrderBy(c => c.Label);
            }
        }

        /// <summary>
        /// Gets the parent label.
        /// </summary>
        [NotMapped]
        public string ParentLabel
        {
            get
            {
                return this.Parent != null ? this.Parent.Label : string.Empty;
            }
        }

        #endregion < Properties >

        #region < Constructors >

        /// <summary>
        /// Initializes a new instance of the <see cref="Area"/> class.
        /// </summary>
        public Area()
        {
            this.CreationDate = DateTime.Now;
            this.CreationLogin = Thread.CurrentPrincipal.Identity.Name;

            this.UpdateDate = DateTime.Now;
            this.UpdateLogin = Thread.CurrentPrincipal.Identity.Name;
        }

        #endregion < Constructors >
    }
}
