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
                        break;
                    case ShotStatus.Hit:
                        Console.WriteLine("Hit!");
                        state.IsPlayerOneTurn = !state.IsPlayerOneTurn;
                        break;
                   case ShotStatus.Miss:
                        Console.WriteLine("Miss!");
                        state.IsPlayerOneTurn = !state.IsPlayerOneTurn;
                        break;
                    default:
                        break;
                }
                ConsoleOutput.NextPlayerTurn();
                Console.ReadKey();
            }
            ConsoleOutput.VictoryMessage();



            Console.ReadLine();
            



            //ShotStatus lastShot = new ShotStatus();
            // while (lastShot != ShotStatus.Victory)
           //{
                //FireShot( isp1Turn, gameboard);
               // isPlayerAsTurn = !isPlayerAsTurn;
           // }
            
           



           //store all of this in game state
           //playerfirst fires at playerseconds board
           //check to make sure shot was valid
           //reveal if shot is hit, miss, hit and sunk, victory, etc.
           //update board to store shot placement
           //switch turns
           //continue until game is over
           //when game is over, prompt if they want to quit or play again.
           //still need to fix if they put in b5 versus B5
           
        }

           
    }
}

