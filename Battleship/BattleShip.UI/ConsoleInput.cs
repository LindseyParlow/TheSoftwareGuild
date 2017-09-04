using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Ships;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Responses;

namespace BattleShip.UI
{
    public class ConsoleInput
    {

        public static string GetNameFromPlayer(int playerNumber)
        {
            Console.Write($"Player {playerNumber}, please enter your name: ");
            return Console.ReadLine();
        }

        internal static Coordinate GetCoordinate(string name, ShipType s)
        {

            int b = -1;
            bool isInputCorrect = false;
            char yPart = 'A';

            
            
            while (!isInputCorrect)
            {
                Console.WriteLine($"{name}, please enter coordinate for {s} (example: B5): ");

                string coordinateInput = Console.ReadLine();


                yPart = coordinateInput[0];
                string xPart = coordinateInput.Substring(1);


                if ((yPart >= 'A' && yPart <= 'J'))
                {
                    if (int.TryParse(xPart, out b))
                    {
                        if (b >= 1 && b <= 10)
                        {
                            isInputCorrect = true;
                        }
                    }
                }

            }

            int a = (yPart - 'A' + 1);
            Coordinate successCoordinate = new Coordinate(a, b);
            return successCoordinate;
        }

        
        internal static Coordinate GetCoordinateFireShot(GameState state)
        {
            int b = -1;
            bool isInputCorrect = false;
            char yPart = 'A';

            
            while (!isInputCorrect)
            {
                string activePlayer = "";

                if(state.IsPlayerOneTurn)
                {
                    activePlayer = state.P1.Name;
                }
                else
                {
                    activePlayer = state.P2.Name;
                }
                Console.WriteLine($"{activePlayer}, please enter coordinate to fire at: ");

                string coordinateInput = Console.ReadLine();


                yPart = coordinateInput[0];

                string xPart = coordinateInput.Substring(1);


                if ((yPart >= 'A' && yPart <= 'J'))
                {
                    if (int.TryParse(xPart, out b))
                    {
                        if (b >= 1 && b <= 10)
                        {
                            isInputCorrect = true;
                        }
                    }
                }

            }

            int a = (yPart - 'A' + 1);
            Coordinate fireShotCoordinate = new Coordinate(a, b);
            return fireShotCoordinate;
        }

        internal static ShipDirection GetDirection(string name)
        {
            ShipDirection successDirection = new ShipDirection();
            bool isInputCorrect = false;

            while (!isInputCorrect)
            {
                Console.WriteLine($"{name}, please choose a direction to place your ship (example: Up, Down, Left, Right): ");
                string desiredDirection = Console.ReadLine();

                if (desiredDirection.ToLower() == "up")
                {
                    isInputCorrect = true;
                    successDirection = ShipDirection.Up;
                }
                else if (desiredDirection.ToLower() == "down")
                {
                    isInputCorrect = true;
                    successDirection = ShipDirection.Down;
                }
                else if (desiredDirection.ToLower() == "left")
                {
                    isInputCorrect = true;
                    successDirection = ShipDirection.Left;
                }
                else if (desiredDirection.ToLower() == "right")
                {
                    isInputCorrect = true;
                    successDirection = ShipDirection.Right;
                }
            }
            return successDirection;
        }
        


    }
}
