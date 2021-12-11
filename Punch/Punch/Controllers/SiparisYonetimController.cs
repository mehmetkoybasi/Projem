using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Punch.Controllers
{
    public class SiparisYonetimController : Controller
    {
        // GET: SiparisYonetim
        public ActionResult Index()
        {
            if (!string.IsNullOrEmpty(Session["KullaniciAdi"] as string))
            {
                return View();
            }
            else
            {

                return RedirectToAction("Index", "Home");
            }
        }
        public ActionResult Toptan_Alis_Siparisi()
        {
            if (!string.IsNullOrEmpty(Session["KullaniciAdi"] as string))
            {
                return View();
            }
            else
            {

                return RedirectToAction("Index", "Home");
            }
        }
        public ActionResult Toptan_Satis_Siparisi()
        {
            if (!string.IsNullOrEmpty(Session["KullaniciAdi"] as string))
            {
                return View();
            }
            else
            {

                return RedirectToAction("Index", "Home");
            }
        }
    }
}