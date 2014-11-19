namespace ProjectTasks.Data.EF
{
    using ProjectTasks.Business.Domain.Entities;
    using ProjectTasks.Data.Interfaces;
    using System.Data.Entity;
    
    /// <summary>
    /// DataContext for the whole application.
    /// </summary>
    public class ApplicationDataContext : DataContext, IDataContext
    {
        #region < Constructors >

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationDataContext"/> class.
        /// </summary>
        public ApplicationDataContext() : base("Tasks")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.AutoDetectChangesEnabled = true;
        }
        
        #endregion < Constructors >

        #region < Properties >

        /// <summary>
        /// Gets or sets the areas.
        /// </summary>
        /// <value>
        /// The areas.
        /// </value>
        public DbSet<Area> Areas { get; set; }

        /// <summary>
        /// Gets or sets the groups.
        /// </summary>
        /// <value>
        /// The groups.
        /// </value>
        public DbSet<Group> Groups { get; set; }

        /// <summary>
        /// Gets or sets the group roles.
        /// </summary>
        /// <value>
        /// The group roles.
        /// </value>
        public DbSet<GroupRole> GroupRoles { get; set; }

        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        /// <value>
        /// The items.
        /// </value>
        public DbSet<Backlog> Items { get; set; }

        /// <summary>
        /// Gets or sets the item tags.
        /// </summary>
        /// <value>
        /// The item tags.
        /// </value>
        public DbSet<BacklogTag> ItemTags { get; set; }

        /// <summary>
        /// Gets or sets the reasons.
        /// </summary>
        /// <value>
        /// The reasons.
        /// </value>
        public DbSet<Reason> Reasons { get; set; }

        /// <summary>
        /// Gets or sets the roles.
        /// </summary>
        /// <value>
        /// The roles.
        /// </value>
        public DbSet<Role> Roles { get; set; }

        /// <summary>
        /// Gets or sets the runs.
        /// </summary>
        /// <value>
        /// The runs.
        /// </value>
        public DbSet<Sprint> Runs { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        public DbSet<Status> Status { get; set; }

        /// <summary>
        /// Gets or sets the tags.
        /// </summary>
        /// <value>
        /// The tags.
        /// </value>
        public DbSet<Tag> Tags { get; set; }

        /// <summary>
        /// Gets or sets the tasks.
        /// </summary>
        /// <value>
        /// The tasks.
        /// </value>
        public DbSet<Task> Tasks { get; set; }

        /// <summary>
        /// Gets or sets the users.
        /// </summary>
        /// <value>
        /// The users.
        /// </value>
        public DbSet<User> Users { get; set; }

        #endregion < Properties >
    }
}
