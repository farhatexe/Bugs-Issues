namespace ProjectTasks.Data.EF
{
    using ProjectTasks.Business.Domain.Entities;
    using System;
    using System.Data.Entity;
    using System.Threading;

    /// <summary>
    /// Initializer that is called each the application is launched. 
    /// Model is dropped and created each time the application is launched.
    /// </summary>
    public class ApplicationDataContextInitializer : DropCreateDatabaseAlways<ApplicationDataContext>
    {
        #region < Methods >

        /// <summary>
        /// Runs after upgrading to the latest migration to allow seed data to be updated.
        /// </summary>
        /// <param name="context">Context to be used for updating seed data.</param>
        protected override void Seed(ApplicationDataContext context)
        {
            context.Areas.Add(new Area() { Label = "Area", CreationDate = DateTime.Now, UpdateDate = DateTime.Now, CreationLogin = "M3gur0", UpdateLogin = "M3gur0" });
            context.Groups.Add(new Group() { Label = "Admin", CreationDate = DateTime.Now, UpdateDate = DateTime.Now, CreationLogin = "M3gur0", UpdateLogin = "M3gur0" });
            context.Reasons.Add(new Reason() { Label = "New" });
            context.Runs.Add(new Run() { Title = "Run #0" });
            context.Status.Add(new Status() { Code = "OP", Label = "Open" });
            context.Tags.Add(new Tag() { Label = "Training" });

            context.SaveChanges();
        }

        #endregion < Methods >
    }
}