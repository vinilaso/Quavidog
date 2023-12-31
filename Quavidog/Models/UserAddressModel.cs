namespace Quavidog.Models
{
    public class UserAddressModel
    {
        public UserModel UserModel { get; set; } = new UserModel();
        public AddressModel AddressModel { get; set; } = new AddressModel();
    }
}
