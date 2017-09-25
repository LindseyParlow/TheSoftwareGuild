using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringOrderingSystem.BLL;
using FlooringOrderingSystem.Models.Responses;
using FlooringOrderingSystem.Models;

namespace FlooringOrderingSystem.UI.Workflows
{
    public class RemoveOrderWorkflow
    {
        private SystemManager manager;

        public RemoveOrderWorkflow(SystemManager manager)
        {
            this.manager = manager;
        }

        public void Execute()
        {
            Console.Clear();
            Console.WriteLine("Remove Order");
            Console.WriteLine("-------------------------------------------");

            DisplayOrderResponse response = FindOrderToRemove();
            if (response.Success)
            {
                Order order = response.Orders.First();

                RemoveOrderConfirmation(order);
            }
            
            return;
        }

        

        public DisplayOrderResponse FindOrderToRemove()
        {
            DateTime userOrderDate = DateTime.MinValue;
            bool isValid = false;

            while (!isValid)
            {
                Console.Write("Enter Order Date of order to edit: ");
                string userInput = Console.ReadLine();

                if (DateTime.TryParse(userInput, out userOrderDate))
                {
                    isValid = true;
                }
                else
                {
                    Console.WriteLine("Invalid date entered...");
                }
            }

            isValid = false;
            int userOrderNumber = 0;
            while (!isValid)
            {
                Console.Write("Enter Order Number of order to edit: ");
                string userInput = Console.ReadLine();

                if (int.TryParse(userInput, out userOrderNumber))
                {
                    isValid = true;
                }
                else
                {
                    Console.WriteLine("Invalid order number entered...");
                }
            }

            Order order = manager.GetSpecificOrder(userOrderDate, userOrderNumber);
            DisplayOrderResponse response = new DisplayOrderResponse();

            if (order == null)
            {
                Console.WriteLine("Order not found!");
                response.Success = false;
                return response;
            }
            else
            {
                Console.WriteLine();
                ConsoleIO.ShowOrderSummary(order);
                Console.WriteLine();
                response.Success = true;
                List<Order> SpecificOrderList = new List<Order>();
                SpecificOrderList.Add(order);
                response.Orders = SpecificOrderList;
            }
            return response;
        }

        private void RemoveOrderConfirmation(Order order)
        {
            bool isValid = false;
            while (!isValid)
            {
                Console.Write("Would you like to remove this order? (Y/N): ");
                string userInput = Console.ReadLine().ToLower();

                if (userInput != "y" && userInput != "n")
                {
                    Console.WriteLine();
                    Console.WriteLine("Invalid response. Answer must be Y/N...");
                    isValid = false;
                }
                else if (userInput == "n")
                {
                    Console.WriteLine();
                    Console.WriteLine("Order not removed. Press any key to return to Main Menu...");
                    Console.ReadKey();
                    isValid = true;
                }
                else
                {
                    manager.ConfirmRemoveOrder(order);
                    Console.WriteLine();
                    Console.WriteLine("Order has been removed. Press any key to return to Main Menu.");
                    Console.ReadKey();
                    isValid = true;
                }
            }
        }
    }
}
