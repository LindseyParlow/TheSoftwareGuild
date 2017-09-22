using FlooringOrderingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringOrderingSystem.UI
{
    public class ConsoleIO
    {
        public static void DisplayOrderDetails(List<Order> Orders)
        {
            foreach(var order in Orders)
            {
                Console.WriteLine($"Order Numer: {order.OrderNumber}");
                Console.WriteLine($"Order Date: {order.OrderDate}");
                Console.WriteLine($"Customer Name: {order.CustomerName}");
                Console.WriteLine($"State: {order.State}");
                Console.WriteLine($"Product: {order.ProductType}");
                Console.WriteLine($"Materials: {order.MaterialCost:c}");
                Console.WriteLine($"Labor: {order.LaborCost:c}");
                Console.WriteLine($"Tax: {order.Tax:c}");
                Console.WriteLine($"Total: {order.Total:c}");
                Console.WriteLine();
            }
        }

        public static void ShowAddOrderSummary(Order newOrder)
        {
            Console.WriteLine($"Order Date: {newOrder.OrderDate}");
            Console.WriteLine($"Customer Name: {newOrder.CustomerName}");
            Console.WriteLine($"State: {newOrder.State}");
            Console.WriteLine($"Product: {newOrder.ProductType}");
            Console.WriteLine($"Area: {newOrder.Area}");
            Console.WriteLine($"Material Cost (per sq. ft.): {newOrder.CostPerSquareFoot}");
            Console.WriteLine($"Labor Cost (per sq. ft.): {newOrder.LaborCostPerSquareFoot}");
            Console.WriteLine($"Materials: {newOrder.MaterialCost}");
            Console.WriteLine($"Labor: {newOrder.LaborCost}");
            Console.WriteLine($"Tax Rate: {newOrder.TaxRate}");
            Console.WriteLine($"Tax: {newOrder.Tax}");
            Console.WriteLine($"Total: {newOrder.Total}");
        }
    }
}
