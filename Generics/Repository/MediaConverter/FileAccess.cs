using Generics.Repository.DB;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics.Repository.MediaConverter
{
    public class FileAccess
    {
        string _Table;
        string _Column;
        long _Id;

        public FileAccess(string table, string column, long id)
        {
            if (table == null || column == null || id <= 0)
            {
                throw new ArgumentNullException("Inicialização inválida do componente!");
            }

            _Table = table;
            _Column = column;
            _Id = id;
        }

        public DBFile GetFile()
        {
            using (SqlConnection conn = new(DBConnection.Connect()))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = $"SELECT {_Column}, {_Column}NAME FROM {_Table} WHERE ID = @ID";
                cmd.Parameters.Add(new SqlParameter("@ID", _Id));

                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    var file = new DBFile()
                    {
                        Name = reader.GetString(1),
                        Data = (byte[])reader[_Column],
                    };

                    return file;
                }
                else
                {
                    throw new Exception("Arquivo não encontrado!");
                }
            }
        }
    }
}
