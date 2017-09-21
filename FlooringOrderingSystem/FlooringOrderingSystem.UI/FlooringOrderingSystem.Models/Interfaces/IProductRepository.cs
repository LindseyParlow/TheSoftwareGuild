using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringOrderingSystem.Models.Interfaces
{
    public interface IProductRepository
    {
        void LoadProducts();
        ProductPricePairs GetProductPricePair(string productName);
        Dictionary<string, ProductPricePairs> ProductPriceDictionary { get; }
    }
}
