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
    public class LoginController : ApiController
    {
        private LoginManager loginManager = new LoginManager();
        
        // GET: Login
        [ResponseType(typeof(Login))]
        public IHttpActionResult GetLogin(string user, string pass)
        {
            string token = loginManager.Login(user, pass);
            return Ok(token);
        }
    }
}