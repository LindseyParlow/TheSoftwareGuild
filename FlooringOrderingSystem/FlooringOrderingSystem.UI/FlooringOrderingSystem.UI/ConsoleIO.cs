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

        public static void ShowOrderSummary(Order order)
        {
            Console.WriteLine($"Order Date: {order.OrderDate}");
            Console.WriteLine($"Customer Name: {order.CustomerName}");
            Console.WriteLine($"State: {order.State}");
            Console.WriteLine($"Product: {order.ProductType}");
            Console.WriteLine($"Area: {order.Area}");
            Console.WriteLine($"Material Cost(per sq. ft.): {order.CostPerSquareFoot:c}");
            Console.WriteLine($"Total Cost of Materials: {order.MaterialCost:c}");
            Console.WriteLine($"Labor Cost(per sq. ft.): {order.LaborCostPerSquareFoot:c}");
            Console.WriteLine($"Total Cost of Labor: {order.LaborCost:c}");
            Console.WriteLine($"Tax Rate: {order.TaxRate}");
            Console.WriteLine($"Tax: {order.Tax:c}");
            Console.WriteLine($"Total: {order.Total:c}");
        }

        
    }
}
