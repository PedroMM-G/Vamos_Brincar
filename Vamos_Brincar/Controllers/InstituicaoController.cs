using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vamos_Brincar.Models;

namespace Vamos_Brincar.Controllers
{
    public class InstituicaoController : Controller
    {
        CRUDinstituicao ci = new CRUDinstituicao();
        // GET: Instituicao
        public ActionResult Index()
        {
            ModelState.Clear();
            return View(ci.GetInst());
        }

        // GET: Instituicao/Details/5
        public ActionResult Details(int id)
        {
            return View(ci.GetInst().Find(itermodel => itermodel.id_inst == id));
        }

        // GET: Instituicao/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Instituicao/Create
        [HttpPost]
        public ActionResult Create(instituicaomod instInsert)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    if (ci.insertInst(instInsert))
                    {
                        ViewBag.message = "Record saved Successfully";
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

        // GET: Instituicao/Edit/5
        public ActionResult Edit(int id)
        {
            return View(ci.GetInst().Find(itermodel=>itermodel.id_inst == id));
        }

        // POST: Instituicao/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, instituicaomod updateinst)
        {
            try
            {
                // TODO: Add update logic here
                ci.editInst(updateinst);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Instituicao/Delete/5
        public ActionResult Delete(int id)
        {
            ci.deleteinst(id);
            return RedirectToAction("Index");
        }

        // POST: Instituicao/Delete/5
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
