using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vamos_Brincar.Models;

namespace Vamos_Brincar.Controllers
{
    public class SugController : Controller
    {
        // GET: Sug
        SugestoesImplementation si = new SugestoesImplementation();
        public ActionResult Index()
        {
            ModelState.Clear();
            return View(si.GetSug());
        }

        // GET: Sug/Details/5
        public ActionResult Details(int id)
        {
            return View(si.GetSug().Find(itmodel => itmodel.id_sug == id));
        }

        // GET: Sug/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sug/Create
        [HttpPost]
        public ActionResult Create(SugestoesProp suginsert)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    if (si.insertsug(suginsert))
                    {
                        ViewBag.message = "Record Save Successfully !";
                        ModelState.Clear();
                    }
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Sug/Edit/5
        public ActionResult Edit(int id)
        {
            return View(si.GetSug().Find(itmodel =>itmodel.id_sug==id));
        }

        // POST: Sug/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, SugestoesProp updatesug)
        {
            try
            {
                si.editsug(updatesug);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Sug/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            si.deletesug(id);
            return RedirectToAction("Index");
        }

        // POST: Sug/Delete/5
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
