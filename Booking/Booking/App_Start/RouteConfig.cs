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
            routes.MapPageRoute(    "Default",          "",                  "~/Pages/BookingPages/BookingListing.aspx");
            routes.MapPageRoute(    "BookingCRD",       "booking/admin",     "~/Pages/BookingPages/BookingCRD.aspx");
            routes.MapPageRoute(    "CustomerCrud",     "customer/admin",    "~/Pages/CustomerPages/CustomerCrud.aspx");
        }
    }
}