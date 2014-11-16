namespace ProjectTasks.Presentation.Core.Bootstrap.Extensions
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Handles extensions for JsTree component.
    /// </summary>
    public static class JsTreeExtension
    {
        /// <summary>
        /// To the js tree.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The source.</param>
        /// <param name="selected">The selected.</param>
        /// <param name="idProperty">The identifier property.</param>
        /// <param name="textProperty">The text property.</param>
        /// <param name="parentIdProperty">The parent identifier property.</param>
        /// <returns></returns>
        public static IEnumerable<dynamic> ToJsTree<T> (this IEnumerable<T> source, object selected, string idProperty, string textProperty, string parentIdProperty)
        {
            var itemType = typeof(T);
            var propId = itemType.GetProperty(idProperty);
            var propText = itemType.GetProperty(textProperty);
            var propParentId = itemType.GetProperty(parentIdProperty);

            List<JsTreeItem> all = source.Select(item => new JsTreeItem
                {
                    id = propId.GetValue(item, null),
                    parent = propParentId.GetValue(item, null) ?? "#",
                    text = propText.GetValue(item, null),
                    state = new JsTreeItemState
                    {
                        opened = false,
                        disabled = false,
                        selected = object.Equals(propId.GetValue(item, null), selected) ? true : false
                    }
            }).ToList();

            JsTreeExtension.SetSelectedItems(all.Where(item => item.state.selected).SingleOrDefault(), ref all);
            return all;
        }

        /// <summary>
        /// Sets the selected items.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="items">The items.</param>
        private static void SetSelectedItems(JsTreeItem item, ref List<JsTreeItem> items)
        {
            if (item != null && (string)item.parent != "#")
            {
                var parent = items.Where(p => p.id == item.parent).SingleOrDefault();
                parent.state.opened = true;
                SetSelectedItems(parent, ref items);
            }
        }

        /// <summary>
        /// Represents a tree item node.
        /// </summary>
        internal class JsTreeItem
        {

            /// <summary>
            /// Gets or sets the identifier.
            /// </summary>
            /// <value>
            /// The identifier.
            /// </value>
            public object id { get; set; }

            /// <summary>
            /// Gets or sets the parent.
            /// </summary>
            /// <value>
            /// The parent.
            /// </value>
            public object parent { get; set; }

            /// <summary>
            /// Gets or sets the text.
            /// </summary>
            /// <value>
            /// The text.
            /// </value>
            public object text { get; set; }

            /// <summary>
            /// Gets or sets the state.
            /// </summary>
            /// <value>
            /// The state.
            /// </value>
            public JsTreeItemState state { get; set; }
        }

        /// <summary>
        /// Handles node state in JsTree (opened, disabled and selected).
        /// </summary>
        internal class JsTreeItemState
        {
            /// <summary>
            /// Gets or sets a value indicating whether this <see cref="JsTreeItemState"/> is opened.
            /// </summary>
            /// <value>
            ///   <c>true</c> if opened; otherwise, <c>false</c>.
            /// </value>
            public bool opened { get; set; }

            /// <summary>
            /// Gets or sets a value indicating whether this <see cref="JsTreeItemState"/> is disabled.
            /// </summary>
            /// <value>
            ///   <c>true</c> if disabled; otherwise, <c>false</c>.
            /// </value>
            public bool disabled { get; set; }

            /// <summary>
            /// Gets or sets a value indicating whether this <see cref="JsTreeItemState"/> is selected.
            /// </summary>
            /// <value>
            ///   <c>true</c> if selected; otherwise, <c>false</c>.
            /// </value>
            public bool selected { get; set; }
        }
    }
}
