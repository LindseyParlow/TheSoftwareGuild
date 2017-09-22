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
        private static List<ProductPricePairs> ProductList;

        public ProductTestRepository()
        {
            LoadProducts();
        }

        public ProductPricePairs GetOne(string productName)
        {
            return ProductList.FirstOrDefault(p => p.ProductType == productName);
        }

        private void LoadProducts()
        {
            ProductList = new List<ProductPricePairs>()
            {
                new ProductPricePairs("Carpet", 2.25M, 2.10M),
                new ProductPricePairs("Laminate", 1.75M, 2.10M),
                new ProductPricePairs("Tile", 3.50M, 4.15M),
                new ProductPricePairs("Wood", 5.15M, 4.75M),
            };
        }
    }
}
