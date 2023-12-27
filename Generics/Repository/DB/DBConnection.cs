using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics.Repository.DB
{
    public class DBConnection
    {
        public static string Connect()
        {
            return File.ReadAllText("../Generics/Repository/DB/ConnectionString.txt");
        }
    }
}
