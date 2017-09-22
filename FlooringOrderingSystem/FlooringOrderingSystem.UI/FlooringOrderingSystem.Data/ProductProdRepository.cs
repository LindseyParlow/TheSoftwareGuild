using FlooringOrderingSystem.Models;
using FlooringOrderingSystem.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringOrderingSystem.Data
{
    public class ProductProdRepository : IProductRepository
    {
        private static List<ProductPricePairs> ProductList;

        private string productFilePath;
        
        public ProductProdRepository()
        {
            productFilePath = @"C:\Repos\bitbucket\dotnet-lindsey-parlow\FlooringOrderingSystem\FlooringOrderingSystemFiles\Products.txt";
            
            LoadProducts();
        }


        private void LoadProducts()
        {
            ProductList = new List<ProductPricePairs>();

            using (StreamReader sr = new StreamReader(productFilePath))
            {
                sr.ReadLine();
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    string[] columns = line.Split(',');

                    string product = columns[0];
                    decimal material = decimal.Parse(columns[1]);
                    decimal labor = decimal.Parse(columns[2]);
                    ProductPricePairs pricePair = new ProductPricePairs(product, material, labor);

                    ProductList.Add(pricePair);
                }
            }
        }

        public ProductPricePairs GetOne(string productName)
        {
            return ProductList.FirstOrDefault(p => p.ProductType == productName);
        }
    }
}

