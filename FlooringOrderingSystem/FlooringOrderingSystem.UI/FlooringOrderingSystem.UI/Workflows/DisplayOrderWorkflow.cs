using FlooringOrderingSystem.BLL;
using FlooringOrderingSystem.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringOrderingSystem.UI.Workflows
{
    public class DisplayOrderWorkflow
    {
        private SystemManager manager;

        public DisplayOrderWorkflow(SystemManager manager)
        {
            this.manager = manager;
        }

        public void Execute()
        {
            Console.Clear();
            Console.WriteLine("Diplay Orders");
            Console.WriteLine("-----------------------------------------------");
            Console.Write("Enter date of the order to look up: ");
            string orderDate = Console.ReadLine();

            //Need to figure out Displaying all orders based on the date of an order..
            DisplayOrderResponse response = manager.DisplayOrder(orderDate);

            if(response.Success)
            {
                ConsoleIO.DisplayOrderDetails(response.Order);
            }
            else
            {
                Console.WriteLine(response.Message);
            }
            Console.WriteLine();
            Console.WriteLine("Press any key to return to Main Menu");
            Console.ReadKey();
        }
    }
}
