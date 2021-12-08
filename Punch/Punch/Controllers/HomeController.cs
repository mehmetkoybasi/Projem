using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySql.Data.MySqlClient;
using Punch.Models;

namespace Punch.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            List<KullaniciModel> customers = new List<KullaniciModel>();
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

            using (MySqlConnection con = new MySqlConnection(constr))
            {
                string query = "SELECT * FROM tbl_user";
                using (MySqlCommand cmd = new MySqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (MySqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            customers.Add(new KullaniciModel
                            {
                                sirket_kodu = Convert.ToInt32(sdr["sirket_kodu"]),
                                kullanici_adi = sdr["kullanici_adi"].ToString(),
                                kullanici_email = sdr["kullanici_email"].ToString()
                            });
                        }
                    }
                    con.Close();
                }
            }


            return View(customers);
        }
    }
}