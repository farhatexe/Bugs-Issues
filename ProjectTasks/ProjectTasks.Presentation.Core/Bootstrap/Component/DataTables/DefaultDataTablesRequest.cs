namespace ProjectTasks.Presentation.Core.Bootstrap.Component.DataTables
{
    using System.Collections.Generic;

    /// <summary>
    /// Implements a default DataTables request.
    /// </summary>
    public class DefaultDataTablesRequest : DataTablesSortedRequest, IDataTablesRequest
    {
        /// <summary>
        /// Gets/Sets the draw counter from DataTables.
        /// </summary>
        public virtual int Draw { get; set; }
    }
}
