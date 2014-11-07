namespace ProjectTasks.Presentation.Core.Bootstrap.Component.Wizard
{
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;
    using System.Web.WebPages;

    /// <summary>
    /// Represents a bootstrap wizard element.
    /// </summary>
    public class Wizard
    {
        /// <summary>
        /// Gets or set the wizard Id.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or set the wizard caption.
        /// </summary>
        public Func<HtmlHelper, HelperResult> Caption { get; set; }

        /// <summary>
        /// Gets or set the wizard color.
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// Gets the wizard steps.
        /// </summary>
        public IList<WizardStep> Steps { get; private set; }

        /// <summary>
        /// Add a new step to the wizard component.
        /// </summary>
        /// <param name="id">Step id.</param>
        /// <param name="label">Step label.</param>
        /// <param name="content">Step content.</param>
        /// <param name="caption">Step caption.</param>
        public void AddStep(string id, string label, Func<HtmlHelper, HelperResult> content, string caption = null)
        {
            this.Steps.Add(new WizardStep(id) { Label = label, Content = content, Caption = caption ?? label });
        }

        /// <summary>
        /// Build a new wizard component.
        /// </summary>
        /// <param name="id">Wizard Id.</param>
        public Wizard(string id)
        {
            this.Id = id;
            this.Steps = new List<WizardStep>();
        }
    }
}
