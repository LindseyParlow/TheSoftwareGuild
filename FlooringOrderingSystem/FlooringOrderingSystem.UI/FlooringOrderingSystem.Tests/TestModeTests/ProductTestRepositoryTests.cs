using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using FlooringOrderingSystem.BLL;
using FlooringOrderingSystem.Models;

namespace FlooringOrderingSystem.Tests.TestModeTests
{
    [TestFixture]
    public class ProductTestRepositoryTests
    {
        [TestCase("Carpet", 2.25, 2.10)]
        [TestCase("Laminate", 1.75, 2.10)]
        [TestCase("Tile", 3.50, 4.15)]
        [TestCase("Wood", 5.15, 4.75)]
        public void ProductPairsTest(string productType, decimal costPerSquareFoot, decimal laborCostPerSquareFoot)
        {
            SystemManager manager = new SystemManager(OrderRepositoryFactory.Create("Test"), ProductRepositoryFactory.Create("Test"), TaxRepositoryFactory.Create("Test"));

            var productPairInfo = manager.GetProductPricePairs(productType);

            Assert.IsNotNull(productPairInfo);

            Assert.AreEqual(productType, productPairInfo.ProductType);
            Assert.AreEqual(costPerSquareFoot, productPairInfo.MaterialCost);
            Assert.AreEqual(laborCostPerSquareFoot, productPairInfo.LaborCost);
        }

        
        [TestCase("Tile")]
        [TestCase("Carpet")]
        [TestCase("Laminate")]
        [TestCase("Wood")]
        public void ValidateValidProdcutNameTest(string productType)
        {
            SystemManager manager = new SystemManager(OrderRepositoryFactory.Create("Test"), ProductRepositoryFactory.Create("Test"), TaxRepositoryFactory.Create("Test"));
            var result = manager.ValidateProductName(productType);

            Assert.True(result);

        }

        [TestCase("Metal")]
        [TestCase("Lindsey")]
        [TestCase("55")]
        [TestCase("")]
        public void ValidateInvalidProdcutNameTest(string productType)
        {
            SystemManager manager = new SystemManager(OrderRepositoryFactory.Create("Test"), ProductRepositoryFactory.Create("Test"), TaxRepositoryFactory.Create("Test"));
            var result = manager.ValidateProductName(productType);

            Assert.False(result);

        }
    }
}
