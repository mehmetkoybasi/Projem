using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Punch.Controllers
{
    public class StokController : Controller
    {
        // GET: Stok
        public ActionResult StokIndex()
        {
            return View();
        }
  
        // GET: Stok
        public ActionResult DepoIndex()
        {
            return View();
        }
    }
}