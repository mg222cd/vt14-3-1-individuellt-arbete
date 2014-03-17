using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Booking.Model
{
    public class Booking
    {
        //Egenskaper som motsvarar kolumner i tabellen

        public int BookingID { get; set; }

        public int CustomerID { get; set; }

        public int PropertyID { get; set; }

        public int Week { get; set; }

        public int Year { get; set; }

        public int Price { get; set; }
    }
}