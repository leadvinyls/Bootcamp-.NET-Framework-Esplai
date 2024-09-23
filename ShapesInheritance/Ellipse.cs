using ShapesInheritance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesInheritance
{
    public class Ellipse : Shape
    {
        public double MinorAxis { get; set; }
        public double MajorAxis { get; set; }

        public override double CalcArea()
        {
            return Math.PI * MinorAxis * MajorAxis;
        }

        public override double CalcPerimeter()
        {
            return 2 * Math.PI * Math.Sqrt((Math.Pow(MajorAxis, 2) + Math.Pow(MinorAxis, 2)) / 2);
        }
        public Ellipse(double minorAxis, double majorAxis)
        {
            if (minorAxis < majorAxis)
            {
                this.MinorAxis = minorAxis;
                this.MajorAxis = majorAxis;
            }
            else
            {
                this.MinorAxis = majorAxis;
                this.MajorAxis = minorAxis;
            }
        }

        public override string ToString()
        {
            return $"Minor Axis: {MinorAxis}, Major Axis: {MajorAxis}, Area: {CalcArea()}, Perimeter: {CalcPerimeter()}";
        }
    }
}
