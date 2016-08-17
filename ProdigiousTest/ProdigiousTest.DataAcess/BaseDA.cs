using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProdigiousTest.DataBase;

namespace ProdigiousTest.DataAcess
{
    public abstract class BaseDA<T>
    {
        protected DBConnection database;
        protected EntitiesDB entities;

        public BaseDA()
        {
            database = DBConnection.GetInstance();
            entities = DBConnection.instance.db.entities;
        }

        public virtual List<T> GetAll()
        {
            return null;
        }
    }
}