using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProdigiousTest.DataAcess;
using ProdigiousTest.Model.Entities;

namespace ProdigiousTest.Model.Managers
{
    public class ProductManager
    {
        ProductDTO productDTO;

        public ProductManager()
        {
            productDTO = new ProductDTO();
        }

        public IList<Product> GetAll()
        {
            ProductDA productDA = new ProductDA();
            List<ProductDA> productsDA = productDA.GetAll();
            return ProductDTO.Transform(productsDA);
        }

        public Product Get(int id)
        {
            ProductDA productDA = new ProductDA();
            productDA = productDA.Get(id);
            return ProductDTO.Transform(productDA);
        }

        public bool Create(Product product)
        {
            ProductDA productDA = new ProductDA();
            return productDA.Create(ProductDTO.Transform(product));
        }

        public bool Update(int id, Product product)
        {
            ProductDA productDA = new ProductDA();
            return productDA.Update(id, ProductDTO.Transform(product));
        }

        public bool Delete(int id)
        {
            ProductDA productDA = new ProductDA();
            Product product = Get(id);
            if (product == null)
            {
                return false;
            }

            try
            {
                productDA.Delete(id);
            }
            catch (Exception)
            {
                throw;
            }

            return true;
        }
    }
}
