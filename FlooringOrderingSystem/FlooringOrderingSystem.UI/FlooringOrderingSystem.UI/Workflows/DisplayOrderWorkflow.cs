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
            
            DateTime date = DateTime.MinValue;
            bool isValid = false;

            while (!isValid)
            {
                Console.Write("Enter date of the order to look up: ");
                string input = Console.ReadLine();
                Console.WriteLine();

                if (DateTime.TryParse(input, out date))
                {
                    isValid = true;
                }
                else
                {
                    Console.WriteLine("Invalid date entered...");
                }
            }

            //Need to figure out Displaying all orders based on the date of an order..
            DisplayOrderResponse response = manager.DisplayOrder(date);

            if(response.Success)
            {
                ConsoleIO.DisplayOrderDetails(response.Orders);
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
