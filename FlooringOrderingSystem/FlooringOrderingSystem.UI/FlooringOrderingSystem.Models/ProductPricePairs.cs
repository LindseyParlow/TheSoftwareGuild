using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringOrderingSystem.Models
{
    public class ProductPricePairs
    {
        public ProductPricePairs(string productType, decimal material, decimal labor)
        {
            MaterialCost = material;
            LaborCost = labor;
            ProductType = productType;
        }

        public decimal MaterialCost { get; set; }
        public decimal LaborCost { get; set; }
        public string ProductType { get; set; }
    }
}
