﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace Punch.Models
{
    public class KullaniciModel
    {
        public int sirket_kodu { get; set; }
        public string kullanici_adi { get; set; }
        public string kullanici_sifre { get; set; }
        public string kullanici_email { get; set; }
    }
}