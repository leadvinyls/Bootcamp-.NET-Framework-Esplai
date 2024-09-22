using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game currentGame = new Game();
            currentGame.PlayGame();
        }
    }
}
