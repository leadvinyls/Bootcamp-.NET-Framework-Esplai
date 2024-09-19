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
            Console.Clear();
            Console.WriteLine("\x1b[3J");
        }
    }
}
