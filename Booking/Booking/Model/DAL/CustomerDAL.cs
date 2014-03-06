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

        #region Fält
        
        //anslutningssträng som tillhör klassen.
        private static readonly string _connectionString;

        #endregion
        
        #region Konstruktorer

        static CustomerDAL()
        {
            //hämtar anslutningssträngen från webconfig
            _connectionString = WebConfigurationManager.ConnectionStrings["BookingConnectionString"].ConnectionString;
        }

        #endregion

        #region Privata hjälpmetoder

        //skapar och instansierar nytt anslutningsobjekt
        //returnerar ref till SQL-objektet
        private static SqlConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }

        #endregion

        #region CRUD-metoder

        /// <summary>
        /// Hämtar alla kunder ur Customer
        /// </summary>
        /// <returns>samling med ref till Customer-objektet</returns>
        public IEnumerable<Customer> GetCustomers()
        {
            //skapa och initiera anslutningsobjekt
            using (var conn = CreateConnection())
            {
                try
                {
                    //skapar lista (man bör veta ungefärlig storlek)
                    var customers = new List<Customer>(100);

                    //kommando för att exec lagrad procedur
                    var cmd = new SqlCommand("[appSchema].[usp_GetCustomers]", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (var reader = cmd.ExecuteReader())
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
                catch (Exception)
                {
                    throw new ApplicationException("Fel uppstod i samband med hämtning av kunder från databasen");
                }
            }
        }
        #endregion



    }
}