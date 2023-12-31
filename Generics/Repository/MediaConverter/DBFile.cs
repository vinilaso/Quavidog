using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics.Repository.MediaConverter
{
    public class DBFile
    {
        public string Name { get; set; } = string.Empty;
        public byte[] Data { get; set; } = new byte[0];
    }
}

