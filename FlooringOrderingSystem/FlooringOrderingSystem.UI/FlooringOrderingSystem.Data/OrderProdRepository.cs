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
    public class OrderProdRepository : IOrderRepository
    {
        private static string orderDirectoryPath = string.Empty;

        public OrderProdRepository(string prodFilesDirectoryPath)
        {
            orderDirectoryPath = prodFilesDirectoryPath;
        }

        private void WriteOrders(string filePath, List<Order> ordersList)
        {
            if (File.Exists(filePath))
                File.Delete(filePath);

            using (StreamWriter sw = new StreamWriter(filePath))
            {
                sw.WriteLine("OrderNumber,CustomerName,State,TaxRate,ProductType,Area,CostPerSquareFoot,LaborCostPerSquareFoot,MaterialCost,LaborCost,Tax,Total");
                foreach (var order in ordersList)
                {
                    string orderstring = "";

                    orderstring += order.OrderNumber.ToString() + ";";
                    orderstring += order.CustomerName + ";";
                    orderstring += order.State + ";";
                    orderstring += order.TaxRate.ToString() + ";";
                    orderstring += order.ProductType + ";";
                    orderstring += order.Area.ToString() + ";";
                    orderstring += order.CostPerSquareFoot.ToString() + ";";
                    orderstring += order.LaborCostPerSquareFoot.ToString() + ";";
                    orderstring += order.MaterialCost.ToString() + ";";
                    orderstring += order.LaborCost.ToString() + ";";
                    orderstring += order.Tax.ToString() + ";";
                    orderstring += order.Total.ToString();

                    sw.WriteLine(orderstring);
                }
            }
        }

        public void CreateOrder(Order order)
        {
            List<Order> orders = this.LoadOrders(order.OrderDate);

            if (orders == null)
            {
                orders = new List<Order>();
            }

            if (orders.Count == 0)
            {
                order.OrderNumber = 1;
            }
            else
            {
                order.OrderNumber = orders.Max(o => o.OrderNumber) + 1;
            }
            
            orders.Add(order);
            WriteOrders(MakeFilePath(order.OrderDate), orders);
        }

        private string MakeFilePath(DateTime orderDate)
        {
            return Path.Combine(orderDirectoryPath, "Order_" + String.Format("{0:MMddyyyy}", orderDate) + ".txt");
        }

        public List<Order> LoadOrders(DateTime OrderDate)
        {
            List<Order> ProdFiles = new List<Order>();

            try
            {
                var fileName = "Order_" + String.Format("{0:MMddyyyy}", OrderDate) + ".txt";
                if (File.Exists(MakeFilePath(OrderDate)))
                {
                    using (StreamReader sr = new StreamReader(MakeFilePath(OrderDate)))
                    {
                        sr.ReadLine();
                        string line;

                        while ((line = sr.ReadLine()) != null)
                        {
                            Order newOrder = new Order();

                            string[] columns = line.Split(';');


                            newOrder.OrderNumber = int.Parse(columns[0]);
                            newOrder.CustomerName = columns[1];
                            newOrder.State = columns[2];
                            newOrder.TaxRate = decimal.Parse(columns[3]);
                            newOrder.ProductType = columns[4];
                            newOrder.Area = decimal.Parse(columns[5]);
                            newOrder.CostPerSquareFoot = decimal.Parse(columns[6]);
                            newOrder.LaborCostPerSquareFoot = decimal.Parse(columns[7]);
                            newOrder.OrderDate = OrderDate;

                            ProdFiles.Add(newOrder);
                        }
                    }
                }
                else
                {
                    return null;
                }

                
            }
            catch(Exception ex)
            {
                Console.WriteLine($"An error occurred reading the file: {ex.Message}");
                Console.WriteLine($"The error happened at: {ex.StackTrace}");
                Console.Write("Press any key to continue...");
                Console.ReadKey();
                throw;
            }
            return ProdFiles;
        }

        public void RemoveOrder(Order order)
        {
            List<Order> orders = this.LoadOrders(order.OrderDate);

            var orderToDelete = orders.Where(o => o.OrderNumber == order.OrderNumber).First();

            orders.Remove(orderToDelete);

            if(orders.Count == 0)
            {
                File.Delete(MakeFilePath(order.OrderDate));
            }
            else
            {
                WriteOrders(MakeFilePath(order.OrderDate), orders);
            }
        }

        public void UpdateOrder(Order order)
        {
            List<Order> orders = this.LoadOrders(order.OrderDate);

            var orderToDelete = orders.Where(o => o.OrderNumber == order.OrderNumber).First();

            orders.Remove(orderToDelete);
            orders.Add(order);

            WriteOrders(MakeFilePath(order.OrderDate), orders);
        }
        
    }
}
