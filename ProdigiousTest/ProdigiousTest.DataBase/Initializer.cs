using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdigiousTest.DataBase
{
    public class Initializer
    {
        public EntitiesDB entities;

        public Initializer()
        {
            Database.SetInitializer(new SomeData());
            entities = new EntitiesDB();
            entities.Cities.ToList();
            entities.Users.ToList();
            entities.Suppliers.ToList();
            entities.Products.ToList();
        }
    }
}
