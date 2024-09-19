using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public static class InputTools
    {
        public static int IntroNum()
        {
            while (true)
            {
                Console.Write("> ");
                string s = Console.ReadLine();
                if (int.TryParse(s, out int num))
                    return num;

                Console.WriteLine("Error: El valor introducido no es un número");
            }
        }
    }
}
