namespace ProjectTasks.Presentation.Core.Authentication.Attributes
{
    using System;
    using System.Web.Mvc;

    /// <summary>
    /// Custom attibutes to handle authorization on methods and classes.
    /// </summary>
    public class ApplicationAuthorizeAttribute : AuthorizeAttribute
    {
        /// <summary>
        /// Handle authorization attributes on classes and methods
        /// </summary>
        public ApplicationAuthorizeAttribute() : base() { }

        /// <summary>
        /// Handle authorization attributes on classes and methods
        /// </summary>
        /// <param name="roles">Array of roles. It applies an OR clause between each roles.</param>
        public ApplicationAuthorizeAttribute(string[] roles)
        {
            this.Roles = String.Join(",", roles);
        }
    }
}
