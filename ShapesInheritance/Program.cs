using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesInheritance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Rectangle r = new Rectangle(2, 4);
            Console.WriteLine($"Rectangulo creado:\n{r}");
            Console.ReadKey();
        }
    }
}
