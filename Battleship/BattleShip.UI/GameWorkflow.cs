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
    public class GameWorkflow
    {
        GameState State { get; }
        public GameWorkflow(GameState state)
        {
            State = state;
        }
        
        internal void PlayGame(GameState state)
        {
            ShotStatus shotFired = new ShotStatus();
            while (shotFired != ShotStatus.Victory)
            {
                Board toShootAt = state.IsPlayerOneTurn ? state.P2.PlayerBoard : state.P1.PlayerBoard;
                ConsoleOutput.PrintBoard(toShootAt);
                Coordinate shotLoc = ConsoleInput.GetCoordinateFireShot(state);

                FireShotResponse response =  toShootAt.FireShot(shotLoc);
                ConsoleOutput.PrintBoard(toShootAt);
                shotFired = response.ShotStatus;
                switch (response.ShotStatus)
                {
                     case ShotStatus.HitAndSunk:
                        Console.WriteLine("Hit and sunk!");
                        state.IsPlayerOneTurn = !state.IsPlayerOneTurn;
                        ConsoleOutput.NextPlayerTurn();
                        break;
                    case ShotStatus.Hit:
                        Console.WriteLine("Hit!");
                        state.IsPlayerOneTurn = !state.IsPlayerOneTurn;
                        ConsoleOutput.NextPlayerTurn();
                        break;
                   case ShotStatus.Miss:
                        Console.WriteLine("Miss!");
                        state.IsPlayerOneTurn = !state.IsPlayerOneTurn;
                        ConsoleOutput.NextPlayerTurn();
                        break;
                    default:
                        break;
                }
               
                Console.ReadKey();
                Console.Clear();
            }

            ConsoleOutput.VictoryMessage();
            
            Console.ReadLine();
        }  
    }
}

