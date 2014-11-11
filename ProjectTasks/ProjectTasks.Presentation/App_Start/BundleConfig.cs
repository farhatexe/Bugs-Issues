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
            #region < Metronic template >

            bundles.Add(new ScriptBundle("~/content/metronic-theme-js")
                .Include(
                    "~/Content/Metronic/metronic/assets/global/plugins/jquery-1.11.0.min.js",
                    "~/Content/Metronic/metronic/assets/global/plugins/jquery-migrate-1.2.1.min.js",
                    "~/Content/Metronic/metronic/assets/global/plugins/jquery-ui/jquery-ui-1.10.3.custom.min.js",
                    "~/Content/Metronic/metronic/assets/global/plugins/bootstrap/js/bootstrap.min.js",
                    "~/Content/Metronic/metronic/assets/global/plugins/bootstrap-hover-dropdown/bootstrap-hover-dropdown.min.js",
                    "~/Content/Metronic/metronic/assets/global/plugins/jquery-slimscroll/jquery.slimscroll.js",
                    "~/Content/Metronic/metronic/assets/global/plugins/jquery.blockui.min.js",
                    "~/Content/Metronic/metronic/assets/global/plugins/jquery.cokie.min.js",
                    "~/Content/Metronic/metronic/assets/global/plugins/uniform/jquery.uniform.min.js",
                    "~/Content/Metronic/metronic/assets/global/plugins/select2/select2.min.js",
                    "~/Content/Metronic/metronic/assets/global/plugins/data-tables/jquery.dataTables.min.js",
                    "~/Content/Metronic/metronic/assets/global/plugins/data-tables/dataTables.bootstrap.js",
                    "~/Content/Metronic/metronic/assets/global/plugins/bootstrap-wizard/jquery.bootstrap.wizard.min.js",
                    "~/Content/Metronic/metronic/assets/global/plugins/bootstrap-toastr/toastr.min.js",
                    "~/Content/Metronic/metronic/assets/global/plugins/bootstrap-modal/js/bootstrap-modal.js",
                    "~/Content/Metronic/metronic/assets/global/plugins/bootstrap-modal/js/bootstrap-modalmanager.js",
                    "~/Content/Metronic/metronic/assets/global/plugins/jquery-validation/js/jquery.validate.min.js",
                    "~/Content/Metronic/metronic/assets/global/plugins//moment-with-locales.min.js",
                    "~/Content/Metronic/metronic/assets/global/scripts/datatable.js",
                    "~/Content/Metronic/metronic/assets/global/scripts/metronic.js",
                    "~/Content/Metronic/metronic/assets/admin/layout/scripts/layout.js"));

            bundles.Add(new ScriptBundle("~/content/metronic-theme-ltie9-js").Include(
                "~/Content/Metronic/metronic/assets/global/plugins/respond.min.js",
                "~/Content/Metronic/metronic/assets/global/plugins/excanvas.min.js"
            ));

            bundles.Add(new StyleImagePathBundle("~/content/metronic-theme-css").Include(
                "~/Content/Metronic/metronic/assets/global/plugins/font-awesome/css/font-awesome.min.css",
                "~/Content/Metronic/metronic/assets/global/plugins/simple-line-icons/simple-line-icons.min.css",
                "~/Content/Metronic/metronic/assets/global/plugins/bootstrap/css/bootstrap.min.css",
                "~/Content/Metronic/metronic/assets/global/plugins/uniform/css/uniform.default.css",
                "~/Content/Metronic/metronic/assets/global/plugins/bootstrap-daterangepicker/daterangepicker-bs3.css",
                "~/Content/Metronic/metronic/assets/global/plugins/fullcalendar/fullcalendar/fullcalendar.css",
                "~/Content/Metronic/metronic/assets/global/plugins/jqvmap/jqvmap/jqvmap.css",
                "~/Content/Metronic/metronic/assets/global/plugins/data-tables/DT_bootstrap.css",
                "~/Content/Metronic/metronic/assets/global/plugins/dropzone/css/dropzone.css",
                "~/Content/Metronic/metronic/assets/global/plugins/bootstrap-toastr/toastr.min.css",
                "~/Content/Metronic/metronic/assets/global/plugins/bootstrap-select/bootstrap-select.min.css",
                "~/Content/Metronic/metronic/assets/global/plugins/select2/select2.css",
                "~/Content/Metronic/metronic/assets/global/plugins/jquery-multi-select/css/multi-select.css",
                "~/Content/Metronic/metronic/assets/global/css/components.css",
                "~/Content/Metronic/metronic/assets/global/css/plugins.css",
                "~/Content/Metronic/metronic/assets/admin/layout/css/layout.css",
                "~/Content/Metronic/metronic/assets/admin/layout/css/themes/red.css"));

            #endregion < Metronic template >

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

            #region < SignalR >

            bundles.Add(new ScriptBundle("~/content/signalr-js")
                .Include("~/Content/SignalR/jquery.signalR-2.1.2.min.js"));

            #endregion < SignalR >

            #region < M3gur0 >

            bundles.Add(new ScriptBundle("~/Content/meguro-js")
                .IncludeDirectory("~/Content/meguro/scripts/prototypes", "*.js", false)
                .Include("~/Content/meguro/scripts/app.js")
                .IncludeDirectory("~/Content/meguro/scripts/directives", "*.js", false)
                .IncludeDirectory("~/Content/meguro/scripts/controllers", "*.js", false)
                .IncludeDirectory("~/Content/meguro/scripts/plugins", "*.js", false)
                .IncludeDirectory("~/Content/meguro/scripts/services", "*.js", false));

            bundles.Add(new StyleBundle("~/Content/meguro-css")
                .IncludeDirectory("~/Content/meguro/css", "*.css", false));

            #endregion < M3gur0 >
        }
    }
}
