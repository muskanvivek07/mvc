using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
namespace TruYumMVC
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
           
            bundles.Add(
               new ScriptBundle("~/scripts/js")
                    .Include("~/Scripts/jquery-3.6.0.js")
                    .Include("~/Scripts/jquery.validate.js")
                    .Include("~/Scripts/jquery.validate.unobtrusive.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
        }
    }
}