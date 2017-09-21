using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringOrderingSystem.Models
{
    public class ProductPricePairs
    {
        public ProductPricePairs(decimal material, decimal labor)
        {
            MaterialCost = material;
            LaborCost = labor;
        }

        public decimal MaterialCost { get; set; }
        public decimal LaborCost { get; set; }
    }
}
