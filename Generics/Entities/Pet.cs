using Commons.Enums;
using Commons.Interfaces;
using Generics.Repository.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics.Entities
{
    public class Pet : IPet
    {
        #region Attributes

        public int Id { get; set; }
        public IUser Owner { get; set; } = new User();
        public string Name { get; set; } = string.Empty;
        public PetSize Size { get; set; }
        public Breed Breed { get; set; }
        public byte[]? Media { get; set; }
        public string? MediaName { get; set; }

        #endregion

        #region Constructors

        public Pet() { }

        #endregion

        #region Methods

        public static bool Add(IPet pet)
        {
            try
            {
                PetDAO.Add(pet);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static IPet ReadOne(int id)
        {
            try
            {
                return PetDAO.ReadOne(id);
            }
            catch
            {
                return null;
            }
        }

        public static List<IPet> ReadAllByUser(string cpf)
        {
            try
            {
                return PetDAO.ReadAllByUser(cpf);
            }
            catch
            {
                return null;
            }
        }

        public static List<IPet> ReadAll()
        {
            try
            {
                return PetDAO.ReadAll();
            }
            catch
            {
                return null;
            }
        }

        public static bool Update(IPet newPet)
        {
            try
            {
                PetDAO.Update(newPet);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool Delete(int id)
        {
            try
            {
                PetDAO.Delete(id);
                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion
    }
}
