﻿using FlooringOrderingSystem.BLL;
using FlooringOrderingSystem.Models;
using FlooringOrderingSystem.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FlooringOrderingSystem.UI.Workflows
{
    public class AddOrderWorkflow
    {
        SystemManager manager;
        Order newOrder = new Order();

        public AddOrderWorkflow(SystemManager manager)
        {
            this.manager = manager;
        }

        public void Execute()
        {
            Console.Clear();
            Console.WriteLine("Add Order");
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("Please enter the following information:");
            
            GetOrderInformation();
            Console.WriteLine();
            Console.WriteLine("Summary:");

            ConsoleIO.ShowOrderSummary(newOrder);
            Console.WriteLine();
            AddOrderConfirmation();
            
            return;
        }

        private void GetOrderInformation()
        {
            GetOrderDateFromUser();
            GetCustomerNameFromUser();
            GetStateFromUser();
            GetProductTypeFromUser();
            GetAreaFromUser();

            GetTaxRateFromTaxFile();
            GetMaterialAndLaborCosts();
        }
        
        public void GetOrderDateFromUser()
        {
            DateTime date;
            bool isValid = false;

            while (!isValid)
            {
                Console.Write("Order Date: ");
                string input = Console.ReadLine();

                if (DateTime.TryParse(input, out date))
                {
                    if (date.CompareTo(DateTime.Today) <= 0)
                    {
                        Console.WriteLine("Order date must be a future date.");
                    }
                    else
                    {
                        newOrder.OrderDate = date;
                        isValid = true;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid date entered...");
                }
            }
        }

        public void GetCustomerNameFromUser()
        {
            bool isValid = false;
            
            while(!isValid)
            {
                Console.Write("Customer Name: ");
                string userInput = Console.ReadLine();
                bool result = userInput.All(c => Char.IsLetterOrDigit(c) || c == '.' || c == ',' || c == ' ');

                if(userInput == "")
                {
                    Console.WriteLine("Customer Name is a required field!");
                }
                else if (!result)
                {
                    Console.WriteLine("Invalid customer name entered. May only use A-Z, 0-9, and periods/commas.");
                }
                else
                {
                    newOrder.CustomerName = userInput;
                    isValid = true;
                }
            }
        }

        public void GetStateFromUser()
        {
            bool isValid = false;
            while (!isValid)
            {
                Console.Write("State Name/Abbreviation: ");
                string userInput = Console.ReadLine();

                if (manager.ValidateStateName(userInput))
                {
                    newOrder.State = userInput;
                    isValid = true;
                }
                else
                {
                    Console.WriteLine("Invalid state entered!");
                }
            }
        }

        public void GetProductTypeFromUser()
        {
            bool isValid = false;
            while (!isValid)
            {
                Console.Write("Product Type: ");
                string userInput = Console.ReadLine();

                if (manager.ValidateProductName(userInput))
                {
                    newOrder.ProductType = userInput;
                    isValid = true;
                }
                else
                {
                    Console.WriteLine("Invalid product type entered!");
                }
            }
        }

        public void GetAreaFromUser()
        {
            decimal area;
            bool isValid = false;

            while (!isValid)
            {
                Console.Write("Area (100 sq. ft. minimum): ");
                string input = Console.ReadLine();

                if (decimal.TryParse(input, out area))
                {
                    if (area < 100)
                    {
                        Console.WriteLine("Area must be greater than 100 square feet!");
                    }
                    else
                    {
                        newOrder.Area = area;
                        isValid = true;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid area entered...");
                }
            }
        }

        

        private void GetMaterialAndLaborCosts()
        {
            ProductPricePairs pricePairs = manager.GetProductPricePairs(newOrder.ProductType);
            newOrder.CostPerSquareFoot = pricePairs.MaterialCost;
            newOrder.LaborCostPerSquareFoot = pricePairs.LaborCost;
        }



        private void GetTaxRateFromTaxFile()
        {
            StateNamePairs statepairs = manager.GetStateNamePairs(newOrder.State);
            newOrder.TaxRate = statepairs.TaxRate;
        }
        
        private void AddOrderConfirmation()
        {
            bool isValid = false;
            while (!isValid)
            {
                Console.Write("Would you like to add this order? (Y/N): ");
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
                    Console.WriteLine("Order was not added. Press any key to return to Main Menu...");
                    Console.ReadKey();
                    isValid = true;
                }
                else
                {
                    manager.GetCreateOrder(newOrder);
                    Console.WriteLine();
                    Console.WriteLine("Order has been successfully added!");
                    Console.WriteLine($"Your order number is {newOrder.OrderNumber}.");
                    Console.WriteLine("Press any key to return to Main Menu...");
                    Console.ReadKey();
                    isValid = true;
                }
            }
        }
    }
}
