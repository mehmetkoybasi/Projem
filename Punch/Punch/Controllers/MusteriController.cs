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
    public class MusteriController : Controller
    {
        // GET: Musteri
        [HttpGet]
        public ActionResult Index()
        {
            List<Musteri> MusteriListesi = new List<Musteri>();
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                string query = "SELECT * FROM cd_curracc";
                using (MySqlCommand cmd = new MySqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (MySqlDataReader sdr = cmd.ExecuteReader())
                    {
                        try
                        {
                            while (sdr.Read())
                            {
                                MusteriListesi.Add(new Musteri
                                {
                                    Id=Convert.ToInt32(sdr["ID"]),
                                    CurrAccCode = Convert.ToInt32(sdr["CurrAccCode"]),
                                    CurrAccDesc = sdr["CurrAccDesc"].ToString(),
                                    CurrAccType = sdr["CurrAccType"].ToString(),
                                    Status=Convert.ToInt32(sdr["IsActive"]),

                                });
                            }
                            con.Close();
                        }
                        catch (Exception ex)
                        {
                            con.Close();
                            throw;
                        }
                    }
                }
            }
            ViewData["MusteriListesi"] = MusteriListesi;
            TempData["KayitMesaj"] = TempData["message"];
            return View();
        }

        [HttpPost]
        public ActionResult Musteri_Kaydet(Musteri m)
        {
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                string query = "INSERT INTO cd_curracc (CurrAccCode,CurrAccDesc,CurrAccType,IsActive) " +
                                              " VALUES ('"+m.CurrAccCode+"','"+m.CurrAccDesc+"','"+m.CurrAccType+"','"+m.Status+"') ";
                using (MySqlCommand cmd = new MySqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    TempData["message"] = "Added";
                    return RedirectToAction("Index");
                }
            }
            
        }
        public ActionResult Musteri_Guncelle()
        {
            return View();
        }
        public ActionResult Musteri_Sil()
        {
            return View();
        }
    }
}