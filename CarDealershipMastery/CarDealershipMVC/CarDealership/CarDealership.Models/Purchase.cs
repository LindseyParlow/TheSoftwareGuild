using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models
{
    public class Purchase
    {
        public int PurchaseId { get; set; }
        public decimal PurchasePrice { get; set; }
        public int PurchaseTypeId { get; set; }
        public int EmployeeId { get; set; }
        public int CustomerId { get; set; }
        public int VehicleId { get; set; }
        public DateTime DatePurchased { get; set; }

        public virtual PurchaseType PurchaseType { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Vehicle Vehicle { get; set; }
    }
}
