namespace ProjectTasks.Presentation.Core.Bootstrap.Extensions
{
    using ProjectTasks.Presentation.Core.Bootstrap.Component.DataTables;
    using System;
    using System.Linq;
    using System.Web.Helpers;

    /// <summary>
    /// Extensions for DataTablesSortedResponse class.
    /// </summary>
    public static class DataTablesSortedResponseExtenders
    {
        /// <summary>
        /// Transform an IQueryable object to a sorted datatables response.
        /// </summary>
        /// <typeparam name="T">Type of the IQueryable object.</typeparam>
        /// <param name="query">IQueryable object to transform.</param>
        /// <param name="request">Additional request parameters.</param>
        /// <returns>Generic DataTables sorted response.</returns>
        public static DataTablesSortedResponse<T> ToDataTablesSortedResponse<T>(this IQueryable<T> query, DataTablesSortedRequest request) where T : class, new()
        {
            var items = query.OrderBy(x => true);

            Type tType = typeof(T);

            request.Columns
                .Where(col => col.Orderable && col.IsOrdered)
                .OrderBy(col => col.OrderNumber)
                .Select(col => new
                {
                    SortDirection = col.SortDirection,
                    Expression = col.GetOrderByExpression<T>(tType)
                })
                .Where(x => x.Expression != null)
                .ToList()
                .ForEach(expr =>
                {
                    if (expr.SortDirection == SortDirection.Ascending)
                    {
                        items = items.ThenBy(expr.Expression);
                    }
                    else
                    {
                        items = items.ThenByDescending(expr.Expression);
                    }
                });


            return new DataTablesSortedResponse<T>()
            {
                Total = query.Count(),
                Items = items.Skip(request.Start).Take(request.Length).ToList()
            };
        }
    }
}
