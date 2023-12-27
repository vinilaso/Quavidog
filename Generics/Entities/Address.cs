using Commons.Interfaces;
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
