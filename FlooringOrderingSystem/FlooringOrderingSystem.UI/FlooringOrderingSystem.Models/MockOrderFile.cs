using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringOrderingSystem.Models
{
    public class MockOrderFile
    {
        public string fileName { get; set; }
        public List<Order> Orders { get; set; }

        public MockOrderFile()
        {
            Orders = new List<Order>();
        }
    }
}
