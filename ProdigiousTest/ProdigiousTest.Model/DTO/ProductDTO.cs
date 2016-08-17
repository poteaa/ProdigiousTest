using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ProdigiousTest.DataAcess;

namespace ProdigiousTest.Model.Entities
{
    public class ProductDTO
    {
        public static Product Transform(ProductDA productDA)
        {
            return new Product
            {
                Id = productDA.Id,
                Name = productDA.Name,
                Price = productDA.Price,
                SupplierId = productDA.SupplierId,
                Supplier = SupplierDTO.Transform(new SupplierDA().Get(productDA.SupplierId))
            };
        }

        public static ProductDA Transform(Product product)
        {
            return new ProductDA
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                SupplierId = product.SupplierId,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            };
        }


        public static List<Product> Transform(List<ProductDA> productsDA)
        {
            var products = from productDA in productsDA
                           select new Product
                           {
                               Id = productDA.Id,
                               Name = productDA.Name,
                               Price = productDA.Price,
                               SupplierId = productDA.SupplierId,
                               Supplier = SupplierDTO.Transform(new SupplierDA().Get(productDA.SupplierId))
                           };

            return products.ToList();
        }

        public static List<ProductDA> Transform(List<Product> products)
        {
            var productsDA = from product in products
                             select new ProductDA
                             {
                                 Id = product.Id,
                                 Name = product.Name,
                                 Price = product.Price,
                                 SupplierId = product.SupplierId,
                                 CreatedDate = DateTime.Now,
                                 UpdatedDate = DateTime.Now
                             };

            return productsDA.ToList();
        }
    }
}
