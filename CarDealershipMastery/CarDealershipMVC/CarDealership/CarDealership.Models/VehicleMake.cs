using CarDealership.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models
{
    public class VehicleMake
    {
        public int VehicleMakeId { get; set; }
        public string VehicleMakeDescription { get; set; }
        public string UserId { get; set; }
        public DateTime DateAdded { get; set; }

        public virtual AppUser User { get; set; }
    }
}
