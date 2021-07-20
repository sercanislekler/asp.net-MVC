using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MvcCv.Models.Entity;

namespace MvcCv.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(TblAdmin t)
        {
            DbCvEntities1 db = new DbCvEntities1();
            var login = db.TblAdmin.FirstOrDefault(x => x.KullaniciAdi == t.KullaniciAdi && x.Sifre == t.Sifre);
            if (login != null)
            {
                FormsAuthentication.SetAuthCookie(login.KullaniciAdi, true);
                Session["KullaniciAdi"] = login.KullaniciAdi.ToString();
                return RedirectToAction("Index","Deneyim");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index","Login");
        }
    }
}