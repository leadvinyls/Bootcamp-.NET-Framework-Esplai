using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerenciaFormas
{
    public class Circle : Ellipse
    {
        public Circle(double radius) : base(radius, radius)
        {
        }

        public override string ToString()
        {
            return $"Radius: {MajorAxis}, Area: {CalcArea()}, Perimeter: {CalcPerimeter()}";
        }
    }
}
