using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_İngilizce_Website.Models.Entity;


namespace MVC_İngilizce_Website.Controllers
{
    public class İletisimController : Controller
    {
        MVC_English_DatabaseEntities db = new MVC_English_DatabaseEntities();
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(İletisimTablosu p)
        {
            db.İletisimTablosu.Add(p);
            db.SaveChanges();
            return View();
        }

        
        
        
        
    }
}