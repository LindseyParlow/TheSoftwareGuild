using CarDealership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.UI.Models
{
    public class AddModelVM
    {
        public VehicleModel VehicleModel { get; set; }
        public List<SelectListItem> MakeItems { get; set; }

        public AddModelVM()
        {
            VehicleModel = new VehicleModel();
            MakeItems = new List<SelectListItem>();
        }

        public void SetMakeItems(IEnumerable<VehicleMake> makes)
        {
            foreach (var make in makes)
            {
                MakeItems.Add(new SelectListItem()
                {
                    Value = make.VehicleMakeId.ToString(),
                    Text = make.VehicleMakeDescription,
                });
            }
        }
    }
}