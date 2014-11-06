namespace ProjectTasks.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using ProjectTasks.Data.Interfaces;
    using ProjectTasks.Business.Domain.Entities;

    /// <summary>
    /// Represents the unit of work.
    /// </summary>
    /// <typeparam name="TDataContext">Type of DataContext.</typeparam>
    public class UnitOfWork<TDataContext> : IUnitOfWork<TDataContext> where TDataContext : class, IDataContext
    {
        #region < Fields >

        /// <summary>
        /// The repositories.
        /// </summary>
        private Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        /// <summary>
        /// The data context.
        /// </summary>
        private TDataContext context;

        #endregion < Fields >

        #region < Constructors >

        /// <summary>
        /// Initializes a new instance of the UnitOfWork class.
        /// </summary>
        /// <param name="dataContext">Data context for the unit of work.</param>
        public UnitOfWork(TDataContext dataContext)
        {
            this.context = dataContext;
        }

        #endregion < Constructors >

        #region < Methods >

        /// <summary>
        /// Returns the repository of the specified type.
        /// </summary>
        /// <typeparam name="TEntity">Entity type.</typeparam>
        /// <returns>The repository.</returns>
        public IRepository<TEntity, TDataContext> GetRepository<TEntity>() where TEntity : class, IEntity
        {
            if (this.repositories.ContainsKey(typeof(TEntity)))
            {
                return this.repositories[typeof(TEntity)] as IRepository<TEntity, TDataContext>;
            }

            IRepository<TEntity, TDataContext> repository = new Repository<TEntity, TDataContext>(this.context);
            this.repositories[typeof(TEntity)] = repository;
            return repository;
        }

        /// <summary>
        /// Commit all changes.
        /// </summary>
        public void Commit()
        {
            if (this.context != null)
            {
                this.context.SaveChanges();
            }
        }

        /// <summary>
        /// Rollback all changes.
        /// </summary>
        public void Rollback()
        {
            if (this.context != null)
            {
                this.context.CancelChanges();
            }
        }

        #endregion < Methods >
    }
}
