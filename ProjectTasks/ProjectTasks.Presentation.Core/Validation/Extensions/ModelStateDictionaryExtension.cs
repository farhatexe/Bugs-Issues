namespace ProjectTasks.Presentation.Core.Validation.Extensions
{
    using System.Linq;
    using System.Web.Mvc;

    /// <summary>
    /// Extensions for model state dictionary class
    /// </summary>
    public static class ModelStateDictionaryExtension
    {
        /// <summary>
        /// Get all errors in model state
        /// </summary>
        /// <param name="modelState">Model state from which errors are taken</param>
        /// <returns>Dynamic Key/Value pairs enumerable object</returns>
        public static dynamic GetErrors(this ModelStateDictionary modelState)
        {
            return modelState
                .Where(x => x.Value.Errors.Any())
                .Select(x => new { Key = x.Key, Errors = x.Value.Errors });
        }
    }
}
