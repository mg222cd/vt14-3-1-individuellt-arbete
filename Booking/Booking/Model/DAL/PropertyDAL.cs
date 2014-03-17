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

        public Property GetPropertyById(int propertyId)
        {
            //skapa och initiera anslutningsobjekt
            using (var conn = CreateConnection())
            {
                try
                {
                    //kommando för att exec lagrad procedur
                    var cmd = new SqlCommand("[appSchema].[usp_GetPropertyById]", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    //skickar med kundId till lagrade proceduren
                    cmd.Parameters.Add("@PropertyID", SqlDbType.Int, 4).Value = propertyId;

                    //öppna anslutning till databasen
                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        //hämta index
                        var propertyIdIndex = reader.GetOrdinal("PropertyID"); 
                        var propertyNameIndex = reader.GetOrdinal("PropertyName"); 

                        if (reader.Read())
                        {
                            return new Property
                            {
                                //lägger till värdet från databasen i objektegenskaperna
                                PropertyID = reader.GetInt32(propertyIdIndex),
                                PropertyName = reader.GetString(propertyNameIndex)
                            };
                        }
                        return null;
                    }
                }
                catch
                {
                    throw new ApplicationException("Fel uppstod i samband med hämtning av kunder från databasen");
                }
            }
        }

        #endregion
    }
}