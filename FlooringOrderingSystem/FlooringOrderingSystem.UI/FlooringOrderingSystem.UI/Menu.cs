﻿using FlooringOrderingSystem.UI.Workflows;
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
                Console.WriteLine();
                Console.Write("Enter selection: ");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        OrderDisplayWorkflow displayWorkflow = new OrderDisplayWorkflow();
                        displayWorkflow.Execute();
                        break;
                    case "2":
                        break;
                    case "3":
                        break;
                    case "4":
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
