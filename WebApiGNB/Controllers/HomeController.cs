using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApiGNB.Models;

namespace WebApiGNB.Controllers
{
    public class HomeController : Controller
    {
      
        public ActionResult Index()
        {            
            return View();
        }
        

 

    }
}