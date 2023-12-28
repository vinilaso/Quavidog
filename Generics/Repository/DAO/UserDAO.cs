using Commons.Enums;
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
    public class UserDAO
    {
        public static void Add(IUser user)
        {
            using(var conn = new SqlConnection(DBConnection.Connect()))
            {
                conn.Open();
                var cmd = conn.CreateCommand();

                string media = (user.Media != null) ? " MEDIA, MEDIA_NAME," : string.Empty;
                string mediaValues = (user.Media != null) ? " @MEDIA, @MEDIA_NAME, " : string.Empty;

                cmd.CommandText = $"INSERT INTO USERS (ADDRESS_ID, NAME, PHONE, EMAIL, CPF, {media} PASSWORD, ACCESS_TYPE) " +
                    $"VALUES (@ADDRESS_ID, @NAME, @PHONE, @EMAIL, @CPF, {mediaValues} @PASSWORD, @ACCESS_TYPE);";

                cmd.Parameters.AddWithValue("@ADDRESS_ID", user.Address.Id);
                cmd.Parameters.AddWithValue("@NAME", user.Name);
                cmd.Parameters.AddWithValue("@PHONE", user.Phone);
                cmd.Parameters.AddWithValue("@EMAIL", user.Email);
                cmd.Parameters.AddWithValue("@CPF", user.Cpf);
                cmd.Parameters.AddWithValue("@PASSWORD", user.Password);
                cmd.Parameters.AddWithValue("@ACCESS_TYPE", user.AccessType);

                if(user.Media != null)
                {
                    cmd.Parameters.AddWithValue("@MEDIA", user.Media);
                    cmd.Parameters.AddWithValue("@MEDIA_NAME", user.MediaName);
                }
                cmd.ExecuteNonQuery();
            }
        }

        public static IUser ReadOneByCpf(string cpf)
        {
            var result = new User();
            using(var conn = new SqlConnection(DBConnection.Connect()))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT ID, ADDRESS_ID, NAME, PHONE, EMAIL, CPF, MEDIA, MEDIA_NAME, PASSWORD, ACCESS_TYPE " +
                    "FROM USERS WHERE CPF = @CPF;";

                cmd.Parameters.AddWithValue("@CPF", cpf);

                using(var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        result = new User()
                        {
                            Id = (int)reader["ID"],
                            Address = AddressDAO.ReadOne((int)reader["ADDRESS_ID"]),
                            Name = (string)reader["NAME"],
                            Phone = (string)reader["PHONE"],
                            Email = (string)reader["EMAIL"],
                            Cpf = (string)reader["CPF"],
                            Password = (string)reader["PASSWORD"],
                            AccessType = (AccessType)reader["ACCESS_TYPE"],
                            Media = (reader["MEDIA"] != DBNull.Value) ? (byte[])reader["MEDIA"] : null,
                            MediaName = (reader["MEDIA_NAME"] != DBNull.Value) ? (string)reader["MEDIA_NAME"] : null
                        };
                    }
                }
            }
            return result;
        }

        public static IUser ReadOneById(int id)
        {
            var result = new User();
            using(var conn = new SqlConnection(DBConnection.Connect()))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT ID, ADDRESS_ID, NAME, PHONE, EMAIL, CPF, MEDIA, MEDIA_NAME, PASSWORD, ACCESS_TYPE " +
                    "FROM USERS WHERE ID = @ID;";

                cmd.Parameters.AddWithValue("@ID", id);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        result = new User()
                        {
                            Id = (int)reader["ID"],
                            Address = AddressDAO.ReadOne((int)reader["ADDRESS_ID"]),
                            Name = (string)reader["NAME"],
                            Phone = (string)reader["PHONE"],
                            Email = (string)reader["EMAIL"],
                            Cpf = (string)reader["CPF"],
                            Password = (string)reader["PASSWORD"],
                            AccessType = (AccessType)reader["ACCESS_TYPE"],
                            Media = (reader["MEDIA"] != DBNull.Value) ? (byte[])reader["MEDIA"] : null,
                            MediaName = (reader["MEDIA_NAME"] != DBNull.Value) ? (string)reader["MEDIA_NAME"] : null
                        };
                    }
                }
            }
            return result;
        }

        public static List<IUser> ReadAll()
        {
            var result = new List<IUser>();
            using(var conn = new SqlConnection(DBConnection.Connect()))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT ID, ADDRESS_ID, NAME, PHONE, EMAIL, CPF, MEDIA, MEDIA_NAME, PASSWORD, ACCESS_TYPE FROM USERS;";

                using(var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(new User()
                        {
                            Id = (int)reader["ID"],
                            Address = AddressDAO.ReadOne((int)reader["ADDRESS_ID"]),
                            Name = (string)reader["NAME"],
                            Phone = (string)reader["PHONE"],
                            Email = (string)reader["EMAIL"],
                            Cpf = (string)reader["CPF"],
                            Password = (string)reader["PASSWORD"],
                            AccessType = (AccessType)reader["ACCESS_TYPE"],
                            Media = (reader["MEDIA"] != DBNull.Value) ? (byte[])reader["MEDIA"] : null,
                            MediaName = (reader["MEDIA_NAME"] != DBNull.Value) ? (string)reader["MEDIA_NAME"] : null
                        });
                    }
                }
            }
            return result;
        }

        public static void Update(IUser newUser)
        {
            using(var conn = new SqlConnection(DBConnection.Connect()))
            {
                conn.Open();
                var cmd = conn.CreateCommand();

                string media = (newUser.Media != null) ? ", MEDIA = @MEDIA, MEDIA_NAME = @MEDIA_NAME" : string.Empty;
                cmd.CommandText = $"UPDATE USERS SET NAME = @NAME, PHONE = @PHONE, EMAIL = @EMAIL{media} " +
                    "WHERE CPF = @CPF;";

                cmd.Parameters.AddWithValue("@NAME", newUser.Name);
                cmd.Parameters.AddWithValue("@PHONE", newUser.Phone);
                cmd.Parameters.AddWithValue("@EMAIL", newUser.Email);
                cmd.Parameters.AddWithValue("@CPF", newUser.Cpf);

                if(newUser.Media != null)
                {
                    cmd.Parameters.AddWithValue("@MEDIA", newUser.Media);
                    cmd.Parameters.AddWithValue("@MEDIA_NAME", newUser.MediaName);
                }

                cmd.ExecuteNonQuery();
            }
        }

        public static void Delete(string cpf)
        {
            using(var conn = new SqlConnection(DBConnection.Connect()))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM USERS WHERE CPF = @CPF";

                cmd.Parameters.AddWithValue("@CPF", cpf);

                cmd.ExecuteNonQuery();
            }
        }
    }
}
