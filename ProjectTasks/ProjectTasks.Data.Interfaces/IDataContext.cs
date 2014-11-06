namespace ProjectTasks.Data.Interfaces
{
    using ProjectTasks.Business.Domain.Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    /// <summary>
    /// Generic data context to manage entities.
    /// </summary>
    public interface IDataContext : IDisposable
    {
        #region < Properties >

        /// <summary>
        /// Gets or Sets the command timeout.
        /// </summary>
        int? CommandTimeout { get; set; }

        #endregion < Properties >

        #region < Methods >

        /// <summary>
        /// Define set of entities.
        /// </summary>
        /// <typeparam name="TEntity">Type of the entity.</typeparam>
        /// <param name="includes">Entities expressions to join for the query.</param>
        /// <returns>A query.</returns>
        IQueryable<TEntity> Set<TEntity>(IEnumerable<Expression<Func<TEntity, object>>> includes) where TEntity : class, IEntity;

        /// <summary>
        /// Attach an entity to DataContext.
        /// </summary>
        /// <param name="item">Entity to attach.</param>
        /// <param name="validateEntity">Indicates if entity must be validated before attach. Entity will not be attached if validation failed.</param>
        void Attach(IEntity item, bool validateEntity = true);

        /// <summary>
        /// Attach a list of entities to DataContext.
        /// </summary>
        /// <param name="items">Entities to attach.</param>
        /// <param name="validateEntity">Indicates if entities must be validated before attach. Entity will not be attached if validation failed.</param>
        void Attach(IEnumerable<IEntity> items, bool validateEntity = true);

        /// <summary>
        /// Save changes in DataContext.
        /// </summary>
        /// <returns>Number of entities updated.</returns>
        int SaveChanges();

        /// <summary>
        /// Cancel changes in DataContext.
        /// </summary>
        void CancelChanges();

        /// <summary>
        /// Add an entity to DataContext.
        /// </summary>
        /// <param name="item">Entity to add.</param>
        void Add(IEntity item);

        /// <summary>
        /// Remove an entity from DataContext.
        /// </summary>
        /// <param name="item">Entity to remove.</param>
        void Remove(IEntity item);

        /// <summary>
        /// Mark an entity of the DataContext as modified.
        /// </summary>
        /// <param name="item">Entity to mark.</param>
        void MarkAsModified(IEntity item);

        #endregion < Methods >
    }
}
