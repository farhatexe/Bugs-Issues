namespace ProjectTasks.Presentation.Core.Serialization
{
    using Newtonsoft.Json;
    using System;
    using System.Web;
    using System.Web.Mvc;

    /// <summary>
    /// Extension of JsonResult to use Newtownsoft JSON serializer instead of the default one.
    /// </summary>
    internal class JsonNetResult : JsonResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JsonNetResult"/> class.
        /// </summary>
        internal JsonNetResult()
        {
            Settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Error
            };
        }

        /// <summary>
        /// Gets the settings.
        /// </summary>
        /// <value>
        /// The settings.
        /// </value>
        public JsonSerializerSettings Settings { get; private set; }

        /// <summary>
        /// Enables processing of the result of an action method by a custom type that inherits from the System.Web.Mvc.ActionResult class
        /// </summary>
        /// <param name="context">The context within which the result is executed.</param>
        /// <exception cref="System.ArgumentNullException">The context parameter is null.</exception>
        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");

            HttpResponseBase response = context.HttpContext.Response;

            if (this.ContentEncoding != null)
                response.ContentEncoding = this.ContentEncoding;
            if (this.Data == null)
                return;

            response.ContentType = string.IsNullOrEmpty(this.ContentType) ? "application/json" : this.ContentType;

            var scriptSerializer = JsonSerializer.Create(this.Settings);
            scriptSerializer.Serialize(response.Output, this.Data);
        }
    }
}
