namespace ProjectTasks.Presentation.Core.Bootstrap.Component.Portlet
{
    using System;
    using System.Web.Mvc;
    using System.Web.WebPages;

    /// <summary>
    /// Represents a bootstrap portlet component.
    /// </summary>
    public class Portlet
    {
        #region < Members >

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the color.
        /// </summary>
        /// <value>The color.</value>
        public string Color { get; set; }

        /// <summary>
        /// Gets or sets the caption.
        /// </summary>
        /// <value>The caption.</value>
        public Func<HtmlHelper, HelperResult> Caption { get; set; }

        /// <summary>
        /// Gets or sets the content.
        /// </summary>
        /// <value>The content.</value>
        public Func<HtmlHelper, HelperResult> Content { get; set; }

        /// <summary>
        /// Gets or sets the actions.
        /// </summary>
        /// <value>The actions</value>
        public Func<HtmlHelper, HelperResult> Actions { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Portlet"/> is collapsable.
        /// </summary>
        /// <value><c>true</c> if collapsable; otherwise, <c>false</c>.</value>
        public bool Collapsable { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Portlet"/> is scrollable.
        /// </summary>
        /// <value><c>true</c> if scrollable; otherwise, <c>false</c>.</value>
        public bool Scrollable { get; set; }

        /// <summary>
        /// Gets or sets the CSS classes.
        /// </summary>
        /// <value>The CSS classes.</value>
        public string CssClass { get; set; }

        #endregion < Members >

        #region < Constructors >

        /// <summary>
        /// Initializes a new instance of the <see cref="Portlet"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public Portlet(string id)
        {
            this.Id = id;
        }

        #endregion < Constructors >
    }
}
