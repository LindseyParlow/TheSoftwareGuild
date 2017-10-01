using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using FlooringOrderingSystem.Models;
using FlooringOrderingSystem.Models.Responses;
using FlooringOrderingSystem.BLL;
using FlooringOrderingSystem.Models.Interfaces;

namespace FlooringOrderingSystem.Tests.TestModeTests
{
    [TestFixture]
    public class OrderTestRepositoryTests
    {

        [TestCase(1,"Wise","OH",6.25,"Wood",100,5.15,4.75,"6/1/13")]
        public void LoadOrdersTest(int orderNumber, string customerName, string stateAbbreviation, decimal taxRate, string productType, decimal area, decimal costPerSquareFoot, decimal laborCostPerSquareFoot, string date)
        {
            SystemManager manager = new SystemManager(OrderRepositoryFactory.Create("Test"), ProductRepositoryFactory.Create("Test"), TaxRepositoryFactory.Create("Test"));

            DateTime orderDate = DateTime.Parse(date);

            var result = manager.GetSpecificOrder(orderDate, orderNumber);

            Assert.IsNotNull(result, "Result is null.");
            Assert.AreEqual(orderNumber, result.OrderNumber, "Order numbers don't match.");
            Assert.AreEqual(customerName, result.CustomerName, "Customer names don't match.");
            Assert.AreEqual(stateAbbreviation, result.State, "States don't match.");
            Assert.AreEqual(taxRate, result.TaxRate, "Tax rates don't match.");
            Assert.AreEqual(productType, result.ProductType, "Product types don't match.");
            Assert.AreEqual(area, result.Area, "Areas don't match.");
            Assert.AreEqual(costPerSquareFoot, result.CostPerSquareFoot, "Cost per sq. ft. doesn't match.");
            Assert.AreEqual(laborCostPerSquareFoot, result.LaborCostPerSquareFoot, "Labor cost per sq. ft. doesn't match.");
        }


        
        [TestCase(1, "Johnson", "MI", 5.75, "Tile", 110, 5.15, 4.75, "6/1/13")]
        public void UpdateOrderTest(int orderNumber, string customerName, string stateAbbreviation, decimal taxRate, string productType, decimal area, decimal costPerSquareFoot, decimal laborCostPerSquareFoot, string date)
        {
            SystemManager manager = new SystemManager(OrderRepositoryFactory.Create("Test"), ProductRepositoryFactory.Create("Test"), TaxRepositoryFactory.Create("Test"));

            Order order = new Order()
            {
                OrderNumber = orderNumber,
                CustomerName = customerName,
                State = stateAbbreviation,
                TaxRate = taxRate,
                ProductType = productType,
                Area = area,
                CostPerSquareFoot = costPerSquareFoot,
                LaborCostPerSquareFoot = laborCostPerSquareFoot,
                OrderDate = DateTime.Parse(date)
            };

            Order oldOrder = manager.GetSpecificOrder(order.OrderDate, order.OrderNumber);
            manager.GetUpdateOrder(order);
            Order result = manager.GetSpecificOrder(order.OrderDate, order.OrderNumber);

            Assert.IsNotNull(result, "Result is null.");

            Assert.AreNotEqual(order.CustomerName, oldOrder.CustomerName);
            Assert.AreNotEqual(order.State, oldOrder.State);
            Assert.AreNotEqual(order.ProductType, oldOrder.ProductType);
            Assert.AreNotEqual(order.Area, oldOrder.Area);


        }


        [TestCase(1,"Wise","OH",6.25,"Wood",100,5.15,4.75, "6/1/13")]
        public void RemoveOrderTest(int orderNumber, string customerName, string stateAbbreviation, decimal taxRate, string productType, decimal area, decimal costPerSquareFoot, decimal laborCostPerSquareFoot, string date)
        {
            SystemManager manager = new SystemManager(OrderRepositoryFactory.Create("Test"), ProductRepositoryFactory.Create("Test"), TaxRepositoryFactory.Create("Test"));

            Order order = new Order()
            {
                OrderNumber = orderNumber,
                CustomerName = customerName,
                State = stateAbbreviation,
                TaxRate = taxRate,
                ProductType = productType,
                Area = area,
                CostPerSquareFoot = costPerSquareFoot,
                LaborCostPerSquareFoot = laborCostPerSquareFoot,
                OrderDate = DateTime.Parse(date)
            };

            Order oldOrder = manager.GetSpecificOrder(order.OrderDate, order.OrderNumber);
            manager.ConfirmRemoveOrder(order);
            Order result = manager.GetSpecificOrder(order.OrderDate, order.OrderNumber);

            Assert.IsNull(result);
        }

        
        [TestCase(1, "Parlow", "IN", 6.00, "Carpet", 150, 2.25, 2.10, "10/02/17")]
        public void CreateOrderTest(int orderNumber, string customerName, string stateAbbreviation, decimal taxRate, string productType, decimal area, decimal costPerSquareFoot, decimal laborCostPerSquareFoot, string date)
        {
            SystemManager manager = new SystemManager(OrderRepositoryFactory.Create("Test"), ProductRepositoryFactory.Create("Test"), TaxRepositoryFactory.Create("Test"));

            Order order = new Order()
            {
                OrderNumber = orderNumber,
                CustomerName = customerName,
                State = stateAbbreviation,
                TaxRate = taxRate,
                ProductType = productType,
                Area = area,
                CostPerSquareFoot = costPerSquareFoot,
                LaborCostPerSquareFoot = laborCostPerSquareFoot,
                OrderDate = DateTime.Parse(date)
            };

            Order oldOrder = manager.GetSpecificOrder(order.OrderDate, order.OrderNumber);
            Assert.IsNull(oldOrder);

            manager.GetCreateOrder(order);
            Order result = manager.GetSpecificOrder(order.OrderDate, order.OrderNumber);

            Assert.IsNotNull(result);
            Assert.AreEqual(orderNumber, order.OrderNumber);
            Assert.AreEqual(customerName, order.CustomerName);
            Assert.AreEqual(stateAbbreviation, order.State);
            Assert.AreEqual(taxRate, order.TaxRate);
            Assert.AreEqual(productType, order.ProductType);
            Assert.AreEqual(area, order.Area);
            Assert.AreEqual(costPerSquareFoot, order.CostPerSquareFoot);
            Assert.AreEqual(laborCostPerSquareFoot, order.LaborCostPerSquareFoot);
            Assert.AreEqual(DateTime.Parse(date), order.OrderDate);
        }
    }
}
