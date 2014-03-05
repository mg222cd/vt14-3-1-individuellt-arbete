using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

            //skapa anslutningsobjekt
            using (var conn = new SqlConnection(connectionString))
            {
                //ungefärlig storlek på listobjektet
                var customers = new List<Customer>(100);

                //kommando för att exec lagrad procedur
                var cmd = new SqlCommand("usp_GetCustomers", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                //öppna anslutningen (vill man göra så sent som möjligt)
                conn.Open();

                using(var reader = cmd.ExecuteReader())
                {
                    //läs post för post
                    while (reader.Read())
                    {
                        
                    }


                }

                customers.TrimExcess();

                return customers;
            }
        }
    }
}