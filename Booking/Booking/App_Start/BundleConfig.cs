using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace Booking.App_Start
{
    public class BundleConfig
    {
       public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-*"
                ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content.reset.css",
                "~/Content.site.css"
                ));
        }
    }
}