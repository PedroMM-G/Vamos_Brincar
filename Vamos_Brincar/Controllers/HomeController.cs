//using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Vamos_Brincar.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()

        {
            return View();
        }
        public ActionResult Index_Intituicao() {
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
                
        }
    }
