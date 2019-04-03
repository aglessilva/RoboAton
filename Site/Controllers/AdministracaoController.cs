using Site.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Site.Controllers
{
    
    public class AdministracaoController : Controller
    {
        private DBConn db = new DBConn();
        // GET: Administracao
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Login(string login, string pwd)
        {
            string _senha = "roboatom2019", _login = "RoboAtom";

            if (_senha.Equals(pwd.Trim()) && _login.Equals(login.Trim()))
            {
               
                SessionContext.Login ="Robo Atom";
                SessionContext.IsAutenticado = "true";
                return Json(new { status = "ok" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { status = "NOK" }, JsonRequestBehavior.AllowGet);
            }


        }

        // GET: Administracao/Details/5
        public ActionResult DetailsList()
        {
            IEnumerable<FotoImagem> lst = null;

            lst = db.Imagens.AsEnumerable();
            return View(lst);
        }

        // GET: Administracao/Create
        public ActionResult Create()
        {
            ViewBag.TipoEvento = FotoImagem.ListTypeEvent();
            return View();
        }

        // POST: Administracao/Create
        [HttpPost]
        public ActionResult Create(FotoImagem fotoImagem)
        {
            ViewBag.TipoEvento = FotoImagem.ListTypeEvent();

            try
            {
                HttpFileCollectionBase files = Request.Files;
                HttpPostedFileBase file = files[0];

                using (MemoryStream ms = new MemoryStream())
                {
                    file.InputStream.CopyTo(ms);
                    fotoImagem.Path = ms.GetBuffer();
                }
                using (DBConn db = new DBConn())
                {
                    db.Imagens.Add(fotoImagem);
                    db.SaveChanges();
                    db.Dispose();
                }

                return View();
            }
            catch(Exception ex)
            {
                string err = ex.Message.ToString();
                return View();
            }
        }

        // GET: Administracao/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Administracao/Edit/5
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

        // GET: Administracao/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Administracao/Delete/5
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
