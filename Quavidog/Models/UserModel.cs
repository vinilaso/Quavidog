using Commons.Enums;
using Commons.Interfaces;

namespace Quavidog.Models
{
    public class UserModel : IUser
    {
        #region Attributes
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
        #endregion

        #region Constructors
        public UserModel() { }
        public UserModel(UserAddressModel model)
        {
            Name = model.UserModel.Name;
            Cpf = model.UserModel.Cpf;
            Password = model.UserModel.Password;
            Email = model.UserModel.Email;
            Phone = model.UserModel.Phone;
            Media = model.UserModel.Media;
            MediaName = model.UserModel.MediaName;
        }
        #endregion

    }
}
