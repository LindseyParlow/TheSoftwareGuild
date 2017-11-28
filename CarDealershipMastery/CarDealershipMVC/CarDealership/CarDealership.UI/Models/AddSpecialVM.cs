using CarDealership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership.UI.Models
{
    public class AddSpecialVM
    {
        public Special AddSpecial { get; set; }

        public AddSpecialVM()
        {
            AddSpecial = new Special();
        }
    }
}