using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using FlooringOrderingSystem.Models;
using FlooringOrderingSystem.Models.Responses;
using FlooringOrderingSystem.BLL;

namespace FlooringOrderingSystem.Tests.TestModeTests
{
    [TestFixture]
    public class OrderTestRepositoryTests
    {


        [TestCase(1,"Wise","OH",6.25,"Wood",100,5.15,4.75)]
        public void LoadOrdersTest(int orderNumber, string customerName, string stateAbbreviation, decimal taxRate, string productType, decimal area, decimal costPerSquareFoot, decimal laborCostPerSquareFoot)
        {
            SystemManager manager = new SystemManager();
            var oneOrder = manager.GetSpecificOrder(new DateTime(2013, 06, 01), 1);

            Assert.AreEqual(oneOrder.OrderNumber, orderNumber);
            Assert.AreEqual(oneOrder.CustomerName, customerName);
            Assert.AreEqual(oneOrder.State, stateAbbreviation);
            Assert.AreEqual(oneOrder.TaxRate, taxRate);
            Assert.AreEqual(oneOrder.ProductType, productType);
            Assert.AreEqual(oneOrder.Area, area);
            Assert.AreEqual(oneOrder.CostPerSquareFoot, costPerSquareFoot);
            Assert.AreEqual(oneOrder.LaborCostPerSquareFoot, laborCostPerSquareFoot);

            var materialCost = area * costPerSquareFoot;
            var laborCost = area * laborCostPerSquareFoot;
            var tax = (materialCost + laborCost) * (taxRate / 100);
            var total = materialCost + laborCost + tax;

            Assert.AreEqual(oneOrder.MaterialCost, materialCost);
            Assert.AreEqual(oneOrder.LaborCost, laborCost);
            Assert.AreEqual(oneOrder.Tax, tax);
            Assert.AreEqual(oneOrder.Total, total);

        }


        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        public void UpdateOrderTest(Order order)
        {

        }


        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        public void RemoveOrderTest(Order order)
        {

        }


        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        public void CreateOrderTest(Order order)
        {

        }
    }
}
