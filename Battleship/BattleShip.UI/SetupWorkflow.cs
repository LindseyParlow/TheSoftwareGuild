using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Ships;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;

namespace BattleShip.UI
{
    public class SetupWorkflow
    {
        public GameState SetUpGame()
        {
            ConsoleOutput.DisplayTitle();
            ConsoleOutput.WelcomePlayers();


            string p1 = ConsoleInput.GetNameFromPlayer(1);
            string p2 = ConsoleInput.GetNameFromPlayer(2);


            Board Player1Board = CreateBoard(p1);
            Board Player2Board = CreateBoard(p2);
            

            Player player1 = new Player(p1, Player1Board);
            Player player2 = new Player(p2, Player2Board);


            bool isP1First = ConsoleOutput.IsPlayer1First(player1, player2);


            GameState state = new GameState(player1, player2, isP1First);
            return state;
        }

        public Board CreateBoard(string name)
        {
            Board board = new Board();

            
            for(ShipType s = ShipType.Carrier; s >= ShipType.Destroyer; s--)
            {
                bool isPlacementValid = false;
                do
                {
                    PlaceShipRequest request = new PlaceShipRequest();
                    request.Coordinate = ConsoleInput.GetCoordinate(name, s);
                    request.Direction = ConsoleInput.GetDirection(name);
                    request.ShipType = s;

                    var placementResult = board.PlaceShip(request);
                    if (placementResult == ShipPlacement.NotEnoughSpace)
                    {
                        ConsoleOutput.ErrorNotEnoughSpace();
                    }
                    else if (placementResult == ShipPlacement.Overlap)
                    {
                        ConsoleOutput.ErrorOverlap();
                    }
                    else
                    {
                        isPlacementValid = true;
                    }
                } while (!isPlacementValid);
            }
            Console.Clear();
            return board;
        }
    }
}
