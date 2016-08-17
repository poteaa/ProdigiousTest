using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ProdigiousTest.DataBase;

namespace ProdigiousTest.DataAcess
{
    public class DBConnection
    {
        public static DBConnection instance;
        public Initializer db;

        private DBConnection()
        {
            db = new Initializer();
        }

        public static DBConnection GetInstance()
        {
            if (instance == null)
            {
                instance = new DBConnection();
            }

            return instance;
        }
    }
}
