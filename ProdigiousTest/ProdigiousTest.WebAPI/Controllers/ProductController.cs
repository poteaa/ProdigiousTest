using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ProdigiousTest.Model.Entities;
using ProdigiousTest.Model.Managers;

namespace ProdigiousTest.WebAPI.Controllers
{
    public class ProductController : ApiController
    {
        private ProductManager productManager = new ProductManager();

        // GET: Product
        public IList<Product> GetProducts()
        {
            return productManager.GetAll();
        }

        // GET: Product/5
        [ResponseType(typeof(Product))]
        public IHttpActionResult GetProduct(int id)
        {
            Product product = productManager.Get(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // PUT: Product/5
        [BasicHttpAuthorize]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProduct(int id, Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != product.Id)
            {
                return BadRequest();
            }

            try
            {
                if (productManager.Update(id, product))
                {
                    return StatusCode(HttpStatusCode.NoContent);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                return InternalServerError();
            }
            catch (Exception)
            {
                return InternalServerError();
            }

        }

        // POST: Product
        [BasicHttpAuthorize]
        [ResponseType(typeof(Product))]
        public IHttpActionResult PostProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            productManager.Create(product);

            return CreatedAtRoute("DefaultApi", new { id = product.Id }, product);
        }

        // DELETE: Product/5
        [BasicHttpAuthorize]
        [ResponseType(typeof(void))]
        public IHttpActionResult DeleteProduct(int id)
        {
            if(!productManager.Delete(id))
            {
                return NotFound();
            }

            return Ok();
        }
    }
}