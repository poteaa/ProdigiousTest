using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using ProdigiousTest.Model.Managers;

namespace ProdigiousTest.WebAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ProductManager productManager = new ProductManager();
            productManager.GetAll();
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
