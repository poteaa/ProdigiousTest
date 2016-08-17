using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProdigiousTest.DataAcess;
using ProdigiousTest.Model.Entities;

namespace ProdigiousTest.Model.Managers
{
    public class SupplierManager
    {
        public IList<Supplier> GetAll()
        {
            SupplierDA SupplierDA = new SupplierDA();
            List<SupplierDA> SuppliersDA = SupplierDA.GetAll();
            return SupplierDTO.Transform(SuppliersDA);
        }

        public Supplier Get(int id)
        {
            SupplierDA SupplierDA = new SupplierDA();
            SupplierDA = SupplierDA.Get(id);
            return SupplierDTO.Transform(SupplierDA);
        }
    }
}
