using Booking.Model.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Booking.Model
{
    //Serviceklass som "pratar med " dataåtkomstklassen
    public class Service
    {
        private CustomerDAL _customerDAL;

        private CustomerDAL CustomerDAL
        {
            get { return _customerDAL ?? (_customerDAL = new CustomerDAL()); }
        }

        public IEnumerable<Customer> GetCustomers()
        {

        }
    }
}