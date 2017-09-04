using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.BLL
{
    public static class RNG
    {
        public static Random _generator = new Random();
        public static double NextDouble()
        {
            return _generator.NextDouble();
        }


    }
}




