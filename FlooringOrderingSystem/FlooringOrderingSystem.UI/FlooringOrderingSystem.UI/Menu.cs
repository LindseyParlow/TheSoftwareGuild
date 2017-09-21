using FlooringOrderingSystem.BLL;
using FlooringOrderingSystem.UI.Workflows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringOrderingSystem.UI
{
    public static class Menu
    {
        public static void Start()
        {
            SystemManager manager = new SystemManager();

            while(true)
            {
                Console.Clear();
                Console.WriteLine("Flooring Ordering System");
                Console.WriteLine("-----------------------------------");
                Console.WriteLine("1. Display Orders");
                Console.WriteLine("2. Add an Order");
                Console.WriteLine("3. Edit an Order");
                Console.WriteLine("4. Remove an Order");
                Console.WriteLine("5. Quit");
                Console.WriteLine("-----------------------------------");
                Console.Write("Enter selection: ");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        DisplayOrderWorkflow displayWorkflow = new DisplayOrderWorkflow(manager);
                        displayWorkflow.Execute();
                        break;
                    case "2":
                        AddOrderWorkflow addWorkflow = new AddOrderWorkflow(manager);
                        addWorkflow.Execute();
                        break;
                    case "3":
                        EditOrderWorkflow editWorkflow = new EditOrderWorkflow(manager);
                        editWorkflow.Execute();
                        break;
                    case "4":
                        RemoveOrderWorkflow removeWorkflow = new RemoveOrderWorkflow(manager);
                        removeWorkflow.Execute();
                        break;
                    case "5":
                        return;
                    default:
                        break;
                }
            }
        }
    }
}
