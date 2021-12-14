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
    public class RaporController : Controller
    {
        // GET: Rapor
        public ActionResult Index()
        {
            List<Musteri> MusteriListesi = new List<Musteri>();
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                string query = "SELECT * FROM cd_curracc";
                //string query = "call sp_customer";
                //string query = "SET @p0='2'; CALL sp_customer (@p0); SELECT @p0 AS `AccID`;"; 
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
                                    Id = Convert.ToInt32(sdr["ID"]),
                                    CurrAccCode = Convert.ToInt32(sdr["CurrAccCode"]),
                                    CurrAccDesc = sdr["CurrAccDesc"].ToString(),
                                    CurrAccType = sdr["CurrAccType"].ToString(),
                                    Status = Convert.ToInt32(sdr["IsActive"]),

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
        public ActionResult MusteriRapor(Musteri mr)
        {
            List<Musteri> MusteriListesi = new List<Musteri>();
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                string query = "SELECT * FROM cd_curracctype";
                //string query = "call sp_customer";
                //string query = "SET @p0='2'; CALL sp_customer (@p0); SELECT @p0 AS `AccID`;"; 
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
                                    Id = Convert.ToInt32(sdr["ID"]),
                                    CurrAccCode = Convert.ToInt32(sdr["CurrAccCode"]),
                                    CurrAccDesc = sdr["CurrAccDesc"].ToString(),
                                    CurrAccType = sdr["CurrAccType"].ToString(),
                                    Status = Convert.ToInt32(sdr["IsActive"]),

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
    }
}