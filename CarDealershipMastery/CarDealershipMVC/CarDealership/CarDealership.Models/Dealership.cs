using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models
{
    public class Dealership
    {
        public int DealershipId { get; set; }
        public string DealerShipName { get; set; }
        public int AddressId { get; set; }
        public ICollection<Phone> Phone { get; set; }

        public virtual Address Address { get; set; }

    }
}
