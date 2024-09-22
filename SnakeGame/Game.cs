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
        //string[,] sMap;
        //public string[,] SMap { get { return sMap; } }

        public Game()
        {
            Player = new Snake();
            map = new bool?[mapSize, mapSize];

            //sMap = new string[15, 15];
        }

        public void PlayGame() 
        {
            UpdatePlayerPos();
            int i = 1;
            while (true)
            {
                OutputTools.Clear();
                Console.WriteLine(this);
                Point currentPos = Player.Head;
                if (i % 2 == 0)
                    Player.AddTail(currentPos);

                if (!MovePlayer())
                    break;
                i++;
            }

            int snakeSize = Player.Body.Count();
            for (int j = 0; j < snakeSize ; j++)
            {
                Player.Body.RemoveLast();
                UpdatePlayerPos();
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

            if (Player.Body.Find(nextPos) == null)
                Player.Move(nextPos);
            else
                return false;

            UpdatePlayerPos();
            return true;
        }

        public void UpdatePlayerPos() 
        {
            map = new bool?[mapSize, mapSize];
            foreach (var element in Player.Body)
            {
                if (element == Player.Body.First())
                    map[element.X, element.Y] = false;
                else
                    map[element.X, element.Y] = true;
            }
        }

        public override string ToString()
        {
            string sOut = "█──────────────────────────────█\n";
            for (int i = 0; i < mapSize; i++)
            {
                sOut += "|";
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
                sOut += "|\n";
            }

            sOut += "█──────────────────────────────█\n";

            return sOut;
        }
    }
}
