using FlooringOrderingSystem.BLL;
using FlooringOrderingSystem.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringOrderingSystem.UI.Workflows
{
    public class OrderDisplayWorkflow
    {
        public void Execute()
        {
            OrderManager manager = OrderManagerFactory.Create();

            Console.Clear();
            Console.WriteLine("Diplay Orders");
            Console.WriteLine("-------------------------");
            Console.Write("Enter date of the order to look up: ");
            string orderDate = Console.ReadLine();

            //Need to figure out Displaying all orders based on the date of an order. Not based on the Order number.
            OrderDisplayResponse response = manager.DisplayOrder(orderDate);

            if(response.Success)
            {
                ConsoleIO.DisplayOrderDetails(response.Order);
            }
            else
            {
                Console.WriteLine("An error occurred:");
                Console.WriteLine(response.Message);
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
