using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringOrderingSystem.BLL;

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

            FindOrderToEdit();

            ChangeableFieldsPrompts();
            
            EditOrderSummary();

            EditOrderConfirmation();
            
            
            return;

        }
        
        private void ChangeableFieldsPrompts()
        {
            ChangeNamePrompt();
            ChangeStatePrompt();
            ChangeProductTypePrompt();
            ChangeAreaPrompt();
        }

        public void FindOrderToEdit()
        {
            Console.WriteLine("Enter Order Date of order to edit: ");
            string userOrderDate = Console.ReadLine();

            Console.WriteLine("Enter Order Number of order to edit: ");
            string userOrderNumber = Console.ReadLine();

            //use dictionary to find date and within the date, that order number using string userOrderDate and userOrderNumber
            //still need to deal with dates being strings instead of DateTime variables

            //if order is found, display the order
            //if order is not found, display message to user and press any key to return to main menu
        }

        public void ChangeNamePrompt()
        {
            bool isValid = false;

            while(!isValid)
            {
                Console.WriteLine("Would you like to change the Customer Name? (Y/N): ");
                string userInput = Console.ReadLine().ToLower();

                if (userInput != "y" && userInput != "n")
                {
                    Console.WriteLine("Invalid response. Answer must be Y/N...");
                    isValid = false;
                }
                else if (userInput == "n")
                {
                    //maybe give message that name was not changed
                    //continue to next field
                    isValid = true;
                }
                else
                {
                    Console.WriteLine("Enter new Customer Name: ");
                    //make it so this replaces the other name
                    //continue to next field
                    isValid = true;
                }
            }
        }

        public void ChangeStatePrompt()
        {
            bool isValid = false;

            while (!isValid)
            {
                Console.WriteLine("Would you like to change the State? (Y/N): ");
                string userInput = Console.ReadLine().ToLower();

                if (userInput != "y" && userInput != "n")
                {
                    Console.WriteLine("Invalid response. Answer must be Y/N...");
                    isValid = false;
                }
                else if (userInput == "n")
                {
                    //maybe give message that state was not changed
                    //continue to next field
                    isValid = true;
                }
                else
                {
                    Console.WriteLine("Enter new State: ");
                    //make it so this replaces the other state
                    //continue to next field
                    isValid = true;
                }
            }
        }

        public void ChangeProductTypePrompt()
        {
            bool isValid = false;

            while (!isValid)
            {
                Console.WriteLine("Would you like to change the Product Type? (Y/N): ");
                string userInput = Console.ReadLine().ToLower();

                if (userInput != "y" && userInput != "n")
                {
                    Console.WriteLine("Invalid response. Answer must be Y/N...");
                    isValid = false;
                }
                else if (userInput == "n")
                {
                    //maybe give message that product type was not changed
                    //continue to next field
                    isValid = true;
                }
                else
                {
                    Console.WriteLine("Enter new Product Type: ");
                    //make it so this replaces the other product type
                    //continue to next field
                    isValid = true;
                }
            }
        }

        public void ChangeAreaPrompt()
        {
            bool isValid = false;

            while (!isValid)
            {
                Console.WriteLine("Would you like to change the Area? (Y/N): ");
                string userInput = Console.ReadLine().ToLower();

                if (userInput != "y" && userInput != "n")
                {
                    Console.WriteLine("Invalid response. Answer must be Y/N...");
                    isValid = false;
                }
                else if (userInput == "n")
                {
                    //maybe give message that area was not changed
                    //continue to next field
                    isValid = true;
                }
                else
                {
                    Console.WriteLine("Enter new Area: ");
                    //make it so this replaces the other area
                    //continue to next field
                    isValid = true;
                }
            }
        }

        public void EditOrderSummary()
        {
            //should I use something like the DiplayOrderDetails or do I need to create an AddOrderDetails and feed it this info?
            //should I really inclue the per sq ft fields or just the totals?
            //remember, we are recalulating some of the fields based on new info

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

        private void EditOrderConfirmation()
        {
            bool isValid = false;

            //make an if/else statement... if there were changes made:
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
                    //maybe do an "are you sure"
                    //make sure order stayed how it originally was
                    Console.WriteLine();
                    Console.WriteLine("Edits not saved. Press any key to return to Main Menu...");
                    Console.ReadKey();
                    isValid = true;
                }
                else
                {
                    //overwrite order edits
                    Console.WriteLine();
                    Console.WriteLine("Order has been successfully edited. Press any key to return to main menu.");
                    Console.ReadKey();
                    isValid = true;
                }
            }
            //other part of if/else statement... else if no changes were made Console.WriteLine("No changes were made. Press any key to return to Main Menu...");
        }
    }
}
