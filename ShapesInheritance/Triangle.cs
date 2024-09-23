using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesInheritance
{
    public class Triangle : Poligon
    {
        public double SideA { get; set; }
        public double SideB { get; set; }
        public double SideC { get; set; }
        public double Angle { get; set; }

        public Triangle(double sideA, double sideB, double angle) : base(3)
        {
            this.SideA = sideA;
            this.SideB = sideB;
            this.Angle = angle;
            SideC = Math.Sqrt(Math.Pow(SideA, 2) + Math.Pow(SideB, 2) - (2 * SideA * SideB * Math.Cos((Angle  * Math.PI) / 180)));
        }

        public override double CalcArea()
        {
            return (SideA * SideB * Math.Abs(Math.Sin(Angle))) / 2;
        }

        public override double CalcPerimeter()
        {
            return SideA + SideB + SideC;
        }

        public override string ToString()
        {
            return base.ToString() + $"SideA: {SideA}, SideB: {SideB}, SideC: {SideC}, Angle A&B: {Angle}, Area: {CalcArea()}, Perimeter: {CalcPerimeter()}";
        }

        public override string Draw()
        {
            return @"     *         
    / \        
   /   \       
  /     \      
 /       \     
*─────────*";
        }
    }

}
