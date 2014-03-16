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
                    var cmd = new SqlCommand("[appSchema].[usp_GetUnbookedNo1]", conn);
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

                        /* TODO: Radera detta när vi vet att allt funkar.
                         * Booking temp = new Booking();
                        temp.BookingID = reader.GetInt32(bookingIdIndex);
                        temp.CustomerID = reader.GetInt32(customerIdIndex);
                        temp.PropertyID = reader.GetInt32(propertyIdIndex);
                        temp.Week = reader.GetInt32(weekIndex);
                        temp.Year = reader.GetInt32(yearIndex);
                        temp.Price = reader.GetInt32(priceIndex);
                        //Cleaning = reader.GetBoolean(cleaningIndex)
                         */

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
                    //TODO Varför hamnar man här när listan ska hämtas?
                    throw new ApplicationException("Fel uppstod i samband med hämtning av obokade veckor - stuga 1");
                }
            }
        }

        //Metod hämtar lista med obokade veckor Stuga 2
        public IEnumerable<Booking> GetUnbookedWeeksProp2()
        {
            //anslutningsobjekt
            using (var conn = CreateConnection())
            {
                try
                {
                    //skapa lista
                    var unbookedProperty1 = new List<Booking>(100);

                    //exec lagrad procedur
                    var cmd = new SqlCommand("[appSchema].[usp_GetUnbookedNo2]", conn);
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

        //Metod för at hämta alla bokningar
        public IEnumerable<Booking> GetAllBookings()
        {
            //anslutningsobjekt
            using (var conn = CreateConnection())
            {
                try
                {
                    //skapa lista
                    var allBookings = new List<Booking>(100);

                    //exec lagrad procedur
                    var cmd = new SqlCommand("[appSchema].[usp_GetBookings]", conn);
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
                            allBookings.Add(new Booking
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
                    allBookings.TrimExcess();
                    return allBookings;
                }
                catch
                {

                    throw new ApplicationException("Fel uppstod i samband med hämtning av alla bokningar");
                }
            }
        }

        //Metod för att hämta BookingID
        public Booking GetBookingById(int BookingID)
        {
            using (var conn = CreateConnection())
            {
                try
                {
                    //kommande för lagrad procedur
                    var cmd = new SqlCommand("[appSchema].[usp_GetBookingById]", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    //skickar med bokningsid till lagrade proceduren
                    cmd.Parameters.Add("@BookingID", SqlDbType.Int, 4).Value = BookingID;

                    //öppna databasanslutningen:
                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        //lägger till heltal med index
                        var bookingIdIndex = reader.GetOrdinal("BookingID");
                        var customerIdIndex = reader.GetOrdinal("CustomerID");
                        var propertyIdIndex = reader.GetOrdinal("PropertyID");
                        var weekIndex = reader.GetOrdinal("Week");
                        var yearIndex = reader.GetOrdinal("Year");
                        var priceIndex = reader.GetOrdinal("Price");
                        var cleaningIndex = reader.GetOrdinal("Cleaning");

                        if (reader.Read())
                        {
                            return new Booking
                            {
                                BookingID = reader.GetInt32(bookingIdIndex),
                                CustomerID = reader.GetInt32(customerIdIndex),
                                PropertyID = reader.GetInt32(propertyIdIndex),
                                Week = reader.GetInt32(weekIndex),
                                Year = reader.GetInt32(yearIndex),
                                Price = reader.GetInt32(priceIndex),
                                Cleaning = reader.GetBoolean(cleaningIndex)
                            };
                        }
                        //om id:t inte skulle finnas
                        return null;
                    }
                }
                catch
                {

                    throw new ApplicationException("Fel uppstod i samband med hämtning av bokningsid ur databasen.");
                }
                
            }
        }

        //Metod för kundbokning
        public void InsertCustomerAndUpdateBooking (int bookingId, Customer customer)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    //kommando för att köra lagrad procedur.
                    SqlCommand cmd = new SqlCommand("[appSchema].[usp_InsertCustomerAndUpdateBooking]", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    //lägger till parametrar
                    cmd.Parameters.Add("@BookingID", SqlDbType.Int, 4).Value = bookingId;
                    cmd.Parameters.Add("@Name", SqlDbType.VarChar, 40).Value = customer.Name;
                    cmd.Parameters.Add("@Address", SqlDbType.VarChar, 40).Value = customer.Address;
                    cmd.Parameters.Add("@Postal", SqlDbType.Int, 4).Value = customer.Postal;
                    cmd.Parameters.Add("@City", SqlDbType.VarChar, 25).Value = customer.City;
                    cmd.Parameters.Add("@Phone", SqlDbType.VarChar, 20).Value = customer.Phone;
                    cmd.Parameters.Add("@Email", SqlDbType.VarChar, 50).Value = customer.Email;

                    //parameter som tar emot värde från lagrade proceduren (i detta fall med nya postens customerId)
                    cmd.Parameters.Add("@CustomerId", SqlDbType.Int, 4).Direction = ParameterDirection.Output;

                    //öppnar anslutning till databasen
                    conn.Open();

                    //exec
                    cmd.ExecuteNonQuery();

                    //metod för att exec lagrade proceduren
                    customer.CustomerID = (int)cmd.Parameters["@CustomerId"].Value;

                }
                catch
                {
                    throw new ApplicationException("Fel uppstod då kund skulle infogas och bokning uppdateras.");
                }
            }
        }

        #endregion
    }
}