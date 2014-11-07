namespace ProjectTasks.Presentation.Core.Bootstrap.Component.DataTables
{
    using System.Collections.Generic;

    /// <summary>
    /// Represents a DataTables sorted request encapsuling the business type.
    /// </summary>
    public class DataTablesSortedRequest
    {
        /// <summary>
        /// Get or set the item index to render.
        /// </summary>
        public int Start { get; set; }

        /// <summary>
        /// Get or set the page length.
        /// </summary>
        public int Length { get; set; }

        /// <summary>
        /// Get or set the datatables columns.
        /// </summary>
        public IEnumerable<DataTablesColumn> Columns { get; set; }
    }
}
