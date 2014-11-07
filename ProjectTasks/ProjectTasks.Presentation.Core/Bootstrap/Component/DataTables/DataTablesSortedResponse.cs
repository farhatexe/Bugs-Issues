namespace ProjectTasks.Presentation.Core.Bootstrap.Component.DataTables
{
    using System.Collections.Generic;

    /// <summary>
    /// Represents a DataTables sorted response encapsuling the business type.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DataTablesSortedResponse<T> where T : class, new()
    {
        /// <summary>
        /// Gets or set the number of total items (without paging).
        /// </summary>
        public int Total { get; set; }

        /// <summary>
        /// Get or set the items to render the specified datatables page.
        /// </summary>
        public IEnumerable<T> Items { get; set; }
    }
}
