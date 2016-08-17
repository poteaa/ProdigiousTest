using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ProdigiousTest.DataAcess;

namespace ProdigiousTest.Model.Entities
{
    public class SupplierDTO
    {
        public static Supplier Transform(SupplierDA SupplierDA)
        {
            return new Supplier
            {
                Id = SupplierDA.Id,
                Name = SupplierDA.Name
            };
        }

        public static SupplierDA Transform(Supplier Supplier)
        {
            return new SupplierDA
            {
                Id = Supplier.Id,
                Name = Supplier.Name
            };
        }


        public static List<Supplier> Transform(List<SupplierDA> SuppliersDA)
        {
            var Suppliers = from SupplierDA in SuppliersDA
                           select new Supplier
                           {
                               Id = SupplierDA.Id,
                               Name = SupplierDA.Name
                           };

            return Suppliers.ToList();
        }

        public static List<SupplierDA> Transform(List<Supplier> Suppliers)
        {
            var SuppliersDA = from Supplier in Suppliers
                           select new SupplierDA
                           {
                               Id = Supplier.Id,
                               Name = Supplier.Name
                           };

            return SuppliersDA.ToList();
        }
    }
}
