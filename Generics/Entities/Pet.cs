using Commons.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics.Entities
{
    public class Pet
    {
        #region Attributes

        public int Id { get; set; }
        public User Owner { get; set; } = new User();
        public string Name { get; set; } = string.Empty;
        public PetSize Size { get; set; }
        public Breed Breed { get; set; }

        #endregion

        #region Constructors

        public Pet() { }

        #endregion

        #region Methods

        public void Add()
        {

        }

        public void ReadOne()
        {

        }

        public void ReadAllByUser()
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
