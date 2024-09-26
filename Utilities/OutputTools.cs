using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

        public static void WriteWhite(string s) 
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write(s);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static string ToFileString(Object obj) 
        {
            string sOut = "";
            if (obj != null)
            {
                Type type = obj.GetType();
                PropertyInfo[] properties = type.GetProperties();
                foreach (PropertyInfo property in properties)
                {
                    Object value = property.GetValue(obj);

                    if (value != null)
                        sOut += $"{value}";
                    else
                        sOut += " ";
                        
                    if (property != properties.Last())
                        sOut += "█";
                    
                }
            }
            return sOut;
        }
    }
}
