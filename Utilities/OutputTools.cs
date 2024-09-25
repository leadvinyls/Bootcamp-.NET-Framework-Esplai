using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public static class OutputTools
    {
        public static void Clear()
        {
            //Console.Clear();
            //Console.SetCursorPosition(0, 0);
            //Console.WriteLine("\x1b[3J");
            Console.SetCursorPosition(0, 0);
            Console.CursorVisible = false;
            for (int y = 0; y<Console.WindowHeight; y++)
                Console.Write(new String(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, 0);
            //Console.CursorVisible = true;
        }

        public static string ToFileString(Object o) 
        {
            string sOut = "";
            Type l = typeof(o);


            return sOut;
        }
    }
}
