﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Punch.Models
{
    public class Musteri
    {
        public int Id { get; set; }
        public int CurrAccCode { get; set; }
        public string CurrAccDesc { get; set; }
        public string CurrAccType { get; set; }
        public int Status { get; set; } 
        public IEnumerable<SelectListItem> SCurrAccType { get; set; }
        public IEnumerable<SelectListItem> SCurrAccDesc { get; set; }

    }
}