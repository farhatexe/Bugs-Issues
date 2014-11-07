namespace ProjectTasks.Presentation.Core.Authentication.Manager
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Threading;
    using System.Web.Mvc;

    /// <summary>
    /// Regulated action manager.
    /// </summary>
    public static class RegulatedActionManager
    {
        /// <summary>
        /// Returns a value indicating whether the current user is authorized to access to the specified ressource, according to the regulated actions.
        /// </summary>
        /// <typeparam name="TController">The type of the controller.</typeparam>
        /// <param name="action">The controller action.</param>
        /// <returns>True if the current user is authorized.</returns>
        public static bool IsAuthorized<TController>(Expression<Action<TController>> action)
        {
            Func<CustomAttributeData, bool> customAttributeSelector = x => x.AttributeType == typeof(AuthorizeAttribute);

            var controllerAuthorizes = typeof(TController).CustomAttributes.Where(customAttributeSelector);
            var methodAuthorizes = (action.Body as MethodCallExpression) != null ?
                (action.Body as MethodCallExpression).Method.CustomAttributes.Where(customAttributeSelector)
                : new CustomAttributeData[0];

            Func<CustomAttributeData, string> roleSelector = x => x.NamedArguments
                .Where(n => n.MemberName == "Roles")
                .Select(n => n.TypedValue.Value.ToString())
                .SingleOrDefault();

            return methodAuthorizes.Select(roleSelector)
                .Union(controllerAuthorizes.Select(roleSelector))
                .Where(p => !string.IsNullOrWhiteSpace(p))
                .All(p => Thread.CurrentPrincipal.IsInRole(p));

        }

        /// <summary>
        /// Returns a value indicating whether the current user is authorized to access to the specified ressource, according to the regulated actions.
        /// </summary>
        /// <typeparam name="TController">The type of the controller.</typeparam>
        /// <param name="action">The controller action.</param>
        /// <returns>True if the current user is authorized.</returns>
        public static bool IsAuthorized<TController>(params Expression<Func<TController, ActionResult>>[] actions) where TController : Controller
        {
            foreach (var item in actions)
                if (IsAuthorized(item))
                    return true;

            return false;
        }

    }

}
