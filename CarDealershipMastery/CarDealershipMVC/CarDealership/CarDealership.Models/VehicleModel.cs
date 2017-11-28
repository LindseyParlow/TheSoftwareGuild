using CarDealership.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models
{
    public class VehicleModel
    {
        public int VehicleModelId { get; set; }
        public string VehicleModelDescription { get; set; }
        public DateTime DateAdded { get; set; }
        public int VehicleMakeId { get; set; }
        public string UserId { get; set; }


        public virtual AppUser User { get; set; }
        public virtual VehicleMake VehicleMake { get; set; }
    }
}
