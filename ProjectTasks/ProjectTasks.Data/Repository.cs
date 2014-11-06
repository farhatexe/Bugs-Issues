namespace ProjectTasks.Data
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using ProjectTasks.Data.Interfaces;
    using ProjectTasks.Business.Domain.Entities;

    /// <summary>
    /// Generic repository for entities.
    /// </summary>
    /// <typeparam name="TEntity">Type of entity.</typeparam>
    /// <typeparam name="TDataContext">Type of DataContext.</typeparam>
    internal class Repository<TEntity, TDataContext> : IRepository<TEntity, TDataContext>
        where TEntity : class, IEntity
        where TDataContext : class, IDataContext
    {
        #region < Constructors >

        /// <summary>
        /// Initializes a new instance of the Repository class.
        /// </summary>
        /// <param name="dataContext">Data context for the repository.</param>
        public Repository(TDataContext dataContext)
        {
            this.Context = dataContext;
        }

        #endregion < Constructors >

        #region < Properties >

        /// <summary>
        /// Gets data context for the repository.
        /// </summary>
        public IDataContext Context { get; private set; }

        #endregion < Properties >

        #region < Methods >

        #region < Select >

        /// <summary>
        /// Gets all entities.
        /// </summary>
        /// <param name="includes">Entities to joins to the entity.</param>
        /// <returns>Query to return entities.</returns>
        public IQueryable<TEntity> All(params Expression<Func<TEntity, object>>[] includes)
        {
            return this.Context.Set<TEntity>(includes);
        }
        
        /// <summary>
        /// Get one entity by his key.
        /// </summary>
        /// <param name="keyFilter">Expression to filter by key.</param>
        /// <param name="includes">Entities to joins to the entity.</param>
        /// <returns>Entity if found.</returns>
        /// <exception cref="System.ArgumentNullException">Source or predicate is null.</exception>
        /// <exception cref="System.InvalidOperationException">More than one element satisfies the condition in predicate.</exception>
        public TEntity Single(Expression<Func<TEntity, bool>> keyFilter, params Expression<Func<TEntity, object>>[] includes)
        {
            return this.All(includes).Single(keyFilter);
        }

        /// <summary>
        /// Get one entity by his key or default value (default(TEntity)).
        /// </summary>
        /// <param name="keyFilter">Expression to filter by key.</param>
        /// <param name="includes">Entities to joins to the entity.</param>
        /// <returns>Entity if found and null instead.</returns>
        /// <exception cref="System.ArgumentNullException">Source or predicate is null.</exception>
        /// <exception cref="System.InvalidOperationException">More than one element satisfies the condition in predicate.</exception>
        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> keyFilter, params Expression<Func<TEntity, object>>[] includes)
        {
            return this.All(includes).SingleOrDefault(keyFilter);
        }

        /// <summary>
        /// Select entities with where clause and includes.
        /// </summary>
        /// <param name="predicate">Filter expression.</param>
        /// <param name="includes">Entities to joins to the entity.</param>
        /// <returns>Query to return entities.</returns>
        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes)
        {
            return this.All(includes).Where(predicate);
        }

        #endregion < Select >

        #region < Add - Update - Delete >

        /// <summary>
        /// Add an entity.
        /// </summary>
        /// <param name="entity">Entity to add.</param>
        public void Add(TEntity entity)
        {
            this.Context.Add(entity);
        }

        /// <summary>
        /// Update an entity.
        /// </summary>
        /// <param name="entity">Entity to update.</param>
        public void Update(TEntity entity)
        {
            this.Context.MarkAsModified(entity);
        }

        /// <summary>
        /// Delete an entity.
        /// </summary>
        /// <param name="entity">Entity to delete.</param>
        public void Delete(TEntity entity)
        {
            this.Context.Remove(entity);
        }

        #endregion < Add - Update - Delete >

        #endregion < Methods >
    }
}
