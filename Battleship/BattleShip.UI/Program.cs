using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL;

namespace BattleShip.UI
{
    public class Program
    {
        static void Main(string[] args)
        {
            bool wantsToPlayAgain = true;
            while (wantsToPlayAgain)
            {

            SetupWorkflow setup = new SetupWorkflow();
            var state = setup.SetUpGame();
            

            GameWorkflow game = new GameWorkflow(state);
            game.PlayGame(state);


                Console.WriteLine("Would you like to play again? (Y/N)");
            var input = Console.ReadLine();
            if (input == "Y" || input == "y")
            {
                wantsToPlayAgain = true;
            }
            else if (input == "N" || input == "n")
            {
                Console.WriteLine("Press any key to quit....");
                Console.ReadKey();
                wantsToPlayAgain = false;
                }
           
            }
        }
    }
}
