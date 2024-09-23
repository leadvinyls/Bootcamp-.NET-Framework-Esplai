using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Utilities;

namespace ShapesInheritance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int nShapes = Menu();
            FluxDiagram fx = new FluxDiagram();
            fx.CreateFluxDiagram(nShapes);
            Console.WriteLine(fx.Draw());
            Console.WriteLine(fx);
            Console.WriteLine($"Total area: {fx.CalcTotalArea()}");
            Console.WriteLine($"Total perimeter: {fx.CalcTotalPerimeter()}");

            Console.ReadKey();
        }

        static int Menu()
        {
            Console.WriteLine("Introduce the number of shapes that you diagram will have");
            return InputTools.IntroNum();
        }
    }
}
