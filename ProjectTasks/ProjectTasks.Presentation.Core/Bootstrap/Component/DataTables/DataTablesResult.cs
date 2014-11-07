namespace ProjectTasks.Presentation.Core.Bootstrap.Component.DataTables
{
    using System.Web.Mvc;

    /// <summary>
    /// Represents a full datatables JSON object containing all the properties required by the datatables component.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DataTablesResult<T> : JsonResult where T : class, new()
    {
        /// <summary>
        /// Build a new DataTables result.
        /// </summary>
        /// <param name="response">Sorted items to render.</param>
        /// <param name="request">Sorted request containing all filter parameters.</param>
        /// <param name="behavior">JSON request behavior set to Deny Get by default.</param>
        public DataTablesResult(DataTablesSortedResponse<T> response, IDataTablesRequest request, JsonRequestBehavior behavior = JsonRequestBehavior.DenyGet)
        {
            this.Data = new
            {
                draw = request.Draw,
                data = response.Items,
                recordsTotal = response.Total,
                recordsFiltered = response.Total
            };

            this.JsonRequestBehavior = behavior;
        }
    }
}
