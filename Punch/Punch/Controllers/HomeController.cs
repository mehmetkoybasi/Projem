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
        [HttpGet]
        public ActionResult Index()
        {
            KullaniciModel kg = new KullaniciModel();
            return View(kg);
        }
        [HttpPost]
        public ActionResult Index(KullaniciModel kg, string kadi)
        {
            try
            {
                
                string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    string query = "SELECT * FROM tbl_user t where t.kullanici_adi = '"+kg.kullanici_adi+ "' and t.kullanici_sifre = '" + kg.kullanici_sifre+"' ";
                    using (MySqlCommand cmd = new MySqlCommand(query))
                    {
                        cmd.Connection = con;
                        con.Open();
                        using (MySqlDataReader sdr = cmd.ExecuteReader())
                        {
                            if (sdr.Read())
                            {
                                kadi = kg.kullanici_adi.ToString();
                                con.Close();
                                Session["KullaniciAdi"] = kg.kullanici_adi;
                                Session["KullaniciSifre"] = kg.kullanici_sifre;
                                //Session["KullaniciAdSoyad"] = kg.kullanici_adsoyad;

                                return RedirectToAction("Index","AnaSayfa");
                            }
                            else
                            {
                                ModelState.AddModelError("Hata","Login Hata... Kullanıcı Bilgileri Hatalı");
                                con.Close();
                                return View(kg);
                                Session.Clear();

                            }

                        }
                    }
                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Hata", "Login Hata... Kullanıcı Bilgileri Doğru");
                return View(kg);
            }
        }

    }
}