using System.Web;
using System.Web.Optimization;

namespace ToolTrackApp
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            // App Styles
            bundles.Add(new StyleBundle("~/Content/appCss").Include(
                "~/Content/app/css/app.css",
                "~/Content/mvc-override.css"
            ));

            // Bootstrap Styles
            bundles.Add(new StyleBundle("~/Content/bootstrapCss").Include(
                "~/Content/app/css/bootstrap.css", new CssRewriteUrlTransform()
            ));

            //Main scripts
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-2.1.4.js"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryUtil").Include(
                        "~/Scripts/app/util/JUtility.js",
                        "~/Scripts/app/util/JMessages.js",
                        "~/Scripts/app/util/JExtensions.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/ToolTrack").Include(
                // App init
                "~/Scripts/app/app.init.js",
                // Modules
                "~/Scripts/app/modules/bootstrap-start.js",
                "~/Scripts/app/modules/calendar.js",
                "~/Scripts/app/modules/classyloader.js",
                "~/Scripts/app/modules/clear-storage.js",
                "~/Scripts/app/modules/constants.js",
                "~/Scripts/app/modules/flatdoc.js",
                "~/Scripts/app/modules/trigger-resize.js",
                "~/Scripts/app/modules/fullscreen.js",
                "~/Scripts/app/modules/load-css.js",
                "~/Scripts/app/modules/localize.js",
                "~/Scripts/app/modules/maps-vector.js",
                "~/Scripts/app/modules/navbar-search.js",
                "~/Scripts/app/modules/notify.js",
                "~/Scripts/app/modules/now.js",
                "~/Scripts/app/modules/panel-tools.js",
                "~/Scripts/app/modules/play-animation.js",
                "~/Scripts/app/modules/porlets.js",
                "~/Scripts/app/modules/sidebar.js",
                "~/Scripts/app/modules/skycons.js",
                "~/Scripts/app/modules/slimscroll.js",
                "~/Scripts/app/modules/sparkline.js",
                "~/Scripts/app/modules/table-checkall.js",
                "~/Scripts/app/modules/toggle-state.js",
                "~/Scripts/app/modules/utils.js",
                "~/Scripts/app/modules/chart.js",
                "~/Scripts/app/modules/morris.js",
                "~/Scripts/app/modules/rickshaw.js",
                "~/Scripts/app/modules/chartist.js",
                "~/Scripts/app/modules/tour.js",
                "~/Scripts/app/modules/color-picker.js",
                "~/Scripts/app/modules/imagecrop.js",
                "~/Scripts/app/modules/chart-knob.js",
                "~/Scripts/app/modules/chart-easypie.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryValidate").Include(
              "~/Scripts/jquery.validate.js"
            ));

            bundles.Add(new StyleBundle("~/bundles/SweetAlert").Include(
                "~/Scripts/app/modules/sweetalert.min.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/jquerySteps").Include(
              "~/Scripts/app/modules/jquery.steps.js"
            ));

       
            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/matchMedia").Include(
                    "~/Scripts/matchMedia/matchMedia.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/moment").Include(
              "~/Scripts/app/modules/moment-with-locales.min.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/storage").Include(
              "~/Scripts/jQuery-Storage-API/jquery.storageapi.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryEasing").Include(
              "~/Scripts/jquery.easing/jquery.easing.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/select2").Include(
              "~/Scripts/app/modules/select2.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/gmap").Include(
                "~/Scripts/app/modules/jquery.gmap.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/datetimePicker").Include(
              "~/Scripts/app/modules/bootstrap-datetimepicker.min.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/ColorPicker").Include(
              "~/Scripts/app/modules/bootstrap-colorpicker.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/jqGrid").Include(
                "~/Scripts/app/modules/jqGrid/jquery.jqGrid.js",
                "~/Scripts/app/modules/jqGrid/i18n/grid.locale-en.js"
            ));

            bundles.Add(new StyleBundle("~/bundles/datetimePickerCss").Include(
                "~/Content/app/css/bootstrap-datetimepicker.min.css"
            ));

            bundles.Add(new StyleBundle("~/bundles/ColorPickerCss").Include(
                "~/Content/app/css/bootstrap-colorpicker.css"
            ));

            bundles.Add(new StyleBundle("~/bundles/select2Css").Include(
              "~/Content/app/css/select2.css",
              "~/Content/app/css/select2-bootstrap.css"
            ));

            bundles.Add(new StyleBundle("~/bundles/animatecss").Include(
              "~/Content/app/css/animate.min.css"
            ));
                      
            bundles.Add(new StyleBundle("~/bundles/fontawesome").Include(
              "~/Content/fontAwesome/css/font-awesome.min.css", new CssRewriteUrlTransform()
            ));

            bundles.Add(new StyleBundle("~/bundles/simpleLineIcons").Include(
              "~/Content/simple-line-icons/css/simple-line-icons.css", new CssRewriteUrlTransform()
            ));

            bundles.Add(new StyleBundle("~/bundles/jqGridCss").Include(
                "~/Content/app/css/ui.jqgrid.css",
                "~/Content/app/css/jquery-ui.css"
            ));

            bundles.Add(new StyleBundle("~/bundles/SweetAlertCss").Include(
                "~/Content/app/css/sweetalert.css"
            ));
        }
    }
}
