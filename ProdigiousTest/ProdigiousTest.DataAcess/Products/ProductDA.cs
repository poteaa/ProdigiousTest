using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProdigiousTest.DataBase;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace ProdigiousTest.DataAcess
{
    public class ProductDA : BaseDA<ProductDA>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int SupplierId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public override List<ProductDA> GetAll()
        {
            var productsDB = entities.Products.ToList();
            return Transform(productsDB);
        }

        public ProductDA Get(int id)
        {
            var productDB = entities.Products.Find(id);
            return Transform(productDB);
        }

        public bool Create(ProductDA product)
        {
            try
            {
                ProductTable productDB = Transform(product);
                entities.Products.Add(productDB);
                entities.SaveChanges();
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }
        public bool Update(int id, ProductDA product)
        {
            try
            {
                ProductTable productDB = Transform(product);
                entities.Entry(product).State = EntityState.Modified;
                entities.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return true;
        }
        public bool Delete(int id)
        {
            try
            {
                ProductTable productDB = entities.Products.Find(id);
                entities.Products.Remove(productDB);
                entities.SaveChanges();
            }
            catch
            {
                return false;
            }

            return true;
        }

        private ProductDA Transform(ProductTable productDB)
        {
            return new ProductDA
            {
                Id = productDB.Id,
                Name = productDB.Name,
                Price = productDB.Price,
                SupplierId = productDB.SupplierId
            };
        }

        private ProductTable Transform(ProductDA productDA)
        {
            return new ProductTable
            {
                Id = productDA.Id,
                Name = productDA.Name,
                Price = productDA.Price,
                SupplierId = productDA.SupplierId,
                CreatedDate = productDA.CreatedDate,
                UpdatedDate = productDA.UpdatedDate
            };
        }

        private List<ProductDA> Transform(List<ProductTable> productsDB)
        {
            var usersDA = from product in productsDB
                          select new ProductDA
                          {
                              Id = product.Id,
                              Name = product.Name,
                              Price = product.Price,
                              SupplierId = product.SupplierId
                          };

            return usersDA.ToList();
        }

        private List<ProductTable> Transform(List<ProductDA> productsDA)
        {
            var usersDA = from product in productsDA
                          select new ProductTable
                          {
                              Id = product.Id,
                              Name = product.Name,
                              Price = product.Price,
                              SupplierId = product.SupplierId
                          };

            return usersDA.ToList();
        }

        private bool ProductExists(int id)
        {
            return entities.Products.Count(e => e.Id == id) > 0;
        }
    }
}
