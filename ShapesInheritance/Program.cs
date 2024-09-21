using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace ShapesInheritance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int nShapes = Menu();
            Random rnd = new Random();
            for (int i = 0; i < nShapes; i++)
            {
                int shapeType = rnd.Next(0, 4);
                switch (shapeType)
                {
                    case 0:
                        Rectangle r = new Rectangle(2, 4);
                        Console.WriteLine($"{r}");
                        break;
                    case 1:
                        Square s = new Square(2);
                        Console.WriteLine($"{s}");
                        break;
                    case 2:
                        Triangle t = new Triangle(2, 4, 90);
                        Console.WriteLine($"{t}");
                        break;
                    case 3:
                        Ellipse e = new Ellipse(2, 4);
                        Console.WriteLine($"{e}");
                        break;
                    case 4:
                        Circle c = new Circle(2);
                        Console.WriteLine($"{c}");
                        break;
                }
            }

            Console.ReadKey();
        }

        static int Menu()
        {
            Console.WriteLine("Introduce cuantas formas quieres generar");
            return InputTools.IntroNum();
        }
    }
}
