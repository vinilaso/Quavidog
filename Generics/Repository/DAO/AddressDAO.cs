using Commons.Interfaces;
using Generics.Entities;
using Generics.Repository.DB;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics.Repository.DAO
{
    public class AddressDAO
    {
        public static void Add(IAddress address)
        {
            using (var conn = new SqlConnection(DBConnection.Connect()))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO ADDRESSES (CEP, STREET, NUMBER, NEIGHBORHOOD, CITY) " +
                    "VALUES (@CEP, @STREET, @NUMBER, @NEIGHBORHOOD, @CITY);";

                cmd.Parameters.AddWithValue("@CEP", address.Cep);
                cmd.Parameters.AddWithValue("@STREET", address.Street);
                cmd.Parameters.AddWithValue("@NUMBER", address.Number);
                cmd.Parameters.AddWithValue("@NEIGHBORHOOD", address.Neighborhood);
                cmd.Parameters.AddWithValue("@CITY", address.City);

                cmd.ExecuteNonQuery();
            }
        }

        public static IAddress ReadOne(int id)
        {
            IAddress result = null;
            using (var conn = new SqlConnection(DBConnection.Connect()))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT ID, CEP, STREET, NUMBER, NEIGHBORHOOD, CITY FROM ADDRESSES " +
                    "WHERE ID = @ID;";

                cmd.Parameters.AddWithValue("@ID", id);
                using(var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        result = new Address()
                        {
                            Id = (int)reader["ID"],
                            Cep = (string)reader["CEP"],
                            Street = (string)reader["STREET"],
                            Number = (string)reader["NUMBER"],
                            Neighborhood = (string)reader["NEIGHBORHOOD"],
                            City = (string)reader["CITY"]
                        };
                    }
                }
            }
            return result;
        }

        public static List<IAddress> ReadAll()
        {
            var result = new List<IAddress>();
            using(var conn = new SqlConnection(DBConnection.Connect()))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT ID, CEP, STREET, NUMBER, NEIGHBORHOOD, CITY FROM ADDRESSES;";
                
                using(var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(new Address()
                        {
                            Id = (int)reader["ID"],
                            Cep = (string)reader["CEP"],
                            Street = (string)reader["STREET"],
                            Number = (string)reader["NUMBER"],
                            Neighborhood = (string)reader["NEIGHBORHOOD"],
                            City = (string)reader["CITY"]
                        });
                    }
                }
                return result;
            }
        }

        public static void Update(IAddress newAddress)
        {
            using(var conn = new SqlConnection(DBConnection.Connect()))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE ADDRESSES SET CEP = @CEP, STREET = @STREET, NUMBER = @NUMBER, " +
                    "NEIGHBORHOOD = @NEIGHBORHOOD, CITY = @CITY WHERE ID = @ID;";

                cmd.Parameters.AddWithValue("@CEP", newAddress.Cep);
                cmd.Parameters.AddWithValue("@STREET", newAddress.Street);
                cmd.Parameters.AddWithValue("@NUMBER", newAddress.Number);
                cmd.Parameters.AddWithValue("@NEIGHBORHOOD", newAddress.Neighborhood);
                cmd.Parameters.AddWithValue("@CITY", newAddress.City);
                cmd.Parameters.AddWithValue("@ID", newAddress.Id);

                cmd.ExecuteNonQuery();
            }
        }

        public static void Delete(int id)
        {
            using(var conn = new SqlConnection(DBConnection.Connect()))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM ADDRESSES WHERE ID = @ID;";

                cmd.Parameters.AddWithValue("@ID", id);

                cmd.ExecuteNonQuery();
            }
        }
    }
}
