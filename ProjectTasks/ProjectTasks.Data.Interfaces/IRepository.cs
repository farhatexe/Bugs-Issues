namespace ProjectTasks.Data.Interfaces
{
    using ProjectTasks.Business.Domain.Entities;
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    /// <summary>
    /// Interface for generic repository for entities.
    /// </summary>
    /// <typeparam name="TEntity">Type of entity.</typeparam>
    /// <typeparam name="TDataContext">Type of DataContext.</typeparam>
    public interface IRepository<TEntity, TDataContext> 
        where TEntity : class, IEntity 
        where TDataContext : class, IDataContext
    {
        #region < Properties >

        /// <summary>
        /// Gets data context for the repository.
        /// </summary>
        /// <value>The context.</value>
        IDataContext Context { get; }

        #endregion < Properties >

        #region < Methods >

        /// <summary>
        /// Gets all entities.
        /// </summary>
        /// <param name="includes">Entities to joins to the entity.</param>
        /// <returns>Query to return entities.</returns>
        IQueryable<TEntity> All(params Expression<Func<TEntity, object>>[] includes);

        /// <summary>
        /// Get one entity.
        /// </summary>
        /// <param name="predicate">Expression to filter.</param>
        /// <param name="includes">Entities to joins to the entity.</param>
        /// <returns>Entity if found and null instead.</returns>
        /// <exception cref="System.ArgumentNullException">Source or predicate is null.</exception>
        /// <exception cref="System.InvalidOperationException">More than one element satisfies the condition in predicate.</exception>
        TEntity Single(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes);

        /// <summary>
        /// Select entities with where clause and includes.
        /// </summary>
        /// <param name="predicate">Filter expression.</param>
        /// <param name="includes">Entities to joins to the entity.</param>
        /// <returns>Query to return entities.</returns>
        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes);

        /// <summary>
        /// Add an entity.
        /// </summary>
        /// <param name="entity">Entity to add.</param>
        void Add(TEntity entity);

        /// <summary>
        /// Update an entity.
        /// </summary>
        /// <param name="entity">Entity to update.</param>
        void Update(TEntity entity);

        /// <summary>
        /// Delete an entity.
        /// </summary>
        /// <param name="entity">Entity to delete.</param>
        void Delete(TEntity entity);

        #endregion < Methods >

    }
}
