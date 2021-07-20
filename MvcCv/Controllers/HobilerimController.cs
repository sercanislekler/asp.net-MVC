using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repositories;

namespace MvcCv.Controllers
{
    public class HobilerimController : Controller
    {
        // GET: Hobilerim
        GenericRepository<TblHobilerim> repo = new GenericRepository<TblHobilerim>();
        public ActionResult Index()
        {
            var liste = repo.List();
            return View(liste);
        }
        [HttpGet]
        public ActionResult HobiEkle()
        {
            return View();
        }
        public ActionResult HobiEkle(TblHobilerim t)
        {
            repo.TAdd(t);
            return RedirectToAction("Index");
        }
        public ActionResult HobiSil(int id)
        {
            var sorgu = repo.Find(x => x.ID == id);
            repo.TDelete(sorgu);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult HobiDuzenle(int id)
        {
            var sorgu = repo.Find(x => x.ID == id);
            return View(sorgu);
        }
        [HttpPost]
        public ActionResult HobiDuzenle(TblHobilerim p)
        {
            var sorgu = repo.Find(x => x.ID == p.ID);
            sorgu.Aciklama1 = p.Aciklama1;
            sorgu.Aciklama2 = p.Aciklama2;
            repo.TUpdate(sorgu);
            return RedirectToAction("Index");
        }
    }
}