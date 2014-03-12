using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Booking.Model.DAL
{
    public class BookingDAL
    {
        #region Fält

        //anslutningssträng
        private static readonly string _connectionString;

        #endregion

        #region Konstruktorer

        static BookingDAL() 
        {
            //Hämtar anslutningssträng
            _connectionString = WebConfigurationManager.ConnectionStrings["BookingConnectionString"].ConnectionString;
        }

        #endregion

        #region Privata hjälpmetoder

        //skapar anslutningsobjekt och returnerar ref till SQL-objektet
        private static SqlConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }

        #endregion

        #region CRUD-metoder

        //Metod hämtar lista med obokade veckor - Stuga 1
        public IEnumerable<Booking> GetUnbookedWeeksProp1()
        {
            //anslutningsobjekt
            using (var conn = CreateConnection())
            {
                try
                {
                    //skapa lista
                    var unbookedProperty1 = new List<Booking>(100);

                    //exec lagrad procedur
                    var cmd = new SqlCommand("[dbo].[usp_GetUnbookedNo1]", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    //öppna anslutning
                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        //returnerar heltal med index
                        var bookingIdIndex = reader.GetOrdinal("BookingID");
                        var customerIdIndex = reader.GetOrdinal("CustomerID");
                        var propertyIdIndex = reader.GetOrdinal("PropertyID");
                        var weekIndex = reader.GetOrdinal("Week");
                        var yearIndex = reader.GetOrdinal("Year");
                        var priceIndex = reader.GetOrdinal("Price");
                        var cleaningIndex = reader.GetOrdinal("Cleaning");

                        //läs så länge Read returnerar true
                        while (reader.Read())
                        {
                            //samlingsobjekt av typen List
                            unbookedProperty1.Add(new Booking
                            {
                                //varje post översätts till C#-Bookingobjekt
                                BookingID = reader.GetInt32(bookingIdIndex),
                                CustomerID = reader.GetInt32(customerIdIndex),
                                PropertyID = reader.GetInt32(propertyIdIndex),
                                Week = reader.GetInt32(weekIndex),
                                Year = reader.GetInt32(yearIndex),
                                Price = reader.GetInt32(priceIndex),
                                Cleaning = reader.GetBoolean(cleaningIndex)
                            });
                        }
                    }

                    //SIST trimma och returnera
                    unbookedProperty1.TrimExcess();
                    return unbookedProperty1;
                }     
                catch
                {

                    throw new ApplicationException("Fel uppstod i samband med hämtning obokade veckor - stuga 1");
                }
            }
        }

        //Metod hämtar lista med obokade veckor Stuga 2
        public IEnumerable<Booking> GetUnbookedWeeksProp1()
        {
            //anslutningsobjekt
            using (var conn = CreateConnection())
            {
                try
                {
                    //skapa lista
                    var unbookedProperty1 = new List<Booking>(100);

                    //exec lagrad procedur
                    var cmd = new SqlCommand("[dbo].[usp_GetUnbookedNo2]", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    //öppna anslutning
                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        //returnerar heltal med index
                        var bookingIdIndex = reader.GetOrdinal("BookingID");
                        var customerIdIndex = reader.GetOrdinal("CustomerID");
                        var propertyIdIndex = reader.GetOrdinal("PropertyID");
                        var weekIndex = reader.GetOrdinal("Week");
                        var yearIndex = reader.GetOrdinal("Year");
                        var priceIndex = reader.GetOrdinal("Price");
                        var cleaningIndex = reader.GetOrdinal("Cleaning");

                        //läs så länge Read returnerar true
                        while (reader.Read())
                        {
                            //samlingsobjekt av typen List
                            unbookedProperty1.Add(new Booking
                            {
                                //varje post översätts till C#-Bookingobjekt
                                BookingID = reader.GetInt32(bookingIdIndex),
                                CustomerID = reader.GetInt32(customerIdIndex),
                                PropertyID = reader.GetInt32(propertyIdIndex),
                                Week = reader.GetInt32(weekIndex),
                                Year = reader.GetInt32(yearIndex),
                                Price = reader.GetInt32(priceIndex),
                                Cleaning = reader.GetBoolean(cleaningIndex)
                            });
                        }
                    }

                    //SIST trimma och returnera
                    unbookedProperty1.TrimExcess();
                    return unbookedProperty1;
                }
                catch
                {

                    throw new ApplicationException("Fel uppstod i samband med hämtning obokade veckor - stuga 2");
                }
            }
        }

        #endregion
    }
}