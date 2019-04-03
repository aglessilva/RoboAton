using Site.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace Site.Controllers
{
    public class HomeController : Controller
    {
        private DBConn db = new DBConn();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Videos()
        {
          
            return View();
        }


        [HttpGet]
        public ActionResult Lista()
        {
            ViewBag.Heigth = "460px";

            IEnumerable<FotoImagem> lst = null;
            
            lst = db.Imagens.Where(c => c.Ativo).AsEnumerable();
            return View("Lista",lst);
            
        }

        public ActionResult Eventos()
        {
            return View();
        }

        [HttpGet]
        public ActionResult EnviarContato()
        {
            return View();
        }

        [HttpPost]
        public JsonResult EnviarContato(Email _objModelMail)
        {
                try
                {
                    if (ModelState.IsValid)
                    {
                        string txtBody = "Cliente: " + _objModelMail.Nome + "<br>";
                        txtBody +="Telefone: " + _objModelMail.Telefone + "<br>";
                        txtBody += "E-mail: " + _objModelMail.From + "<br><br>";
                        txtBody += "<b>Mensagem:</b><br><br>" + _objModelMail.Body + "<br>";
                    MailMessage mail = new MailMessage();
                        mail.To.Add(_objModelMail.To);
                        mail.From = new MailAddress(_objModelMail.From);
                        mail.Subject = _objModelMail.Subject;
                        mail.Body = txtBody.Replace("\n", "<br>");
                        mail.IsBodyHtml = true;

                    //Instância smtp do servidor, neste caso o gmail.

                    SmtpClient smtp = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        UseDefaultCredentials = false,
                        Credentials = new System.Net.NetworkCredential("agles.developer@gmail.com", "290482hbt"),// Login e senha do e-mail.
                        EnableSsl = true
                    };
                    smtp.Send(mail);

                   

                    return Json(new { isSubmited = true }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isSubmited = false }, JsonRequestBehavior.AllowGet);
                    }
                }
                catch (Exception ex)
                {
                   return Json(new { isSubmited = false, messageError = ex.Message.ToString() }, JsonRequestBehavior.AllowGet);
                } 
                //Instância classe email
        }

        [HttpGet]
        public PartialViewResult Carrosssel(string id)
        {
            ViewBag.Evento = FotoImagem.ListTypeEvent().Find(g => g.Value.Equals(id)).Text;
            db = new DBConn();
            int _TypeEvent = Convert.ToInt32(id);

            List<FotoImagem> lstImgePictory = null;
            lstImgePictory = db.Imagens.Where(x => x.TipoEvento == _TypeEvent && x.Ativo).ToList();
            return PartialView("Carrosssel", lstImgePictory);
        }
    }
}