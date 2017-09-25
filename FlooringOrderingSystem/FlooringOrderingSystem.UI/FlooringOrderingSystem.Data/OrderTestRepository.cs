using FlooringOrderingSystem.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringOrderingSystem.Models;
using System.IO;

namespace FlooringOrderingSystem.Data
{
    public class OrderTestRepository : IOrderRepository
    {
        private static List<MockOrderFile> MockFiles = new List<MockOrderFile>()
        {
            new MockOrderFile()
            {
                fileName = "Orders_06012013",
                Orders = new List<Order>()
                {
                    new Order
                    {
                        OrderNumber = 1,
                        CustomerName = "Wise",
                        State = "OH",
                        TaxRate = 6.25M,
                        ProductType = "Wood",
                        Area = 100.00M,
                        CostPerSquareFoot = 5.15M,
                        LaborCostPerSquareFoot = 4.75M,
                        OrderDate = new DateTime(2013, 06, 01)
                    }
                }
            },
            new MockOrderFile()
            {
                fileName = "Orders_11112017",
                Orders = new List<Order>()
                {
                    new Order
                    {
                        OrderNumber = 1,
                        CustomerName = "Parlow",
                        State = "PA",
                        TaxRate = 6.75M,
                        ProductType = "Tile",
                        Area = 300.00M,
                        CostPerSquareFoot = 3.50M,
                        LaborCostPerSquareFoot = 4.15M,
                        OrderDate = new DateTime(2017, 11, 11)
                    },
                    new Order
                    {
                        OrderNumber = 2,
                        CustomerName = "Angell",
                        State = "IN",
                        TaxRate = 6.00M,
                        ProductType = "Carpet",
                        Area = 200.00M,
                        CostPerSquareFoot = 2.25M,
                        LaborCostPerSquareFoot = 2.10M,
                        OrderDate = new DateTime(2017, 11, 11)
                    }
                }
            }
        };
        
        private static Order _order = new Order
        {
            OrderNumber = 1,
            CustomerName = "Wise",
            State = "OH",
            TaxRate = 6.25M,
            ProductType = "Wood",
            Area = 100.00M,
            CostPerSquareFoot = 5.15M,
            LaborCostPerSquareFoot = 4.75M,
            OrderDate = new DateTime(2013, 06, 01)
        };
        
        public List<Order> LoadOrders(DateTime orderDate)
        {
            MockOrderFile MockFile = MockFiles.FirstOrDefault(f => f.fileName.Contains(String.Format("{0:MMddyyyy}", orderDate)));

            if(MockFile == null)
            {
                return null;
            }

            return MockFile.Orders;
        }

        public void UpdateOrder(Order order)
        {
            MockOrderFile MockFile = MockFiles.FirstOrDefault(f => f.fileName.Contains(String.Format("{0:MMddyyyy}", order.OrderDate)));
            Order orderToFind = MockFile.Orders.FirstOrDefault(o => o.OrderNumber == order.OrderNumber);

            orderToFind.CustomerName = order.CustomerName;
            orderToFind.State = order.State;
            orderToFind.ProductType = order.ProductType;
            orderToFind.Area = order.Area;
        }

        public void RemoveOrder(Order order)
        {
            MockOrderFile MockFile = MockFiles.FirstOrDefault(f => f.fileName.Contains(String.Format("{0:MMddyyyy}", order.OrderDate)));
            Order orderToFind = MockFile.Orders.FirstOrDefault(o => o.OrderNumber == order.OrderNumber);
            MockFile.Orders.Remove(orderToFind);

            if(MockFile.Orders.Count == 0)
            {
                MockFiles.Remove(MockFile);
            }
        }

        public void CreateOrder(Order order)
        {
            MockOrderFile MockFile = (MockFiles.FirstOrDefault(f => f.fileName.Contains(String.Format("{0:MMddyyyy}", order.OrderDate))));

            if (MockFile == null)
            {
                MockFile = new MockOrderFile() { fileName = "Orders_" + String.Format("{0:MMddyyyy}", order.OrderDate) };
            }

            if (MockFile.Orders.Count == 0)
            {
                order.OrderNumber = 1;
            }
            else
            {
                order.OrderNumber = MockFile.Orders.Max(o => o.OrderNumber) + 1;
            }

            MockFile.Orders.Add(order);
            
        }
    }
}
