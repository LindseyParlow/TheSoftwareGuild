using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models
{
    public class ContactUsQuery
    {
        public int ContactUsQueryId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Message { get; set; }
        public int? VehicleId { get; set; }
        
        public virtual Vehicle Vehicle { get; set; }
    }
}
