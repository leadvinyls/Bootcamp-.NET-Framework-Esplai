using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesInheritance
{
    public class Rectangle : Poligon
    {
        public double Length { get; set; }
        public double Height { get; set; }

        public Rectangle(double length, double height) : base(4)
        {
            this.Length = length;
            this.Height = height;
            this.NumSides = 4;
        }

        public override double CalcArea()
        {
            return Length * Height;
        }

        public override double CalcPerimeter()
        {
            return (Length + Height) * 2;
        }

        public override string ToString()
        {
            return base.ToString() + $"Length: {Length}, Height: {Height}, Area: {CalcArea()}";
        }

        public override string Draw()
        {
            return @"╔═════════╗
║         ║
║         ║
║         ║
║         ║
║         ║
║         ║
║         ║
╚═════════╝";
        }
    }
}
