using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Booking.Model.DAL
{
    public class CustomerDAL
    {
        public IEnumerable<Customer> GetCustomers()
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["BookingConnectionString"].ConnectionString;
        }
    }
}