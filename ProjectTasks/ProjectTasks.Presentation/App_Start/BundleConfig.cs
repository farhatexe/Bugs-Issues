namespace ProjectTasks.Presentation
{

    using System.Web.Optimization;

    /// <summary>
    /// Bundle configuration. All js and CSS must be included to the bundle to optimize the number of requests to the web server.
    /// </summary>
    public class BundleConfig
    {
        /// <summary>
        /// Registers the bundles.
        /// </summary>
        /// <param name="bundles">The bundles.</param>
        public static void RegisterBundles(BundleCollection bundles)
        {
            #region < Plugins >

            bundles.Add(new ScriptBundle("~/content/plugins-js")
                .Include(
                    "~/Content/Plugins/jquery-1.11.1.min.js",
                    "~/Content/Plugins/jquery-migrate-1.2.1.min.js",
                    "~/Content/Plugins/jquery-ui/jquery-ui.min.js",
                    "~/Content/Plugins/bootstrap/js/bootstrap.min.js",
                    "~/Content/Plugins/bootstrap-hover-dropdown/bootstrap-hover-dropdown.min.js",
                    "~/Content/Plugins/jquery-slimscroll/jquery.slimscroll.min.js",
                    "~/Content/Plugins/jquery.blockUI.min.js",
                    "~/Content/Plugins/jquery.cookie.js",
                    "~/Content/Plugins/uniform/jquery.uniform.min.js",
                    "~/Content/Plugins/moment-with-locales.min.js",
                    "~/Content/Plugins/select2/select2.min.js",
                    "~/Content/Plugins/data-tables/jquery.dataTables.min.js",
                    "~/Content/Plugins/data-tables/dataTables.bootstrap.js",
                    "~/Content/Plugins/bootstrap-wizard/jquery.bootstrap.wizard.min.js",
                    "~/Content/Plugins/bootstrap-toastr/toastr.min.js",
                    "~/Content/Plugins/jquery-treetable/jquery.treetable.js"
                )
            );

            bundles.Add(new ScriptBundle("~/content/plugins-ltie9-js")
                .Include(
                    "~/Content/Plugins/respond.min.js",
                    "~/Content/Plugins/excanvas.min.js"
                )
            );

            bundles.Add(new StyleBundle("~/content/plugins-css")
                .Include(
                    "~/Content/Plugins/fonts/fonts.css",
                    "~/Content/Plugins/font-awesome/css/font-awesome.min.css",
                    "~/Content/Plugins/simple-line-icons/simple-line-icons.min.css",
                    "~/Content/Plugins/bootstrap/css/bootstrap.min.css",
                    "~/Content/Plugins/uniform/css/uniform.default.css",
                    "~/Content/Plugins/bootstrap-select/css/bootstrap-select.min.css",
                    "~/Content/Plugins/select2/select2.css",
                    "~/Content/Plugins/data-tables/DT_bootstrap.css",
                    "~/Content/Plugins/bootstrap-toastr/toastr.min.css",
                    "~/Content/Plugins/jquery-treetable/css/jquery.treetable.css",
                    "~/Content/Plugins/jquery-treetable/css/jquery.treetable.theme.bootstrap.css"
                )
            );

            #endregion < Plugins >

            #region < Angular >

            bundles.Add(new ScriptBundle("~/content/angular-js")
                .Include(
                    "~/Content/Angular/angular.min.js",
                    "~/Content/Angular/angular-route.min.js",
                    "~/Content/Angular/angular-resource.min.js",
                    "~/Content/Angular/ui-bootstrap-0.11.2.min.js",
                    "~/Content/Angular/angular-moment.min.js",
                    "~/Content/Angular/angular-datatables.min.js"));

            #endregion < Angular >

            #region < Metronic >

            bundles.Add(new ScriptBundle("~/content/metronic-js")
                .Include(
                    "~/Content/Metronic/scripts/metronic.js",
                    "~/Content/Metronic/scripts/layout.js",
                    "~/Content/Metronic/scripts/datatable.js"
                )
            );

            bundles.Add(new StyleBundle("~/content/metronic-css")
                .Include(
                    "~/Content/Metronic/css/components.css",
                    "~/Content/Metronic/css/plugins.css",
                    "~/Content/Metronic/css/layout.css",
                    "~/Content/Metronic/css/themes/default.css",
                    "~/Content/Metronic/css/themes/red-limagrain.css"
                )
            );

            #endregion < Metronic >

            #region < SignalR >

            bundles.Add(new ScriptBundle("~/content/signalr-js")
                .Include("~/Content/SignalR/jquery.signalR-2.1.2.min.js"));

            #endregion < SignalR >

            #region < M3gur0 >

            bundles.Add(new ScriptBundle("~/Content/meguro-js")
                .IncludeDirectory("~/Content/meguro/scripts/prototypes", "*.js", false)
                .IncludeDirectory("~/Content/meguro/scripts/modules", "*.js", false)
                .Include("~/Content/meguro/scripts/app.js")
                .IncludeDirectory("~/Content/meguro/scripts/directives", "*.js", false)
                .IncludeDirectory("~/Content/meguro/scripts/controllers", "*.js", false)
                .IncludeDirectory("~/Content/meguro/scripts/plugins", "*.js", false)
                .IncludeDirectory("~/Content/meguro/scripts/services", "*.js", false));

            bundles.Add(new StyleBundle("~/Content/meguro-css").IncludeDirectory("~/Content/meguro/css", "*.css", false));

            #endregion < M3gur0 >
        }
    }
}
