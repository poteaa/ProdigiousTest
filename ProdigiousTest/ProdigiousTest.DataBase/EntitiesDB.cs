using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProdigiousTest.DataBase
{
    public class EntitiesDB : DbContext
    {
        public DbSet<UserTable> Users { get; set; }
        public DbSet<CityTable> Cities { get; set; }
        public DbSet<ProductTable> Products { get; set; }
        public DbSet<SupplierTable> Suppliers { get; set; }
        
    }
}
