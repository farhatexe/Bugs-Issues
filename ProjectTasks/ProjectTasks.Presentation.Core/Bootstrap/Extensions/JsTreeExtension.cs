namespace ProjectTasks.Presentation.Core.Bootstrap.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class JsTreeExtension
    {
        public static IEnumerable<dynamic> ToJsTree<T> (this IEnumerable<T> source, object selected, string idProperty, string textProperty, string parentIdProperty)
        {
            var itemType = typeof(T);
            var propId = itemType.GetProperty(idProperty);
            var propText = itemType.GetProperty(textProperty);
            var propParentId = itemType.GetProperty(parentIdProperty);

            List<ComboTreeItem> all = source.Select(item => new ComboTreeItem
                {
                    id = propId.GetValue(item, null),
                    parent = propParentId.GetValue(item, null) ?? "#",
                    text = propText.GetValue(item, null),
                    state = new ComboTreeItemState
                    {
                        opened = false,
                        disabled = false,
                        selected = object.Equals(propId.GetValue(item, null), selected) ? true : false
                    }
            }).ToList();

            JsTreeExtension.SetSelectedItems(all.Where(item => item.state.selected).SingleOrDefault(), ref all);
            return all;
        }

        private static void SetSelectedItems(ComboTreeItem item, ref List<ComboTreeItem> items)
        {
            if (item != null && item.parent != "#")
            {
                var parent = items.Where(p => p.id == item.parent).SingleOrDefault();
                parent.state.opened = true;
                SetSelectedItems(parent, ref items);
            }
        }

        internal class ComboTreeItem
        {

            public object id { get; set; }

            public object parent { get; set; }

            public object text { get; set; }

            public ComboTreeItemState state { get; set; }
        }

        internal class ComboTreeItemState
        {
            public bool opened { get; set; }

            public bool disabled { get; set; }

            public bool selected { get; set; }
        }
    }
}
