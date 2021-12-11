using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Punch.Models;

namespace Punch.Controllers
{
    public class AnaSayfaController : Controller
    {
        // GET: AnaSayfa
        [HttpGet]
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
    }
}