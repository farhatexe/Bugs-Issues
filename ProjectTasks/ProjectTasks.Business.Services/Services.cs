namespace ProjectTasks.Business.Services
{
    using ProjectTasks.Business.Services.Interfaces;
    using ProjectTasks.Data.Interfaces;

    /// <summary>
    /// Provides an implementation for IServices interface.
    /// </summary>
    public partial class Services : IServices
    {
        private IUnitOfWork<IDataContext> unitOfWork;

        /// <summary>
        /// Initializes a new instance of the <see cref="Services"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        public Services(IUnitOfWork<IDataContext> unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
    }
}
