using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Responses;
using BattleShip.BLL.Requests;

namespace BattleShip.UI
{
    public class ConsoleOutput
    {

        internal static void DisplayTitle()
        {
            Console.WriteLine($"Welcome to Battleship!");
            Console.WriteLine($"Press any key to enter the game...");
            Console.ReadKey();
            Console.Clear();
        }

        internal static void PrintBoard(Board printBoard)
        {
           
            for (int y = 1; y <= 10; y++)
            {
                for (int x = 1; x <= 10; x++)
                {
                    ShotHistory currentState = printBoard.CheckCoordinate(new Coordinate(y, x));
                    switch (currentState)
                    {
                        case ShotHistory.Hit:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("H");
                            Console.ResetColor();
                            break;
                        case ShotHistory.Miss:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("M");
                            Console.ResetColor();
                            break;
                        case ShotHistory.Unknown:
                            Console.Write(" ");
                            Console.ResetColor();
                            break;
                    }
                    Console.Write($"   |");
                }
                Console.WriteLine(" ");
                Console.WriteLine("---------------------------------------------------");
            }
        }

        internal static void NextPlayerTurn()
        {
            Console.WriteLine("Your turn is over. Press any key to switch turns.");
        }

        internal static void VictoryMessage()
        {
            Console.WriteLine("Hit and sunk! Victory is YOURS!!!!");
        }

        internal static void WelcomePlayers()
        {
            Console.WriteLine($"Let's introduce ourselves...");
        }

        internal static bool IsPlayer1First(Player player1, Player player2)
        {
            bool isPlayer1First = false;
            if (RNG.NextDouble() < .5)
            {
                isPlayer1First = true;
                Console.WriteLine($"{player1.Name} is first to fire!");
            }
            else
            {
                isPlayer1First = false;
                Console.WriteLine($"{player2.Name} is first to fire!");
            }
            return isPlayer1First;
        }

        internal static void ErrorNotEnoughSpace()
        {
            Console.WriteLine("You placed a ship where there's not enough space. Try again.");
        }

        internal static void ErrorOverlap()
        {
            Console.WriteLine("You made ships overlap. Try again.");
        }
    }
}


