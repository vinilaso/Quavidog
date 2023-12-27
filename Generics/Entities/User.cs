using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics.Entities
{
    public class User
    {
        #region Attributes

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public Address Address { get; set; } = new Address();
        public byte[]? Media { get; set; }
        public string? MediaName { get; set; }

        #endregion

        #region Constructors

        public User() { }

        #endregion

        #region Methods

        public void Add()
        {

        }

        public void ReadOne()
        {

        }

        public void ReadAll()
        {

        }

        public void Update()
        {

        }

        public void Delete()
        {

        }

        #endregion
    }
}
