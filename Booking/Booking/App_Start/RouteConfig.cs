using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace Booking.App_Start
{
    public static class RouteConfig
    {
        public static void RegisterRoutes (RouteCollection routes)
        {
            //skicka med namn, url, fysiskfil(webbformuläret)
            routes.MapPageRoute("CustomerCreate",
                "kund/ny",
                "~/Create.aspx");

            routes.MapPageRoute("Default",
                "",
                "~/Default.aspx");

        }
    }
}