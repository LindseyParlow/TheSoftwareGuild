﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models
{
    public class Special
    {
        public int SpecialId { get; set; }
        public string SpecialTitle { get; set; }
        public string SpecialDescription { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string SpecialType { get; set; }
        public decimal SpecialValue { get; set; }
    }
}
