using BattleShip.BLL.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using BattleShip.UI;

namespace Battleship.Tests
{
    [TestFixture]
    public class ConsoleInputTests
    {
        [TestCase("B10",2,10, true)]
        [TestCase("C4",3,4, true)]
        [TestCase("D12",4,12, false)]
        [TestCase("X2",24,2, false)]
        [TestCase(" ", 0, 0, false)]
        public static void GetCoordinateFireShotTest(string userInput, int x, int y, bool expected)
        {
            string coordinateInput = userInput;
            Coordinate coordinate = new Coordinate(x,y);
            bool isValid = ConsoleInput.TryParseCoordinate(userInput, out coordinate);

            Assert.AreEqual(expected, isValid);
        }
    }
}
