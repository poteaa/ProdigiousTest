using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdigiousTest.DataBase
{
    public class SomeData : DropCreateDatabaseAlways<EntitiesDB>
    {
        protected override void Seed(EntitiesDB context)
        {
            var cities = new List<CityTable>
            {
                new CityTable {Id=1, Name="Bogotá", CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now }
            };

            cities.ForEach(c => context.Cities.Add(c));

            new List<UserTable>
            {
                new UserTable {Id=1, Age=32, CityId=cities.Single(c => c.Name=="Bogotá").Id, Name ="Diego",
                    UserName ="Diego", Password="BmwzQACRCmddGbSXdUJIGw==", CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now }
            }.ForEach(u => context.Users.Add(u));

            var suppliers = new List<SupplierTable>
            {
                new SupplierTable {Id=1, Name="Milky", Description="Milk Company", Address="Street 123", Phone="12345", Contact="Adriana", CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now },
                new SupplierTable {Id=2, Name="ChocoComp", Description="Chocolate Company", Address="Street 123", Phone="12345", Contact="Johana", CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now  }
            };

            suppliers.ForEach(s => context.Suppliers.Add(s));

             new List<ProductTable>
            {
                new ProductTable {Id=1, Name="Regular Milk", Price=10, SupplierId = suppliers.Single(s => s.Name=="Milky").Id, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now},
                new ProductTable {Id=2, Name="Almond Milk", Price=10, SupplierId = suppliers.Single(s => s.Name=="Milky").Id, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now },
                new ProductTable {Id=3, Name="Chocolate Bar", Price=10, SupplierId = suppliers.Single(s => s.Name=="ChocoComp").Id, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now },
                new ProductTable {Id=4, Name="Sweet Chocolate", Price=10, SupplierId = suppliers.Single(s => s.Name=="ChocoComp").Id, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now }
            }.ForEach(p => context.Products.Add(p));
        }
    }
}
