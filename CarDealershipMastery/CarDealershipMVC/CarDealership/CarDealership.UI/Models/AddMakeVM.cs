using CarDealership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership.UI.Models
{
    public class AddMakeVM
    {
        public VehicleMake VehicleMakeItem { get; set; }

        public AddMakeVM()
        {
            VehicleMakeItem = new VehicleMake();
        }
    }
}