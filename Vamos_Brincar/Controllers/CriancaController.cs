using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vamos_Brincar.Models;


namespace Vamos_Brincar.Controllers
{
    public class CriancaController : Controller
    {
     
        // GET: Crianca
        CrudCrianca cc = new CrudCrianca();
       

        public ActionResult LoginCrianca() {
           
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LoginCrianca(Criancamod u) {
           
            if (ModelState.IsValid) //verifica se é válido
            {
                using (CadastroEntities cd = new CadastroEntities()) 
                {
                   var v = cd.crianca.Where(a => a.nome.Equals(u.nome) && a.pass.Equals(u.pass)).FirstOrDefault();
                    if (v != null)
                    {
                        
                        Session["usuarioLogadoID"] = v.id_crianca.ToString();
                        Session["nomeUsuarioLogado"] = v.nome.ToString();
                        return RedirectToAction("Index_Crianca");
                    }
                }
            }

            return View(u);

        }
        public ActionResult RegisterCrianca()
        { 
            return View();
        }
        public ActionResult Index()
        {
            ModelState.Clear();
            return View(cc.GetCri());
        }
        public ActionResult Index_Crianca()
        {
            return View();

        }
        public ActionResult Jogos()
        {
            return View();
        }
        // GET: Crianca/Details/5
        public ActionResult Details(int id)
        {
            return View(cc.GetCri().Find(itermodel => itermodel.id_crianca == id));
        }

        // GET: Crianca/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Crianca/Create
        [HttpPost]
        public ActionResult Create(Criancamod criInsert)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    if (cc.insertCri(criInsert))
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

        // GET: Crianca/Edit/5
        public ActionResult Edit(int id)
        {
            return View(cc.GetCri().Find(itermodel=>itermodel.id_crianca ==id));
        }

        // POST: Crianca/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Criancamod updatecri)
        {
            try
            {
                // TODO: Add update logic here
                cc.editCri(updatecri);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Crianca/Delete/5
        public ActionResult Delete(int id)
        {
            cc.deletecri(id);
            return RedirectToAction("Index");
        }

        // POST: Crianca/Delete/5
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
