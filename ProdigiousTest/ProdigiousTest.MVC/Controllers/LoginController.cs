using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using ProdigiousTest.Model.Entities;

namespace ProdigiousTest.MVC.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {            
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Login(Login login)
        {
            using (var httpClient = new HttpClient())
            {
                var response = httpClient.GetAsync(string.Format("http://localhost:56278/Login?user={0}&&pass={1}", login.Name, login.Password)).Result;
                var result = response.Content.ReadAsStringAsync().Result;
                HttpCookie cookie = new HttpCookie("Login");
                cookie.Values.Add("User", login.Name);
                cookie.Values.Add("Token", result.ToString());
                Response.Cookies.Add(cookie);
            }

            return PartialView();
        }
        
    }
}
