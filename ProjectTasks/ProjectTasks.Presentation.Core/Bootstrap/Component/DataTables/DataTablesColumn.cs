namespace ProjectTasks.Presentation.Core.Bootstrap.Component.DataTables
{
    using System.Web.Helpers;

    /// <summary>
    /// Represents a datatables columns.
    /// </summary>
    public class DataTablesColumn
    {/// <summary>
        /// Gets the data component (bind property name).
        /// </summary>
        public string PropertyName { get; set; }
        /// <summary>
        /// Indicates if the column is orderable or not.
        /// </summary>
        public bool Orderable { get; set; }
        /// <summary>
        /// Indicates if the current column should be ordered on server-side or not.
        /// </summary>
        public bool IsOrdered { get { return OrderNumber != -1; } }
        /// <summary>
        /// Indicates the column' position on the ordering (multi-column ordering).
        /// </summary>
        public int OrderNumber { get; set; }
        /// <summary>
        /// Indicates the column's sort direction.
        /// </summary>
        public SortDirection SortDirection { get; set; }
    }
}
