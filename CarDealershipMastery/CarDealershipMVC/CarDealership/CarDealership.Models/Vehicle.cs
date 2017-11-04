using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models
{
    public class Vehicle
    {
        public int VehicleId { get; set; }
        public int VehicleTypeId { get; set; }
        public int VehicleModelId { get; set; }
        public int TransmissionId { get; set; }
        public decimal SalePrice { get; set; }
        public decimal MSRPPrice { get; set; }
        public int VehicleBodyId { get; set; }
        public int Year { get; set; }
        public string VehicleColor { get; set; }
        public string InteriorColor { get; set; }
        public string VinNumber { get; set; }
        public int Mileage { get; set; }
        public string VehicleDescription { get; set; }
        public int? SpecialId { get; set; }
        public DateTime DateAdded { get; set; }
        public int PurchaseStatusId { get; set; }
        public bool IsFeatured { get; set; }

        public virtual VehicleType VehicleType { get; set; }
        public virtual VehicleModel VehicleModel { get; set; }
        public virtual Transmission Transmission { get; set; }
        public virtual VehicleBody VehicleBody { get; set; }
        public virtual Special Special { get; set; }
        public virtual PurchaseStatus PurchaseStatus { get; set; }
    }
}
