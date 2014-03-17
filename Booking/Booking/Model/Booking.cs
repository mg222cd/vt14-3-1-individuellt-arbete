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

        [RegularExpression(@"^([0-5]?[0-9]|53)$", ErrorMessage = "Ogiltigt format för vecka")]
        public int Week { get; set; }

        [RegularExpression(@"^(19|20)\d{2}$", ErrorMessage = "Ogiltigt format för år")]
        public int Year { get; set; }

        [RegularExpression(@"^(?=[0-9]{3,6}$)0*[1-9][0-9]{2,5}", ErrorMessage = "Felaktigt format för pris")]
        public int Price { get; set; }
    }
}