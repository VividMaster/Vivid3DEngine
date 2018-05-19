using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReboundGame
{
    class Program
    {
        static void Main(string[] args)
        {
            var logoState = new States.LogosState();

            StarGame.InitState = logoState;

            var game = new StarGame(800, 600, false);

            game.Run(30, 30);

        }
    }
}
