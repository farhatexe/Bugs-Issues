namespace ProjectTasks.Presentation.Core.Bootstrap.Extensions
{
    using ProjectTasks.Presentation.Core.Bootstrap.Component.DataTables;
    using System;
    using System.Linq.Expressions;
    using System.Reflection;

    /// <summary>
    /// Extensions for DataTables columns.
    /// </summary>
    internal static class DataTablesColumnExtenders
    {
        /// <summary>
        /// Gets an expression that represents the order linq clause.
        /// </summary>
        /// <typeparam name="T">Generic Type of the object.</typeparam>
        /// <param name="column">Column on which we have to get the order by clause.</param>
        /// <param name="tType">Object type contained into the column.</param>
        /// <returns>An Expression representing the order by LinQ clause.</returns>
        internal static Expression<Func<T, object>> GetOrderByExpression<T>(this DataTablesColumn column, Type tType)
        {
            MemberInfo prop = tType.GetProperty(column.PropertyName);
            if (prop == null) return null;

            ParameterExpression tParam = Expression.Parameter(tType, "x");

            MemberExpression valueInNameProperty = Expression.MakeMemberAccess(tParam, prop);
            
            UnaryExpression expression = Expression.Convert(
                valueInNameProperty, 
                prop.MemberType.Equals(MemberTypes.Property) 
                    ? (((PropertyInfo)prop).PropertyType)
                    : typeof(object));

            Expression<Func<T, object>> orderByExpression = Expression.Lambda<Func<T, object>>(expression, tParam);

            return orderByExpression;
        }
    }
}
