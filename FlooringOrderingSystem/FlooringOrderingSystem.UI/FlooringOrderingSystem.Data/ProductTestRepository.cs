using FlooringOrderingSystem.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringOrderingSystem.Models;

namespace FlooringOrderingSystem.Data
{
    public class ProductTestRepository : IProductRepository
    {
        public ProductPricePairs GetProductPricePair(string productName)
        {
            throw new NotImplementedException();
        }

        public void LoadProducts()
        {
            throw new NotImplementedException();
        }
    }
}
