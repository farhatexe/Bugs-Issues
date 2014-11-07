namespace ProjectTasks.Presentation.Core.Authentication.Extensions
{
    using ProjectTasks.Presentation.Core.Authentication.Manager;
    using System;
    using System.Linq.Expressions;
    using System.Web.Mvc;
    using System.Web.Routing;

    /// <summary>
    /// Extensions for UrlHelper class.
    /// </summary>
    public static class UrlHelperExtension
    {
        /// <summary>
        /// Invoke regulated action to know if the request can be honored.
        /// </summary>
        /// <typeparam name="TController">Controller that contains the action.</typeparam>
        /// <param name="helper">Helper representation of @Url.</param>
        /// <param name="action">Action on which rights will be tested.</param>
        /// <returns>String representation of the controller action URL.</returns>
        public static string RegulatedAction<TController>(this UrlHelper helper, Expression<Action<TController>> action)
        {
            return helper.RegulatedAction(action, null, null, null);
        }

        /// <summary>
        /// Invoke regulated action to know if the request can be honored.
        /// </summary>
        /// <typeparam name="TController">Controller that contains the action.</typeparam>
        /// <param name="helper">Helper representation of @Url.</param>
        /// <param name="action">Action on which rights will be tested.</param>
        /// <param name="routeValues">Additional route value params.</param>
        /// <returns>String representation of the controller action URL.</returns>
        public static string RegulatedAction<TController>(this UrlHelper helper, Expression<Action<TController>> action, object routeValues)
        {
            var routeValueDictionnary = new RouteValueDictionary(routeValues);

            return helper.RegulatedAction(action, routeValueDictionnary, null, null);
        }

        /// <summary>
        /// Invoke regulated action to know if the request can be honored.
        /// </summary>
        /// <typeparam name="TController">Controller that contains the action.</typeparam>
        /// <param name="helper">Helper representation of @Url.</param>
        /// <param name="action">Action on which rights will be tested.</param>
        /// <param name="routeValues">Additional route value params.</param>
        /// <returns>String representation of the controller action URL.</returns>
        public static string RegulatedAction<TController>(this UrlHelper helper, Expression<Action<TController>> action, RouteValueDictionary routeValues)
        {
            return helper.RegulatedAction(action, routeValues, null, null);
        }

        /// <summary>
        /// Invoke regulated action to know if the request can be honored.
        /// </summary>
        /// <typeparam name="TController">Controller that contains the action.</typeparam>
        /// <param name="helper">Helper representation of @Url.</param>
        /// <param name="action">Action on which rights will be tested.</param>
        /// <param name="routeValues">Additional route value params.</param>
        /// <param name="protocol">The protocol.</param>
        /// <returns>String representation of the controller action URL.</returns>
        public static string RegulatedAction<TController>(this UrlHelper helper, Expression<Action<TController>> action, object routeValues, string protocol)
        {
            var routeValueDictionnary = new RouteValueDictionary(routeValues);
            return helper.RegulatedAction(action, routeValueDictionnary, protocol, null);
        }

        /// <summary>
        /// Invoke regulated action to know if the request can be honored.
        /// </summary>
        /// <typeparam name="TController">Controller that contains the action.</typeparam>
        /// <param name="helper">Helper representation of @Url.</param>
        /// <param name="action">Action on which rights will be tested.</param>
        /// <param name="routeValues">Additional route value params.</param>
        /// <param name="protocol">The protocol.</param>
        /// <returns>String representation of the controller action URL.</returns>
        public static string RegulatedAction<TController>(this UrlHelper helper, Expression<Action<TController>> action, RouteValueDictionary routeValues, string protocol)
        {
            return helper.RegulatedAction(action, routeValues, protocol, null);
        }

        /// <summary>
        /// Invoke regulated action to know if the request can be honored.
        /// </summary>
        /// <typeparam name="TController">Controller that contains the action.</typeparam>
        /// <param name="helper">Helper representation of @Url.</param>
        /// <param name="action">Action on which rights will be tested.</param>
        /// <param name="routeValues">Additional route value params.</param>
        /// <param name="protocol">The protocol.</param>
        /// <param name="hostName">The hostname.</param>
        /// <returns>String representation of the controller action URL.</returns>
        public static string RegulatedAction<TController>(this UrlHelper helper, Expression<Action<TController>> action, RouteValueDictionary routeValues, string protocol, string hostName)
        {
            if (!RegulatedActionManager.IsAuthorized(action))
                return String.Empty;

            return helper.Action((action.Body as MethodCallExpression).Method.Name, typeof(TController).Name.Replace("Controller", ""), routeValues, protocol, hostName);
        }
    }
}