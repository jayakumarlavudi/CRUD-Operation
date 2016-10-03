﻿using System.Web;
using System.Web.Optimization;

namespace AutomatedTellerMachine
{
    public class BundleConfig
    {
        
        public static void RegisterBundles(BundleCollection bundles)
        { 
            bundles.Add(new ScriptBundle("~/bundles/jquery", "//ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js").Include(
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
                      "~/Content/Bootstrap-lumen.css",
                      "~/Content/site.css"));

            // Set EnableOptimizations to false for debugging.
            bundles.UseCdn = true;
            BundleTable.EnableOptimizations = true;
        }
    }
}