namespace ProjectTasks.Data.EF
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Core.Objects;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Linq.Expressions;
    using ProjectTasks.Data.Interfaces;
    using ProjectTasks.Business.Domain.Entities;

    /// <summary>
    /// Generic data context to manage entities.
    /// </summary>
    public class DataContext : DbContext, IDataContext
    {
        #region < Properties >

        private ObjectContext ObjectContext
        {
            get { return (this as IObjectContextAdapter).ObjectContext; }
        }

        /// <summary>
        /// Gets or Sets the command timeout.
        /// </summary>
        public int? CommandTimeout
        {
            get { return this.ObjectContext.CommandTimeout; }
            set { this.ObjectContext.CommandTimeout = value; }
        }

        #endregion < Properties >

        #region < Constructors >

        public DataContext(string dbName) : base(dbName) { }

        #endregion < Constructors >

        #region < Methods >

        /// <summary>
        /// Define set of entities.
        /// </summary>
        /// <typeparam name="TEntity">Type of the entity.</typeparam>
        /// <param name="includes">Entities expressions to join for the query.</param>
        /// <returns>A query.</returns>
        public IQueryable<TEntity> Set<TEntity>(IEnumerable<Expression<Func<TEntity, object>>> includes) where TEntity : class, IEntity
        {
            IQueryable<TEntity> query = this.Set<TEntity>();

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return query;
        }

        /// <summary>
        /// Attach an entity to DataContext.
        /// </summary>
        /// <param name="item">Entity to attach.</param>
        /// <param name="validateEntity">Indicates if entity must be validated before attach. Entity will not be attached if validation failed.</param>
        public void Attach(IEntity item, bool validateEntity = true)
        {
            if (item == null)
            {
                return;
            }

            DbEntityEntry entry = this.Entry(item);

            if (!this.Set(item.GetType()).Local.Contains(item) && (!validateEntity || this.ShouldValidateEntity(entry)))
            {
                this.Set(item.GetType()).Attach(item);
            }
        }

        /// <summary>
        /// Attach a list of entities to DataContext.
        /// </summary>
        /// <param name="items">Entities to attach.</param>
        /// <param name="validateEntity">Indicates if entities must be validated before attach. Entity will not be attached if validation failed.</param>
        public void Attach(IEnumerable<IEntity> items, bool validateEntity = true)
        {
            if (items == null)
            {
                return;
            }

            foreach (IEntity entity in items)
            {
                this.Attach(entity, validateEntity);
            }
        }

        /// <summary>
        /// Cancel changes in DataContext.
        /// </summary>
        public void CancelChanges()
        {
            foreach (DbEntityEntry entry in this.ChangeTracker.Entries().Where(entry => entry.State != EntityState.Unchanged))
            {
                entry.State = EntityState.Unchanged;
            }
        }

        /// <summary>
        /// Add an entity to DataContext.
        /// </summary>
        /// <param name="item">Entity to add.</param>
        public void Add(IEntity item)
        {
            this.Set(item.GetType()).Add(item);
        }

        /// <summary>
        /// Mark an entity of the DataContext as modified.
        /// </summary>
        /// <param name="item">Entity to mark.</param>
        public void MarkAsModified(IEntity item)
        {
            this.Entry(item).State = EntityState.Modified;
        }

        /// <summary>
        /// Remove an entity from DataContext.
        /// </summary>
        /// <param name="item">Entity to remove.</param>
        public void Remove(IEntity item)
        {
            this.Set(item.GetType()).Remove(item);
        }

        #endregion < Methods >
    }
}
