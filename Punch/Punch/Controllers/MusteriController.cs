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

        [HttpPost]
        public ActionResult Musteri_Guncelle(Musteri mg)
        {
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                //string query = "UPDATE cd_curracc set CurrAccCode='" + mg.CurrAccCode + "',CurrAccDesc='" + mg.CurrAccDesc + "', CurrAccType='" + mg.CurrAccType + "',IsActive='" + mg.Status + "' where id='"+mg.Id+"'";
                string query = "SET @p0='" + mg.Id + "'; SET @p1='" + mg.CurrAccCode + "'; SET @p2='" + mg.CurrAccDesc + "'; SET @p3='" + mg.CurrAccType + "'; SET @p4='" + mg.Status + "'; CALL sp_upcustomer (@p0, @p1, @p2, @p3, @p4); SELECT @p0 AS `AccID`, @p1 AS `AccCode`, @p2 AS `AccDesc`, @p3 AS `AccType`, @p4 AS `Active`;";
                using (MySqlCommand cmd = new MySqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    TempData["message"] = "Updated";
                    return RedirectToAction("Index");
                }
            }
        }

        [HttpPost]
        [ActionName("Musteri_Sil")]
        public ActionResult Musteri_Sil(Musteri ms)
        {
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                
                string query = "DELETE FROM cd_curracc where id='" + ms.Id + "'";
                using (MySqlCommand cmd = new MySqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    TempData["message"] = "Deleted";
                   
                    return RedirectToAction("Index");
                }
            }
        }
    }
}