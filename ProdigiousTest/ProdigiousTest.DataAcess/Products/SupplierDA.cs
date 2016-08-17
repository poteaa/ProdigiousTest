using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProdigiousTest.DataBase;

namespace ProdigiousTest.DataAcess
{
    [Table("Supplier")]
    public class SupplierDA : BaseDA<SupplierDA>
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Contact { get; set; }
        
        public override List<SupplierDA> GetAll()
        {
            var suppliersDB = entities.Suppliers.ToList();
            return Transform(suppliersDB);
        }
        public SupplierDA Get(int id)
        {
            var supplierDB = entities.Suppliers.Find(id);
            return Transform(supplierDB);
        }

        private SupplierDA Transform(SupplierTable supplierDB)
        {
            return new SupplierDA
            {
                Id = supplierDB.Id,
                Name = supplierDB.Name
            };
        }
        private SupplierTable Transform(SupplierDA SupplierDA)
        {
            return new SupplierTable
            {
                Id = SupplierDA.Id,
                Name = SupplierDA.Name
            };
        }
        private List<SupplierDA> Transform(List<SupplierTable> suppliersDB)
        {
            var usersDA = from Supplier in suppliersDB
                          select new SupplierDA
                          {
                              Id = Supplier.Id,
                              Name = Supplier.Name
                          };

            return usersDA.ToList();
        }
        
        private List<SupplierTable> Transform(List<SupplierDA> SuppliersDA)
        {
            var usersDA = from Supplier in SuppliersDA
                          select new SupplierTable
                          {
                              Id = Supplier.Id,
                              Name = Supplier.Name
                          };

            return usersDA.ToList();
        }

        private bool SupplierExists(int id)
        {
            return entities.Suppliers.Count(e => e.Id == id) > 0;
        }

    }
}
