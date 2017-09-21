using FlooringOrderingSystem.BLL;
using FlooringOrderingSystem.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
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
            AddOrderSummary();
            AddOrderConfirmation();
            //make sure to tell customer their order number
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
                Console.Write("Enter an Order Date: ");
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
            Console.Write("Customer Name: ");
            newOrder.CustomerName = Console.ReadLine();

            //hey do something with RegEx to make this work
            //if input is blank, error message and reprompt for name
            //if input is not a-z/0-9/periods/commas, error message and reprompt for name

            //if meets requirements, continue to next field
        }

        public void GetStateFromUser()
        {
            Console.Write("State: ");
            newOrder.State = Console.ReadLine();


            //if input doens't match a state we sell to, error message and reprompt for state

            //if meets requirements, continue to next field
        }

        public void GetProductTypeFromUser()
        {
            bool isValid = false;
            while(!isValid)
            {
                Console.Write("Product Type: ");
                string userInput = Console.ReadLine();

                if(manager.ValidateProductName(userInput))
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
            var pricePairs = manager.GetProductPricePairs(newOrder.ProductType);
            newOrder.CostPerSquareFoot = pricePairs.MaterialCost;
            newOrder.LaborCostPerSquareFoot = pricePairs.LaborCost;
        }



        private void GetTaxRateFromTaxFile()
        {
            throw new NotImplementedException();
        }

        public void AddOrderSummary()
        {
            //should I use something like the DiplayOrderDetails or do I need to create an AddOrderDetails and feed it this info?
            //should I really inclue the per sq ft fields or just the totals?

            //newOrder.OrderDate
            //newOrder.CustomerName;
            //newOrder.State;
            //newOrder.ProductType;
            //newOrder.Area;
            //newOrder.CostPerSquareFoot;
            //newOrder.LaborCostPerSquareFoot;
            //newOrder.MaterialCost;
            //newOrder.LaborCost;
            //newOrder.TaxRate;
            //newOrder.Tax;
            //newOrder.Total;
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
                    //maybe do an "are you sure"
                    //make sure order didn't get saved
                    Console.WriteLine();
                    Console.WriteLine("Order was not added. Press any key to return to Main Menu...");
                    Console.ReadKey();
                    isValid = true;
                }
                else
                {
                    //save order: if first for day, create new file and write order into that file. make sure file gets proper name and is order #1
                    //if not first order for day, write order into proper file and make sure it is order #(last order number + 1)
                    Console.WriteLine();
                    Console.WriteLine("Order has been added. Press any key to return to main menu.");
                    Console.ReadKey();
                    isValid = true;
                }
            }
        }
    }
}
