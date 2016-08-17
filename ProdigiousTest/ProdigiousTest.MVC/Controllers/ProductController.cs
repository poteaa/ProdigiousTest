using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using ProdigiousTest.Model.Entities;

namespace ProdigiousTest.MVC.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public async Task<ActionResult> Index()
        {
            var client = new HttpClient();
            var json = await client.GetStringAsync("http://localhost:56278/Product");
            var products = JsonConvert.DeserializeObject<List<Product>>(json);

            return View(products);
        }

        // GET: Product/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var client = new HttpClient();
            var json = await client.GetStringAsync("http://localhost:56278/Product/" + id);
            var product = JsonConvert.DeserializeObject<Product>(json);
            return View(product);
        }

        // GET: Product/Create
        public async Task<ActionResult> Create()
        {
            var client = new HttpClient();
            var json = await client.GetStringAsync("http://localhost:56278/Supplier");
            var suppliers = JsonConvert.DeserializeObject<List<Product>>(json);
            ViewBag.SupplierId = new SelectList(suppliers, "Id", "Name");
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public async Task<ActionResult> Create(Product product)
        {
            try
            {
                HttpCookie cookie = Request.Cookies["Login"];
                string user = cookie["User"];
                string token = cookie["Token"];
                var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", 
                    Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(string.Format("{0}:{1}", user, token))));
                StringContent queryString = new StringContent(JsonConvert.SerializeObject(product), Encoding.UTF8, "application/json");
                var json = await client.PostAsync("http://localhost:56278/Product", queryString);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Create");
            }
        }

        // GET: Product/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var client = new HttpClient();
            var json = await client.GetStringAsync("http://localhost:56278/Product/" + id);
            var product = JsonConvert.DeserializeObject<Product>(json);
            var jsonSup = await client.GetStringAsync("http://localhost:56278/Supplier");
            var suppliers = JsonConvert.DeserializeObject<List<Product>>(jsonSup);
            ViewBag.SupplierId = new SelectList(suppliers, "Id", "Name", product.SupplierId);
            return View(product);
        }

        // POST: Product/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, Product product)
        {
            try
            {
                var client = new HttpClient();
                StringContent queryString = new StringContent(JsonConvert.SerializeObject(product));
                var json = await client.PutAsync("http://localhost:56278/Product/" + id, queryString);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var client = new HttpClient();
            var json = await client.GetStringAsync("http://localhost:56278/Product/" + id);
            var product = JsonConvert.DeserializeObject<Product>(json);
            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id, FormCollection collection)
        {
            try
            {
                var client = new HttpClient();
                var json = await client.DeleteAsync("http://localhost:56278/Product/" + id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
