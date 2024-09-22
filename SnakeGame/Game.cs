using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Utilities;
using System.Xml.Linq;
using System.Configuration;
using System.Threading;

namespace SnakeGame
{
    public class Game
    {
        public static int mapSize = 15;
        public Snake Player { get; set; }
        bool?[,] map;
        bool[,] cherryMap;
        //string[,] sMap;
        //public string[,] SMap { get { return sMap; } }

        public Game()
        {
            Player = new Snake();
            map = new bool?[mapSize, mapSize];
            cherryMap = new bool[mapSize, mapSize];

            //sMap = new string[15, 15];
        }

        public void PlayGame() 
        {

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            GenerateRandomCherry();
            UpdateMap();
            int i = 1;
            while (true)
            {
                OutputTools.Clear();
                Console.WriteLine(this);

                if (i % 20 == 0)
                    GenerateRandomCherry();

                if (!MovePlayer())
                    break;
                i++;
            }

            int snakeSize = Player.Body.Count();
            for (int j = 0; j < snakeSize ; j++)
            {
                Player.Body.RemoveLast();
                UpdateMap();
                Thread.Sleep(20);
                OutputTools.Clear();
                Console.WriteLine(this);
            }

            Console.WriteLine("You lost!");
            Console.ReadLine();
        }

        public bool MovePlayer()
        {
            Point move = InputTools.IntroKey();
            Point nextPos = new Point(Player.Head.X + move.X, Player.Head.Y + move.Y);

            if (nextPos.X >= mapSize)
                nextPos.X = nextPos.X - mapSize;
            else if (nextPos.X < 0)
                nextPos.X = mapSize + nextPos.X;

            if (nextPos.Y >= mapSize)
                nextPos.Y = nextPos.Y - mapSize;
            else if (nextPos.Y < 0)
                nextPos.Y = mapSize + nextPos.Y;

            if (nextPos != Player.Neck)
                if (Player.Body.Find(nextPos) == null)
                    Player.Move(nextPos);
                else
                    return false;

            if (map[Player.Head.X, Player.Head.Y] == false)
            {
                Player.AddTail();
                DeleteCherry(Player.Head);
            }

            UpdateMap();
            return true;
        }

        public void UpdateMap() 
        {
            map = new bool?[mapSize, mapSize];
            foreach (var element in Player.Body)
            {
                if (element == Player.Head)
                    map[element.X, element.Y] = false;
                else
                    map[element.X, element.Y] = true;
            }

            for (int x = 0; x < mapSize; x++)
                for (int y = 0; y < mapSize; y++)
                    if (cherryMap[x, y] == true)
                        map[x, y] = false;

        }

        public override string ToString()
        {
            string sOut = "╔══════════════════════════════╗\n";

            for (int i = 0; i < mapSize; i++)
            {
                sOut += "║";
                for (int j = 0; j < mapSize; j++) 
                {
                    bool? currentPos = map[i, j];
                    switch (currentPos)
                    {
                        case null:
                            sOut += "  ";
                            break;
                        case true:
                            sOut += "▓▓";
                            break;
                        case false:
                            sOut += "██";
                            break;
                    }
                }
                sOut += "║\n";
            }

            sOut += "╚══════════════════════════════╝\n";

            return sOut;
        }

        public void GenerateRandomCherry()
        {
            Random rnd = new Random();
            int x = rnd.Next(0, mapSize - 1);
            int y = rnd.Next(0, mapSize - 1);
            cherryMap[x, y] = true;
        }

        public void DeleteCherry(Point pos)
        {
            cherryMap[pos.X, pos.Y] = false;
        }
    }
}
