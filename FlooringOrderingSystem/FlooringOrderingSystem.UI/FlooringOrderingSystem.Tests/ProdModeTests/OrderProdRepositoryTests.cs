using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.IO;
using FlooringOrderingSystem.BLL;
using FlooringOrderingSystem.Models;

namespace FlooringOrderingSystem.Tests.ProdModeTests
{
    [TestFixture]
    public class OrderProdRepositoryTests
    {
        private const string _directoryPath = @"C:\Repos\bitbucket\dotnet-lindsey-parlow\FlooringOrderingSystem\ProdOrderFilesTest";
        private const string _seedDirectoryPath = @"C:\Repos\bitbucket\dotnet-lindsey-parlow\FlooringOrderingSystem\ProdOrderFilesSeed";

        private void ResetFiles()
        {
            if (Directory.Exists(_directoryPath))
            {
                var testFileNames = Directory.GetFiles(_directoryPath, "*.txt");

                foreach (var file in testFileNames)
                {
                    var source = file;

                    File.Delete(source);
                }
                Directory.Delete(_directoryPath);
            }
            Directory.CreateDirectory(_directoryPath);

            var fileNames = Directory.GetFiles(_seedDirectoryPath, "*.txt");

            foreach (var file in fileNames)
            {
                var source = file;
                var destination = Path.Combine(_directoryPath, file.Split('\\').Last());

                File.Copy(source, destination);
            }
        }


        [SetUp]
        public void Setup()
        {
            ResetFiles();
        }

        [TearDown]
        public void TearDown()
        {
            //ResetFiles();
        }


        [TestCase(1, "Paulson, That Dood", "MI", 5.75, "Wood", 200, 5.15, 4.75, "10/9/17")]
        public void CreateOrderTests(int orderNumber, string customerName, string stateAbbreviation, decimal taxRate, string productType, decimal area, decimal costPerSquareFoot, decimal laborCostPerSquareFoot, string date)
        {
            SystemManager manager = new SystemManager(OrderRepositoryFactory.Create("Prod"), ProductRepositoryFactory.Create("Prod"), TaxRepositoryFactory.Create("Prod"));

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

        [TestCase(1, "Angell, Inc.", "IN", 6.00, "Carpet", 150, 2.25, 2.10, "10/13/17")]
        public void LoadOrderTest(int orderNumber, string customerName, string stateAbbreviation, decimal taxRate, string productType, decimal area, decimal costPerSquareFoot, decimal laborCostPerSquareFoot, string date)
        {
            SystemManager manager = new SystemManager(OrderRepositoryFactory.Create("Prod"), ProductRepositoryFactory.Create("Prod"), TaxRepositoryFactory.Create("Prod"));

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

        [TestCase(1, "Angell, Inc.", "IN", 6.00, "Carpet", 150, 2.25, 2.10, "10/13/17")]
        public void RemoveOrderTests(int orderNumber, string customerName, string stateAbbreviation, decimal taxRate, string productType, decimal area, decimal costPerSquareFoot, decimal laborCostPerSquareFoot, string date)
        {
            SystemManager manager = new SystemManager(OrderRepositoryFactory.Create("Prod"), ProductRepositoryFactory.Create("Prod"), TaxRepositoryFactory.Create("Prod"));

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

        [TestCase(1, "Lindsey, Inc.", "PA", 6.75, "Laminate", 175, 1.75, 2.10, "10/13/17")]
        public void UpdateOrderTests(int orderNumber, string customerName, string stateAbbreviation, decimal taxRate, string productType, decimal area, decimal costPerSquareFoot, decimal laborCostPerSquareFoot, string date)
        {
            SystemManager manager = new SystemManager(OrderRepositoryFactory.Create("Prod"), ProductRepositoryFactory.Create("Prod"), TaxRepositoryFactory.Create("Prod"));

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

    }
}
