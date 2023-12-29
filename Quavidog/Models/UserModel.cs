using Commons.Enums;
using Commons.Interfaces;

namespace Quavidog.Models
{
    public class UserModel : IUser
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public IAddress Address { get; set; } = new AddressModel();
        public AccessType AccessType { get; set; }
        public byte[]? Media { get; set; }
        public string? MediaName { get; set; }
    }
}
