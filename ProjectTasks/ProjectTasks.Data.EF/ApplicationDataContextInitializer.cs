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
            var area = new Area()   { Label = "Area", CreationDate = DateTime.Now, UpdateDate = DateTime.Now, CreationLogin = "M3gur0", UpdateLogin = "M3gur0" };
            var area1 = new Area()  { Label = "Area 1", Parent = area, CreationDate = DateTime.Now, UpdateDate = DateTime.Now, CreationLogin = "M3gur0", UpdateLogin = "M3gur0" };
            var area2 = new Area()  { Label = "Area 2", Parent = area, CreationDate = DateTime.Now, UpdateDate = DateTime.Now, CreationLogin = "M3gur0", UpdateLogin = "M3gur0" };
            var area12 = new Area() { Label = "Area 1.2", Parent = area1, CreationDate = DateTime.Now, UpdateDate = DateTime.Now, CreationLogin = "M3gur0", UpdateLogin = "M3gur0" };
            var area11 = new Area() { Label = "Area 1.1", Parent = area1, CreationDate = DateTime.Now, UpdateDate = DateTime.Now, CreationLogin = "M3gur0", UpdateLogin = "M3gur0" };

            context.Areas.Add(area);
            context.Areas.Add(area1);
            context.Areas.Add(area2);
            context.Areas.Add(area12);
            context.Areas.Add(area11);


            var group = new Group() { Label = "Admin", CreationDate = DateTime.Now, UpdateDate = DateTime.Now, CreationLogin = "M3gur0", UpdateLogin = "M3gur0" };
            context.Groups.Add(group);
            
            var user = new User(){ Username = "M3gur0", Email = "jerome.bolot@gmail.com", Group = group, CreationDate = DateTime.Now, UpdateDate = DateTime.Now, CreationLogin = "M3gur0", UpdateLogin = "M3gur0" };
            context.Users.Add(user);

            context.Reasons.Add(new Reason() { Label = "New" });
            context.Runs.Add(new Sprint() { Title = "Run #0" });
            context.Status.Add(new Status() { Label = "Open" });
            context.Tags.Add(new Tag() { Label = "Training" });

            context.SaveChanges();
        }

        #endregion < Methods >
    }
}