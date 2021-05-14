//using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vamos_Brincar.Models;

namespace Vamos_Brincar.Controllers
{
    public class HomeController : Controller
    {
        PatrocinioImplementation pi = new PatrocinioImplementation();
        public ActionResult RegisterInst()
        {
            return View();
        }
       
        public ActionResult Index()

        {
            return View();
        }
        public ActionResult LoginInst()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LoginInst(PatrocinioProp u)
        {
            if (u.nome.Equals("Camara de Guimaraes") && u.descricao.Equals("123"))
            {
                return RedirectToAction("Index_Intituicao");
            }
            else
            {
                return View();
            }
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
