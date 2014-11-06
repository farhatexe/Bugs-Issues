namespace ProjectTasks.Data.Interfaces
{
    using ProjectTasks.Business.Domain.Entities;

    /// <summary>
    /// Represents the unit of work interface.
    /// </summary>
    /// <typeparam name="TDataContext">Type of DataContext.</typeparam>
    public interface IUnitOfWork<TDataContext> where TDataContext : class, IDataContext
    {
        #region < Methods >

        /// <summary>
        /// Returns the repository of the specified type.
        /// </summary>
        /// <typeparam name="TEntity">Entity type.</typeparam>
        /// <returns>The repository.</returns>
        IRepository<TEntity, TDataContext> GetRepository<TEntity>() where TEntity : class, IEntity;

        /// <summary>
        /// Commit all changes.
        /// </summary>
        void Commit();

        /// <summary>
        /// Roll back all changes.
        /// </summary>
        void Rollback();

        #endregion < Methods >
    }
}