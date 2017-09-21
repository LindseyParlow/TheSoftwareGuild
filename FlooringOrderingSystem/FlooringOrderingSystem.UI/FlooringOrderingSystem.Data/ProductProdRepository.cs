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
        private string productFilePath;

        public ProductProdRepository()
        {
            productFilePath = @"C:\Repos\bitbucket\dotnet-lindsey-parlow\FlooringOrderingSystem\FlooringOrderingSystemFiles\Products.txt";

            ProductPriceDictionary = new Dictionary<string, ProductPricePairs>();

            LoadProducts();
        }

        public Dictionary<string, ProductPricePairs> ProductPriceDictionary { get; private set; }

        public void LoadProducts()
        {
            using (StreamReader sr = new StreamReader(productFilePath))
            {
                sr.ReadLine();
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    string[] columns = line.Split(',');

                    var product = columns[0];
                    var material = decimal.Parse(columns[1]);
                    var labor = decimal.Parse(columns[2]);
                    var pricePair = new ProductPricePairs(material, labor);

                    ProductPriceDictionary.Add(product, pricePair);

                    //use this later to call a particular product from the dictionary
                    //var carpetPrices = ProductPriceDictionary["Carpet"];
                    //decimal carpetLaborCost = carpetPrices.LaborCost;
                }
            }
        }

        public ProductPricePairs GetProductPricePair(string productName)
        {
            return ProductPriceDictionary[productName];
        }
    }
}

