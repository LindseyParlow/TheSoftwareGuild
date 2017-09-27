using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TipCalculator.Models
{
    public class TipData
    {
        public decimal DebitAmount { get; set; }
        public decimal Total { get; set; }
        public decimal Percent { get; set; }
        public decimal Tip
        {
            get { return Total * (Percent / 100); }
        }
        
    }
}