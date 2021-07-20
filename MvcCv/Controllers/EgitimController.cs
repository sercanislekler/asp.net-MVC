using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Repositories;
using MvcCv.Models.Entity;

namespace MvcCv.Controllers
{
    public class EgitimController : Controller
    {
        // GET: Egitim
        GenericRepository<TblEgitimlerim> repo = new GenericRepository<TblEgitimlerim>();
        public ActionResult Index()
        {
            var egitimler = repo.List();
            return View(egitimler);
        }
        [HttpGet]
        public ActionResult YeniEgitim()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniEgitim(TblEgitimlerim p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult EgitimSil(int id)
        {
            var egitim = repo.Find(x => x.ID == id);
            repo.TDelete(egitim);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EgitimDuzenle(int id)
        {
            var egitim = repo.Find(x => x.ID == id);
            return View(egitim);

        }
        [HttpPost]
        public ActionResult EgitimDuzenle(TblEgitimlerim p)
        {
            var e = repo.Find(x => x.ID == p.ID);
            e.Baslik = p.Baslik;
            e.AltBaslik1 = p.AltBaslik1;
            e.AltBaslik2 = p.AltBaslik2;
            e.GNO = p.GNO;
            e.Tarih = p.Tarih;
            repo.TUpdate(e);
            return RedirectToAction("Index");
        }
    }
}