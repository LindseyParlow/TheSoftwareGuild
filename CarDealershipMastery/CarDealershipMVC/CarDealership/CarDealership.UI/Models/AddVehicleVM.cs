using CarDealership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.UI.Models
{
    public class AddVehicleVM
    {
        public Vehicle Vehicle { get; set; }
        public List<SelectListItem> MakeItems { get; set; }
        public List<SelectListItem> ModelItems { get; set; }
        public List<SelectListItem> TypeItems { get; set; }
        public List<SelectListItem> BodyStyleItems { get; set; }
        public List<SelectListItem> TransmissionItems { get; set; }
        public List<SelectListItem> ColorItems = new List<SelectListItem>()
        {
            new SelectListItem() {Text="Red", Value="Red"},
            new SelectListItem() {Text="Blue", Value="Blue"},
            new SelectListItem() {Text="Yellow", Value="Yellow"},
            new SelectListItem() {Text="Green", Value="Green"},
            new SelectListItem() {Text="White", Value="White"},
        };
        public List<SelectListItem> InteriorItems = new List<SelectListItem>()
        {
            new SelectListItem() {Text="Gray", Value="Gray"},
            new SelectListItem() {Text="Black", Value="Black"},
            new SelectListItem() {Text="White", Value="White"},
        };

        public AddVehicleVM()
        {
            Vehicle = new Vehicle();
            MakeItems = new List<SelectListItem>();
            ModelItems = new List<SelectListItem>();
            TypeItems = new List<SelectListItem>();
            BodyStyleItems = new List<SelectListItem>();
            TransmissionItems = new List<SelectListItem>();
            ColorItems = new List<SelectListItem>();
            InteriorItems = new List<SelectListItem>();
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

        public void SetModelItems(IEnumerable<VehicleModel> models)
        {
            foreach (var model in models)
            {
                ModelItems.Add(new SelectListItem()
                {
                    Value = model.VehicleMakeId.ToString(),
                    Text = model.VehicleModelDescription,
                });
            }
        }

        public void SetTypeItems(IEnumerable<VehicleType> types)
        {
            foreach (var type in types)
            {
                TypeItems.Add(new SelectListItem()
                {
                    Value = type.VehicleTypeId.ToString(),
                    Text = type.VehicleTypeDescription,
                });
            }
        }

        public void SetBodyStyleItems(IEnumerable<VehicleBody> bodies)
        {
            foreach (var body in bodies)
            {
                BodyStyleItems.Add(new SelectListItem()
                {
                    Value = body.VehicleBodyId.ToString(),
                    Text = body.VehicleBodyDescription,
                });
            }
        }

        public void SetTransmissionItems(IEnumerable<Transmission> transmissions)
        {
            foreach (var transmission in transmissions)
            {
                TransmissionItems.Add(new SelectListItem()
                {
                    Value = transmission.TransmissionId.ToString(),
                    Text = transmission.TransmissionType,
                });
            }
        }

        public void SetColorItems()
        {
            
                ColorItems.Add(new SelectListItem()
                {
                    Value = "Red",
                    Text = "Red",
                });
            
        }

    }
}