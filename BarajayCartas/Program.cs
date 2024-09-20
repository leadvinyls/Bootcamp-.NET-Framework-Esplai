using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Utilities;

namespace DeckAndCards
{
    internal class Program
    {
        static List<Player> players = new List<Player>();
        static Deck barajaCentral = new Deck();
        static void Main()
        {
            BattleBoard game;
            while (true)
            {
                int? option = Menu(); 
                if (option != null)
                {
                    game = new BattleBoard((int)option);
                    game.PlayGame();
                }
                else
                    break;
            }
        }

        static int? Menu()
        {
            Console.Write(@"Cards Battle

Set the number of players (2 - 5)
");
            while (true)
            {
                int nPlayers = InputTools.IntroNum();
                if (2 <= nPlayers && nPlayers <= 5)
                    return nPlayers;
                else if (nPlayers == 0)
                    return null;
                else
                    Console.WriteLine("Error: Number of players out of range.");
            }      
        }
    }
}
