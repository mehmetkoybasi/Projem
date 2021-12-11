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
                                    CurrAccCode = Convert.ToInt32(sdr["CurrAccCode"]),
                                    CurrAccDesc = sdr["CurrAccDesc"].ToString(),
                                    CurrAccType = sdr["CurrAccType"].ToString(),

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
            return View();
        }
        public ActionResult Musteri_Kaydet()
        {
            return View();
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