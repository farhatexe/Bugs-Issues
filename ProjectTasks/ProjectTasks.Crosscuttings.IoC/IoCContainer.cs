namespace ProjectTasks.Crosscuttings.IoC
{
    using Microsoft.Practices.Unity;
    using Microsoft.Practices.Unity.Configuration;
    using System.Configuration;

    /// <summary>
    /// Container for IoC.
    /// </summary>
    public class IoCContainer
    {
        #region < Private members >

        private static IoCContainer defaultInstance;

        private IUnityContainer container;

        #endregion < Private members >

        #region < Public properties >

        /// <summary>
        /// Get the default container.
        /// </summary>
        public static IoCContainer Default
        {
            get
            {
                if (IoCContainer.defaultInstance == null)
                {
                    IoCContainer.defaultInstance = new IoCContainer();
                }
                return IoCContainer.defaultInstance;
            }
        }

        #endregion < Public properties >

        #region < Constructors >

        /// <summary>
        /// Private contructor that initializes the container and loads all types handled by the IoC.
        /// </summary>
        private IoCContainer()
        {
            this.container = new UnityContainer();
            this.container.LoadConfiguration((UnityConfigurationSection)ConfigurationManager.GetSection("unity"));
        }

        #endregion < Constructors >

        #region < Public methods >

        /// <summary>
        /// Resolve the specified type and return the resolved instance.
        /// </summary>
        /// <typeparam name="T">T type to resolve.</typeparam>
        /// <returns>Resolve type.</returns>
        public T Resolve<T>()
        {
            return this.container.Resolve<T>();
        }

        #endregion < Public methods >
    }
}
