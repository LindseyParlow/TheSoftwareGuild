using SGBank.UI.Workflows;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.UI
{
    public class Menu
    {
        public static void Start()
        {
            
            while (true)
            {
                Console.Clear();
                Console.WriteLine("SG Bank Application");
                Console.WriteLine("------------------------");
                Console.WriteLine("1. Lookup an Account");
                Console.WriteLine("2. Deposit");
                Console.WriteLine("3. Withdraw");

                Console.WriteLine("\nQ to quit");
                Console.Write("\nEnter selection: ");
                
                string userinput = Console.ReadLine();

                string file = @"C:\Repos\bitbucket\dotnet-lindsey-parlow\SGBankAccounts\Accounts.txt";
                string[] text;

                try
                {
                    text = File.ReadAllLines(file);
                }
                catch
                {
                    Console.WriteLine($"The file: {file} was not found.");
                    Console.Write("Press any key to exit...");
                    Console.ReadKey();
                    return;
                }
                

                switch (userinput)
                {
                    case "1":
                        AccountLookupWorkflow lookupWorkflow = new AccountLookupWorkflow();
                        lookupWorkflow.Execute();
                        break;
                    case "2":
                        DepositWorkflow depositWorkflow = new DepositWorkflow();
                        depositWorkflow.Execute();
                        break;
                    case "3":
                        WithdrawWorkflow withdrawWorkflow = new WithdrawWorkflow();
                        withdrawWorkflow.Execute();
                        break;
                    case "Q":
                        return;
                }


            }

        }
    }
}
