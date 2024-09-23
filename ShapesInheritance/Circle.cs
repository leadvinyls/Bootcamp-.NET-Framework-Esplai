using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesInheritance
{
    public class Circle : Ellipse
    {
        public Circle(double radius) : base(radius, radius)
        {
        }

        public override string ToString()
        {
            return $"Circle: Radius: {MajorAxis}, Area: {CalcArea()}, Perimeter: {CalcPerimeter()}";
        }

        public override string Draw()
        {
            return @"    ***
 *       *
*         *
*         *
 *       *
    ***";
            
        }
    }
}
