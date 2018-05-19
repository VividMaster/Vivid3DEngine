using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarKnight
{
    class Program
    {
        static void Main(string[] args)
        {
            var logoState = new States.LogosState();

            StarEngine.App.StarApp.InitState = logoState;

            var game = new StarGame(800, 600, false);

            game.Run(60, 60);

        }
    }
}
