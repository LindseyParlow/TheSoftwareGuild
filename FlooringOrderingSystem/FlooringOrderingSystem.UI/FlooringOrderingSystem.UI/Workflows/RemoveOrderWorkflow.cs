using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringOrderingSystem.BLL;

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

            FindOrderToRemove();

            RemoveOrderConfirmation();

           
            return;
        }

        

        public void FindOrderToRemove()
        {
            Console.WriteLine("Enter Order Date of order to remove: ");
            string userOrderDate = Console.ReadLine();

            Console.WriteLine("Enter Order Number of order to remove: ");
            string userOrderNumber = Console.ReadLine();

            //use dictionary to find date and within the date, that order number using string userOrderDate and userOrderNumber
            //still need to deal with dates being strings instead of DateTime variables

            // if(order is found) 
            // {
            //    display the order
            // }
            // else
            // {
            //    display message to user and press any key to return to main menu
        }

        private void RemoveOrderConfirmation()
        {
            //if order was found
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
                    //maybe do an "are you sure"
                    //make sure order didn't get removed
                    Console.WriteLine();
                    Console.WriteLine("Order not removed. Press any key to return to Main Menu...");
                    Console.ReadKey();
                    isValid = true;
                }
                else
                {
                    //remove order: if only order for the day, do we want to delete just the order or the whole file?
                    //if not only order for day, remove just that order
                    Console.WriteLine();
                    Console.WriteLine("Order has been removed. Press any key to return to Main Menu.");
                    Console.ReadKey();
                    isValid = true;
                }
            }
        }
    }
}
