using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repositories;

namespace MvcCv.Controllers
{
    public class HakkimdaController : Controller
    {
        // GET: Hakkimda
        GenericRepository<TblHakkimda> repo = new GenericRepository<TblHakkimda>();
        public ActionResult Index()
        {
            var hakkimda = repo.List();
            return View(hakkimda);
        }
        [HttpGet]
        public ActionResult HakkimdaDuzenle(int id)
        {
            var bul = repo.Find(x => x.ID == id);
            return View(bul);
        }
        [HttpPost]
        public ActionResult HakkimdaDuzenle(TblHakkimda t)
        {
            var bul = repo.Find(x => x.ID == t.ID);
            bul.Ad = t.Ad;
            bul.Soyad = t.Soyad;
            bul.Aciklama = t.Aciklama;
            bul.Telefon = t.Telefon;
            bul.Adres = t.Adres;
            bul.Mail = t.Mail;
            bul.Resim = t.Resim;
            repo.TUpdate(bul);
            return RedirectToAction("Index");
        }
    }
}