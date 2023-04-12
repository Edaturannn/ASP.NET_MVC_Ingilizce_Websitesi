using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_İngilizce_Website.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace MVC_İngilizce_Website.Controllers
{
    public class UygulamaController : Controller
    {
        MVC_English_DatabaseEntities db = new MVC_English_DatabaseEntities();
        [Authorize(Roles = "Öğretmen")]
        public ActionResult Index(int sayfa=1)
        {
            //var UygulamaDegeri = db.UygulamaTablosu.ToList();
            var UygulamaDegeri = db.UygulamaTablosu.ToList().ToPagedList(sayfa, 10);
            return View(UygulamaDegeri);
        }
        public ActionResult Index2(int sayfa=1)
        {
            //var UygulamaDegeri = db.UygulamaTablosu.ToList();
            var UygulamaDegeri = db.UygulamaTablosu.ToList().ToPagedList(sayfa, 10);
            return View(UygulamaDegeri);
        }
        public ActionResult Sil(int id)
        {
            var UygulamaDegeri = db.UygulamaTablosu.Find(id);
            db.UygulamaTablosu.Remove(UygulamaDegeri);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UygulamaGetir(int id)
        {
            var UygulamaDegeri = db.UygulamaTablosu.Find(id);
            return View("UygulamaGetir", UygulamaDegeri);
        }
        public ActionResult Guncelle(UygulamaTablosu p)
        {
            var UygulamaDegeri = db.UygulamaTablosu.Find(p.ID);
            UygulamaDegeri.Fiil = p.Fiil;
            UygulamaDegeri.Cumleler = p.Cumleler;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(UygulamaTablosu p)
        {
            db.UygulamaTablosu.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}