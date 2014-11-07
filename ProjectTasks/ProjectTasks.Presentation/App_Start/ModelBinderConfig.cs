namespace ProjectTasks.Presentation
{
    using ProjectTasks.Presentation.Core.Bootstrap.Component.DataTables;
    using System.Web.Mvc;

    /// <summary>
    /// Represents the configuration of custom model binders.
    /// </summary>
    public class ModelBinderConfig
    {
        /// <summary>
        /// Registers the model binders.
        /// </summary>
        public static void RegisterModelBinders()
        {
            ModelBinders.Binders.Add(typeof(DefaultDataTablesRequest), new DataTablesBinder());
        }
    }
}