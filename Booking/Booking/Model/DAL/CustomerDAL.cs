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
                var cmd = new SqlCommand("[appSchema].[usp_GetCustomers]", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                //öppna anslutningen (vill man göra så sent som möjligt)
                conn.Open();

                using(var reader = cmd.ExecuteReader())
                {
                    var customerIdIndex = reader.GetOrdinal("CustomerId"); //returnerar heltal (med index tror jag)
                    var nameIndex = reader.GetOrdinal("Name"); //efterfrågas kolumn med namn som ej existerar kastas ett undantag
                    var addressIndex = reader.GetOrdinal("address");
                    var postalIndex = reader.GetOrdinal("postal");
                    var cityIndex = reader.GetOrdinal("city");
                    var phoneIndex = reader.GetOrdinal("Phone");
                    var emailIndex = reader.GetOrdinal("Email");

                    //läs post för post, så länge Read returnerar True
                    while (reader.Read())
                    {
                        //samlingsobjekt av typen List
                        customers.Add(new Customer 
                        {
                            CustomerId = reader.GetInt32(customerIdIndex), //varje post översätts till ett C#-objekt av typen Customer
                            Name = reader.GetString(nameIndex),
                            Address = reader.GetString(addressIndex),
                            Postal = reader.GetInt32(postalIndex),
                            City = reader.GetString(cityIndex),
                            Phone = reader.GetString(phoneIndex),
                            Email = reader.GetString(phoneIndex)
                        });
                    }
                }

                customers.TrimExcess();

                return customers;
            }
        }
    }
}