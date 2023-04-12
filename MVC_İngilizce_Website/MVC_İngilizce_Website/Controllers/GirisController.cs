using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_İngilizce_Website.Models.Entity;
using System.Web.Security;

namespace MVC_İngilizce_Website.Controllers
{
    public class GirisController : Controller
    {
        MVC_English_DatabaseEntities db = new MVC_English_DatabaseEntities();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(GirisTablosu p)
        {
            var GirisDegeri = db.GirisTablosu.FirstOrDefault(x => x.Email == p.Email && x.Sifre == p.Sifre);
            if (GirisDegeri!=null)
            {
                FormsAuthentication.SetAuthCookie(p.Email, false);
                return RedirectToAction("Index", "Anasayfa");
            }
            else
            {
                return View("Index");
            }
        }
    }
}