namespace ProjectTasks.Presentation.Core.Bootstrap.Component.Wizard
{
    using ProjectTasks.Presentation.Core.Bootstrap.Constants;
    using System;
    using System.Web.Mvc;
    using System.Web.WebPages;

    /// <summary>
    /// A step page rendered by the wizard component.
    /// </summary>
    public class WizardStep
    {
        /// <summary>
        /// Gets or set the Step Id.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or set the Step label.
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// Gets or set the Step caption.
        /// </summary>
        public string Caption { get; set; }

        /// <summary>
        /// Gets or set the Step content.
        /// </summary>
        public Func<HtmlHelper, HelperResult> Content { get; set; }

        /// <summary>
        /// Gets or set the Step icon.
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// Build a step object.
        /// </summary>
        /// <param name="id">Id to affect to the step.</param>
        public WizardStep(string id)
        {
            this.Id = id;
            this.Icon = FontAwesome.Check;
        }
    }
}
