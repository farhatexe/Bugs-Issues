namespace ProjectTasks.Business.Domain.Entities
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Threading;

    /// <summary>
    /// Represents a project user.
    /// </summary>
    public class User : IEntity
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
        /// Gets or sets the username.
        /// </summary>
        /// <value>
        /// The username.
        /// </value>
        [Required, StringLength(64)]
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        [Required, StringLength(254)]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        [StringLength(64), MinLength(8)]
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the group identifier.
        /// </summary>
        /// <value>
        /// The group identifier.
        /// </value>
        [Required]
        public int GroupId { get; set; }

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
        /// Gets or sets the group.
        /// </summary>
        /// <value>
        /// The group.
        /// </value>
        [ForeignKey("GroupId"), JsonIgnore]
        public virtual Group Group { get; set; }

        /// <summary>
        /// Gets the group label.
        /// </summary>
        /// <value>
        /// The group label.
        /// </value>
        [NotMapped]
        public string GroupLabel 
        { 
            get 
            {
                if (this.Group == null)
                    return string.Empty;
                    
                return this.Group.Label;
            } 
        }

        #endregion < Properties >

        #region < Constructors >

        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        public User()
        {
            this.CreationDate = DateTime.Now;
            this.CreationLogin = Thread.CurrentPrincipal.Identity.Name;

            this.UpdateDate = DateTime.Now;
            this.UpdateLogin = Thread.CurrentPrincipal.Identity.Name;
        }

        #endregion < Constructors >
    }
}
