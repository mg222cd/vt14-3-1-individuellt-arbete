using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Booking.Model
{
    public class Customer
    {
        //Egeneskaper som motsvarar kolumner i tabellen.
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Postal { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        
    }
}