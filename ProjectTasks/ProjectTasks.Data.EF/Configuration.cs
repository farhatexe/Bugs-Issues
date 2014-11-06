namespace ProjectTasks.Data.EF
{
    using System.Data.Entity.Migrations;

    /// <summary>
    /// Configuration class to handle Entity Framework code first configuration.
    /// </summary>
    public sealed class Configuration:  DbMigrationsConfiguration<DataContext>
    {
        #region < Constructors >

        /// <summary>
        /// Initializes a new instance of the <see cref="Configuration"/> class.
        /// </summary>
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        #endregion < Constructors >
    }
}
