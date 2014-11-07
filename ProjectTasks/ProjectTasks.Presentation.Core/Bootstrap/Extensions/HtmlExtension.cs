namespace ProjectTasks.Presentation.Core.Bootstrap.Extensions
{
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Mvc.Html;

    /// <summary>
    /// HTML extensions that can be used with the following syntax: @Html.
    /// </summary>
    public static class HtmlExtension
    {
        /// <summary>
        /// Apply template to display Font awesome icon.
        /// </summary>
        /// <param name="html">Html helper corresponding to @Html.</param>
        /// <param name="input">Icon to display.</param>
        /// <returns>Html string representation of the font awesome icon.</returns>
        public static IHtmlString IconifyMe(this HtmlHelper html, string input)
        {
            return new HtmlHelper<string>(html.ViewContext, html.ViewDataContainer)
                .DisplayFor(x => input, "FontAwesomeIcon");
        }
    }
}
