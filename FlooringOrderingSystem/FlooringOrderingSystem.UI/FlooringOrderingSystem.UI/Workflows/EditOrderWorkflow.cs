using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringOrderingSystem.BLL;
using FlooringOrderingSystem.Models;
using FlooringOrderingSystem.Models.Responses;

namespace FlooringOrderingSystem.UI.Workflows
{
    public class EditOrderWorkflow
    {
        private SystemManager manager;

        public EditOrderWorkflow(SystemManager manager)
        {
            this.manager = manager;
        }

        public void Execute()
        {
            Console.Clear();
            Console.WriteLine("Edit Order");
            Console.WriteLine("-------------------------------------------");

            DisplayOrderResponse response = FindOrderToEdit();
            if (response.Success)
            {
                Order order = response.Orders.First();

                ChangeableFieldsPrompts(order);

                Console.WriteLine();
                ConsoleIO.ShowOrderSummary(order);

                EditOrderConfirmation(order);
            }
            return;
        }

        private void ChangeableFieldsPrompts(Order order)
        {
            Console.WriteLine("Enter data for field or bypass a field with Enter");
            ChangeNamePrompt(order);
            ChangeStatePrompt(order);
            ChangeProductTypePrompt(order);
            ChangeAreaPrompt(order);
        }

        public DisplayOrderResponse FindOrderToEdit()
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



        public void ChangeNamePrompt(Order order)
        {
            bool isValid = false;

            while (!isValid)
            {
                Console.Write($"Customer Name ({order.CustomerName}): ");
                string userInput = Console.ReadLine();
                bool result = userInput.All(c => Char.IsLetterOrDigit(c) || c == '.' || c == ',' || c == ' ');

                if (userInput == "")
                {
                    isValid = true;
                }
                else if (!result)
                {
                    Console.WriteLine("Invalid customer name entered. May only use A-Z, 0-9, and periods/commas.");
                }
                else
                {
                    order.CustomerName = userInput;
                    isValid = true;
                }
            }
        }


        public void ChangeStatePrompt(Order order)
        {
            bool isValid = false;
            while (!isValid)
            {
                Console.Write($"State Name/Abbreviation ({order.State}): ");
                string userInput = Console.ReadLine();

                if (userInput == "")
                {
                    isValid = true;
                }
                else if (manager.ValidateStateName(userInput))
                {
                    order.State = userInput;
                    isValid = true;
                }
                else
                {
                    Console.WriteLine("Invalid state entered!");
                }
            }
        }
    

        public void ChangeProductTypePrompt(Order order)
        {
            bool isValid = false;
            while (!isValid)
            {
                Console.Write($"Product Type ({order.ProductType}): ");
                string userInput = Console.ReadLine();

                if (userInput == "")
                {
                    isValid = true;
                }
                else if (manager.ValidateProductName(userInput))
                {
                    order.ProductType = userInput;
                    isValid = true;
                }
                else
                {
                    Console.WriteLine("Invalid product type entered!");
                }
            }
        }

        public void ChangeAreaPrompt(Order order)
        {
            decimal area;
            bool isValid = false;

            while (!isValid)
            {
                Console.Write($"Area (100 sq. ft. minimum) ({order.Area}): ");
                string input = Console.ReadLine();

                if (decimal.TryParse(input, out area))
                {
                    if (area < 100)
                    {
                        Console.WriteLine("Area must be greater than 100 square feet!");
                    }
                    else
                    {
                        order.Area = area;
                        isValid = true;
                    }
                }
                else
                {
                    if (input == "")
                    {
                        isValid = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid area entered...");
                    }
                }
            }
        }

        private void EditOrderConfirmation(Order order)
        {
            bool isValid = false;
            
            while (!isValid)
            {
                Console.WriteLine("Would you like to save your changes? (Y/N): ");
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
                    Console.WriteLine("Edits not saved. Press any key to return to Main Menu...");
                    Console.ReadKey();
                    isValid = true;
                }
                else
                {
                    manager.GetUpdateOrder(order);
                    Console.WriteLine();
                    Console.WriteLine("Order has been successfully edited. Press any key to return to main menu.");
                    Console.ReadKey();
                    isValid = true;
                }
            }
        }
    }
}
