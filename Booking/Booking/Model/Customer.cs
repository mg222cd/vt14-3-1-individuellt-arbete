﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Booking.Model
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Postal { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        
    }
}