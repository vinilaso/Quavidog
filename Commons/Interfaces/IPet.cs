using Commons.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commons.Interfaces
{
    public interface IPet
    {
        public int Id { get; set; }
        public IUser Owner { get; set; }
        public string Name { get; set; }
        public PetSize Size { get; set; }
        public Breed Breed { get; set; }
        public byte[]? Media { get; set; }
        public string? MediaName { get; set; }
    }
}
