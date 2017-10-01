using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TipCalculator.Models
{
    public class TipData
    {
        public decimal Total { get; set; }
        public decimal Percent { get; set; }
        public int NumberOfPeople { get; set; }
        public decimal Tip
        {
            get { return Total * (Percent / 100); }
        }
        public decimal TotalBillPerPerson
        {
            get
            {
                if (NumberOfPeople == 0)
                {
                    return (Total + Tip) / (NumberOfPeople + 1);
                }
                else
                {
                    return (Total + Tip) / (NumberOfPeople);
                }
            }
        }
    }
}