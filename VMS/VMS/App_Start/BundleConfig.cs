﻿using System.Web;
using System.Web.Optimization;

namespace VMS
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                       "~/Content/jquery.datetimepicker.css"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js",
                        "~/Scripts/jquery-ui.unobtrusive-{version}.js"));
            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
        "~/Content/themes/base/jquery.ui.core.css",
        "~/Content/themes/base/jquery.ui.datepicker.css",
        "~/Content/themes/base/jquery.ui.theme.css",
<<<<<<< HEAD
         "~/Content/themes/base/all.css",
          "~/Content/site.css"
        )); 
=======
         "~/Content/themes/base/all.css"
        ));
            bundles.Add(new ScriptBundle("~/bundles/jquery-datetimepicker").Include(
                       "~/Scripts/jquery.datetimepicker.js",
                       "~/Scripts/jquery.js"));

            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //           "~/Scripts/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.js",
            //           "~/Scripts/bootstrap-datetimepicker.min.js",
            //          "~/Scripts/respond.js"));


            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.css",
                "~/Content/justified-nav.css",
                "~/Content/bootstrap.min.css",
                "~/Content/jquery.datetimepicker.css",
                "~/Content/site.css"));

>>>>>>> b2bf09c8a783632b67fac66cc466fa2e9eea3c5e

        }
    }
}
