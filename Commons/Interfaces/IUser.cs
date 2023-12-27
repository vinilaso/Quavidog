using Commons.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commons.Interfaces
{
    public interface IUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public IAddress Address { get; set; }
        public AccessType AccessType { get; set; }
        public byte[]? Media { get; set; }
        public string? MediaName { get; set; }
    }
}
