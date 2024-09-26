using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace Utilities
{
    public static class InputTools
    {
        public static int IntroNum(int max = int.MaxValue)
        {
            while (true)
            {
                Console.Write("> ");
                string s = Console.ReadLine();
                if (int.TryParse(s, out int num) && num <= max && num >= 0)
                    return num;

                Console.WriteLine("Error: El valor introducido no es un número");
            }
        }



        public static Point IntroKey()
        {
            Point nextPos = new Point(0,0);
            ConsoleKey direction = Console.ReadKey(false).Key;
            switch (direction) 
            {
                case ConsoleKey.RightArrow:
                    nextPos.Y = 1;
                    break;
                case ConsoleKey.DownArrow:
                    nextPos.X = 1;
                    break;
                case ConsoleKey.LeftArrow:
                    nextPos.Y = -1;
                    break;
                case ConsoleKey.UpArrow:
                    nextPos.X = -1;
                    break;
                default:
                    break;
            }

            return nextPos;
        }

        public static void AddObjectToFile(Object obj, string filePath) 
        {
            try
            {
                StreamWriter sw = new StreamWriter(filePath);
                sw.Write(OutputTools.ToFileString(obj));
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                File.Open(filePath, FileMode.Create).Close();
            }
        }
        /*public static Object FileToObject(string filePath)
        {
            try
            {
                StreamWriter sw = new StreamWriter(filePath);
                sw.Write(OutputTools.ToFileString(obj));
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                File.Open(filePath, FileMode.Create).Close();
            }
        }*/

    }
}
