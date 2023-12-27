using Commons.Interfaces;
using Generics.Entities;

namespace Quavidog.Models
{
    public class AddressModel : IAddress
    {
        #region Attributes
        public int Id { get; set; }
        public string Cep { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Neighborhood { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public string Number { get; set; } = string.Empty;
        #endregion

        #region Constructors
        public AddressModel(IAddress address)
        {
            Id = address.Id;
            Cep = address.Cep;
            City = address.City;
            Neighborhood = address.Neighborhood;
            Street = address.Street;
            Number = address.Number;
        }
        #endregion
    }
}
