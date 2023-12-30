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
    public class User : IUser
    {
        #region Attributes
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public IAddress Address { get; set; }
        public AccessType AccessType { get; set; }
        public byte[]? Media { get; set; }
        public string? MediaName { get; set; }

        #endregion

        #region Constructors

        public User() { }

        #endregion

        #region Methods

        public static bool Add(IUser user)
        {
            try
            {
                UserDAO.Add(user);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static IUser ReadOne(string cpf)
        {
            try
            {
                return UserDAO.ReadOne(cpf);
            }
            catch
            {
                return null;
            }
        }

        public static IUser ReadOne(string cpf, string password) 
        {
            try
            {
                return UserDAO.ReadOne(cpf, password);
            }
            catch
            {
                return null;
            }
        }

        public static List<IUser> ReadAll()
        {
            try
            {
                return UserDAO.ReadAll();
            }
            catch
            {
                return new List<IUser>();
            }

        }

        public static bool Update(IUser newUser)
        {
            try
            {
                UserDAO.Update(newUser);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool Delete(string cpf)
        {
            try
            {
                UserDAO.Delete(cpf);
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
