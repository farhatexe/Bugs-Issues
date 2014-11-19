namespace ProjectTasks.Business.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class UserStory : Backlog, IEntity
    {
        #region < Properties >

        /// <summary>
        /// Gets or sets the tasks.
        /// </summary>
        /// <value>
        /// The tasks.
        /// </value>
        public virtual ICollection<Task> Tasks { get; set; }

        #endregion < Properties >
    }
}
