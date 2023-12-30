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
    public class PetDAO
    {
        public static void Add(IPet pet)
        {
            using(var conn = new SqlConnection(DBConnection.Connect()))
            {
                conn.Open();
                var cmd = conn.CreateCommand();

                var media = (pet.Media != null) ? ", MEDIA, MEDIA_NAME" : string.Empty;
                var mediaValue = (pet.Media != null) ? ", @MEDIA, @MEDIA_NAME" : string.Empty;
                cmd.CommandText = $"INSERT INTO PETS (OWNER, NAME, SIZE, BREED{media}) VALUES (@OWNER, @NAME, @SIZE, @BREED{mediaValue});";

                cmd.Parameters.AddWithValue("@OWNER", pet.Owner.Id);
                cmd.Parameters.AddWithValue("@NAME", pet.Name);
                cmd.Parameters.AddWithValue("@SIZE", (int) pet.Size);
                cmd.Parameters.AddWithValue("@BREED", (int) pet.Breed);

                if(pet.Media != null)
                {
                    cmd.Parameters.AddWithValue("@MEDIA", pet.Media);
                    cmd.Parameters.AddWithValue("@MEDIA_NAME", pet.MediaName);
                }

                cmd.ExecuteNonQuery();
            }
        }

        public static IPet ReadOne(int id)
        {
            IPet result = new Pet();
            using(var conn = new SqlConnection(DBConnection.Connect()))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT ID, OWNER, NAME, SIZE, BREED, MEDIA, MEDIA_NAME FROM PETS WHERE ID = @ID;";

                cmd.Parameters.AddWithValue("@ID", id);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        result = new Pet()
                        {
                            Id = (int)reader["ID"],
                            Owner = UserDAO.ReadOne((int)reader["OWNER"]),
                            Name = (string)reader["NAME"],
                            Size = (PetSize)reader["SIZE"],
                            Breed = (Breed)reader["BREED"],
                            Media = (reader["MEDIA"] != DBNull.Value) ? (byte[])reader["MEDIA"] : null,
                            MediaName = (reader["MEDIA_NAME"] != DBNull.Value) ? (string)reader["MEDIA_NAME"] : null
                        };
                    }
                }
            }
            return result;
        }

        public static List<IPet> ReadAllByUser(string cpf)
        {
            var result = new List<IPet>();
            using(var conn = new SqlConnection(DBConnection.Connect()))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT ID, OWNER, NAME, SIZE, BREED, MEDIA, MEDIA_NAME FROM PETS WHERE OWNER = @OWNER;";

                var owner = UserDAO.ReadOne(cpf);
                cmd.Parameters.AddWithValue("@OWNER", owner.Id);

                using(var reader = cmd.ExecuteReader()) 
                {
                    while (reader.Read())
                    {
                        result.Add(new Pet()
                        {
                            Id = (int)reader["ID"],
                            Owner = UserDAO.ReadOne((int)reader["OWNER"]),
                            Name = (string)reader["NAME"],
                            Size = (PetSize)reader["SIZE"],
                            Breed = (Breed)reader["BREED"],
                            Media = (reader["MEDIA"] != DBNull.Value) ? (byte[])reader["MEDIA"] : null,
                            MediaName = (reader["MEDIA_NAME"] != DBNull.Value) ? (string)reader["MEDIA_NAME"] : null
                        });
                    }
                }
            }
            return result;
        }

        public static List<IPet> ReadAll()
        {
            var result = new List<IPet>();
            using (var conn = new SqlConnection(DBConnection.Connect()))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT ID, OWNER, NAME, SIZE, BREED, MEDIA, MEDIA_NAME FROM PETS;";

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(new Pet()
                        {
                            Id = (int)reader["ID"],
                            Owner = UserDAO.ReadOne((int)reader["OWNER"]),
                            Name = (string)reader["NAME"],
                            Size = (PetSize)reader["SIZE"],
                            Breed = (Breed)reader["BREED"],
                            Media = (reader["MEDIA"] != DBNull.Value) ? (byte[])reader["MEDIA"] : null,
                            MediaName = (reader["MEDIA_NAME"] != DBNull.Value) ? (string)reader["MEDIA_NAME"] : null
                        });
                    }
                }
            }
            return result;
        }

        public static void Update(IPet newPet)
        {
            using(var conn = new SqlConnection(DBConnection.Connect()))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE PETS SET NAME = @NAME, SIZE = @SIZE, BREED = @BREED WHERE ID = @ID;";

                cmd.Parameters.AddWithValue("@NAME", newPet.Name);
                cmd.Parameters.AddWithValue("@SIZE", (int) newPet.Size);
                cmd.Parameters.AddWithValue("@BREED", (int) newPet.Breed);
                cmd.Parameters.AddWithValue("@ID", newPet.Id);

                cmd.ExecuteNonQuery();
            }
        }

        public static void UpdatePicture(byte[] media, string mediaName, int id)
        {
            using(var conn = new SqlConnection(DBConnection.Connect()))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE PETS SET MEDIA = @MEDIA, MEDIA_NAME = @MEDIA_NAME WHERE ID = @ID;";

                cmd.Parameters.AddWithValue("@MEDIA", media);
                cmd.Parameters.AddWithValue("@MEDIA_NAME", mediaName);
                cmd.Parameters.AddWithValue("@ID", id);

                cmd.ExecuteNonQuery();
            }
        }

        public static void Delete(int id)
        {
            using(var conn = new SqlConnection(DBConnection.Connect()))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM PETS WHERE ID = @ID;";

                cmd.Parameters.AddWithValue("@ID", id);

                cmd.ExecuteNonQuery();
            }
        }
    }
}
