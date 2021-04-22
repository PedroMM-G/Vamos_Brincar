using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vamos_Brincar.Models;

namespace Vamos_Brincar.Controllers
{
    public class PatroController : Controller
    {
        // GET: Patro
        PatrocinioImplementation pi = new PatrocinioImplementation();
        public ActionResult Index()
        {
            ModelState.Clear();
            return View(pi.GetPat());
        }
        public ActionResult Index2() {
            return View();
        }

        // GET: Patro/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Patro/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Patro/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Patro/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Patro/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Patro/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Patro/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
