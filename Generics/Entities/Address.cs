using Commons.Interfaces;
using Generics.Repository.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics.Entities
{
    public class Address : IAddress
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

        public Address() { }

        #endregion

        #region Methods

        public static bool Add(IAddress address)
        {
            try 
            {
                AddressDAO.Add(address);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static IAddress ReadOne(int id)
        {
            try
            {
                return AddressDAO.ReadOne(id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static List<IAddress> ReadAll()
        {
            return AddressDAO.ReadAll();
        }

        public static bool Update(IAddress newAddress)
        {
            try
            {
                AddressDAO.Update(newAddress);
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public static bool Delete(int id)
        {
            try
            {
                AddressDAO.Delete(id);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion
    }
}
