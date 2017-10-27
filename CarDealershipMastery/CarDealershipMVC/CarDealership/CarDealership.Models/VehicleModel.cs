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
        public int EmployeeId { get; set; }
        public DateTime DateAdded { get; set; }
        public int VehicleMakeId { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual VehicleMake VehicleMake { get; set; }
    }
}
