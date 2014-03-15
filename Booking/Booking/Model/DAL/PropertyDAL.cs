using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Data;

namespace Booking.Model.DAL
{
    public class PropertyDAL
    {
         #region Fält
        
        //anslutningssträng som tillhör klassen.
        private static readonly string _connectionString;

        #endregion
        
        #region Konstruktorer

        static PropertyDAL()
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

        public IEnumerable<Property> GetProperties()
        {
            //skapa anslutningsobj
            using (var conn = CreateConnection())
            {
                try
                {
                    //skapa lista
                    var properties = new List<Property>(100);

                    //kommand för lagrad procedur
                    var cmd = new SqlCommand("[appSchema].[usp_GetProperties]", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    //Öppna anslutning till databas
                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        //hämtar index:
                        var propertyIdIndex = reader.GetOrdinal("PropertyID");
                        var propertyNameIndex = reader.GetOrdinal("PropertyName");

                        //läs post för post, så länge Read returnerar True
                        while (reader.Read())
                        {
                            //samlingsobjekt
                            properties.Add(new Property
                            {
                                PropertyID = reader.GetInt32(propertyIdIndex),
                                PropertyName = reader.GetString(propertyNameIndex)
                            });
                        }
                    }
                    //trimma ner och returnera lista
                    properties.TrimExcess();
                    return properties;
                }
                catch
                {
                    
                    throw new ApplicationException("Fel uppstod vid hämtning av stugor från databasen");
                }
            }
        }

        //public Customer GetCustomerById(int customerId)
        //{
        //    //skapa och initiera anslutningsobjekt
        //    using (var conn = CreateConnection())
        //    {
        //        try
        //        {
        //            //kommando för att exec lagrad procedur
        //            var cmd = new SqlCommand("[appSchema].[usp_GetCustomerById]", conn);
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            //skickar med kundId till lagrade proceduren
        //            cmd.Parameters.Add("@CustomerID", SqlDbType.Int, 4).Value = customerId;

        //            //öppna anslutning till databasen
        //            conn.Open();

        //            using (var reader = cmd.ExecuteReader())
        //            {
        //                var customerIdIndex = reader.GetOrdinal("CustomerId"); //returnerar heltal (med index tror jag)
        //                var nameIndex = reader.GetOrdinal("Name"); //efterfrågas kolumn med namn som ej existerar kastas ett undantag
        //                var addressIndex = reader.GetOrdinal("address");
        //                var postalIndex = reader.GetOrdinal("postal");
        //                var cityIndex = reader.GetOrdinal("city");
        //                var phoneIndex = reader.GetOrdinal("Phone");
        //                var emailIndex = reader.GetOrdinal("Email");

        //                if (reader.Read())
        //                {
        //                    return new Customer
        //                    {
        //                        CustomerID = reader.GetInt32(customerIdIndex), //översätts till ett C#-objekt av typen Customer
        //                        Name = reader.GetString(nameIndex),
        //                        Address = reader.GetString(addressIndex),
        //                        Postal = reader.GetString(postalIndex),
        //                        City = reader.GetString(cityIndex),
        //                        Phone = reader.GetString(phoneIndex),
        //                        Email = reader.GetString(phoneIndex)
        //                    };
        //                }
        //                return null;
        //            }
        //        }
        //        catch
        //        {
        //            throw new ApplicationException("Fel uppstod i samband med hämtning av kunder från databasen");
        //        }
        //    }
        //}

        //public void InsertCustomer(Customer customer)
        //{
        //    using (SqlConnection conn = CreateConnection())
        //    {
        //        try
        //        {
        //            //skapar och initierar Sql-objekt som kör lagrade proceduren
        //            SqlCommand cmd = new SqlCommand("[appSchema].[usp_InsertCustomer]", conn);
        //            cmd.CommandType = CommandType.StoredProcedure;

        //            //lägger till parametrar
        //            cmd.Parameters.Add("@Name", SqlDbType.VarChar, 40).Value = customer.Name;
        //            cmd.Parameters.Add("@Address", SqlDbType.VarChar, 40).Value = customer.Address;
        //            cmd.Parameters.Add("@Postal", SqlDbType.Int, 4).Value = customer.Postal;
        //            cmd.Parameters.Add("@City", SqlDbType.VarChar, 25).Value = customer.City;
        //            cmd.Parameters.Add("@Phone", SqlDbType.VarChar, 20).Value = customer.Phone;
        //            cmd.Parameters.Add("@Email", SqlDbType.VarChar, 50).Value = customer.Email;

        //            //parameter som tar emot värde från lagrade proceduren (i detta fall med nya postens customerId)
        //            cmd.Parameters.Add("@CustomerId", SqlDbType.Int, 4).Direction = ParameterDirection.Output;

        //            //öppnar anslutning till databasen
        //            conn.Open();

        //            //exec
        //            cmd.ExecuteNonQuery();

        //            //metod för att exec lagrade proceduren
        //            customer.CustomerID = (int)cmd.Parameters["@CustomerId"].Value;

        //        }
        //        catch
        //        {
        //            throw new ApplicationException("Fel uppstod då kund skulle infogas.");
        //        }
        //    }
        //}

        //public void UpdateCustomer(Customer customer)
        //{
        //    using (SqlConnection conn = CreateConnection())
        //    {
        //        try
        //        {
        //            //lagrad procedur
        //            SqlCommand cmd = new SqlCommand("[appSchema].[usp_UpdateCustomer]", conn);
        //            cmd.CommandType = CommandType.StoredProcedure;

        //            //lägger till parametrar
        //            cmd.Parameters.Add("@CustomerID", SqlDbType.Int, 4).Value = customer.CustomerID;
        //            cmd.Parameters.Add("@Name", SqlDbType.VarChar, 40).Value = customer.Name;
        //            cmd.Parameters.Add("@Address", SqlDbType.VarChar, 40).Value = customer.Address;
        //            cmd.Parameters.Add("@Postal", SqlDbType.VarChar, 6).Value = customer.Postal;
        //            cmd.Parameters.Add("@City", SqlDbType.VarChar, 25).Value = customer.City;
        //            cmd.Parameters.Add("@Phone", SqlDbType.VarChar, 20).Value = customer.Phone;
        //            cmd.Parameters.Add("@Email", SqlDbType.VarChar, 50).Value = customer.Email;

        //            //öppnar anslutning
        //            conn.Open();

        //            //exekverar den lagrade proceduren
        //            cmd.ExecuteNonQuery();
        //        }
        //        catch
        //        {
        //            throw new ApplicationException("Fel uppstod när kund skulle uppdateras");
        //        }
                
        //    }
        //}

        //public void DeleteCustomer(int customerId)
        //{
        //    using (SqlConnection conn = CreateConnection())
        //    {
        //        try
        //        {
        //            //lagrad procedur
        //            SqlCommand cmd = new SqlCommand("[appSchema].[usp_DeleteCustomer]", conn);
        //            cmd.CommandType = CommandType.StoredProcedure;

        //            //lägger till parameter den lagrade proceduren kräver
        //            cmd.Parameters.Add("@CustomerID", SqlDbType.Int, 4).Value = customerId;

        //            //öppnar anslutning
        //            conn.Open();

        //            //exekverar den lagrade proceduren
        //            cmd.ExecuteNonQuery();
        //        }
        //        catch (Exception)
        //        {

        //            throw new ApplicationException("Fel uppstod då kund skulle raderas");
        //        }
        //    }
        //}


        #endregion
    }
}