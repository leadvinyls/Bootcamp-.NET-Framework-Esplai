using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesInheritance
{
    public class Square : Rectangle
    {
        public Square(double length) : base(length, length)
        {

        }

        public override string ToString()
        {
            return $"Poligon: Sides: {NumSides}, SideLength: {Length}, Area: {CalcArea()}, Perimeter: {CalcPerimeter()}";
        }

        public override string Draw()
        {
            return @"╔═════════╗
║         ║
║         ║
║         ║
║         ║
╚═════════╝";
        }
    }
}
