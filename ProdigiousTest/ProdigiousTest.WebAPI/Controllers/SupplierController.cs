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
    public class SupplierController : ApiController
    {
        private SupplierManager supplierManager = new SupplierManager();

        // GET: Supplier
        public IList<Supplier> GetSuppliers()
        {
            return supplierManager.GetAll();
        }

        // GET: Supplier/5
        [ResponseType(typeof(Supplier))]
        public IHttpActionResult GetSupplier(int id)
        {
            Supplier Supplier = supplierManager.Get(id);
            if (Supplier == null)
            {
                return NotFound();
            }

            return Ok(Supplier);
        }

        //// PUT: Supplier/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutSupplier(int id, Supplier Supplier)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != Supplier.Id)
        //    {
        //        return BadRequest();
        //    }

        //    try
        //    {
        //        if (supplierManager.Update(id, Supplier))
        //        {
        //            return StatusCode(HttpStatusCode.NoContent);
        //        }
        //        else
        //        {
        //            return NotFound();
        //        }
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        return InternalServerError();
        //    }
        //    catch (Exception)
        //    {
        //        return InternalServerError();
        //    }

        //}

        //// POST: Supplier
        //[ResponseType(typeof(Supplier))]
        //public IHttpActionResult PostSupplier(Supplier Supplier)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    supplierManager.Create(Supplier);

        //    return CreatedAtRoute("DefaultApi", new { id = Supplier.Id }, Supplier);
        //}

        //// DELETE: Supplier/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult DeleteSupplier(int id)
        //{
        //    if(!supplierManager.Delete(id))
        //    {
        //        return NotFound();
        //    }

        //    return Ok();
        //}
    }
}