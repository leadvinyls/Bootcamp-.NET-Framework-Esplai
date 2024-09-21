using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesInheritance
{
    public class Shape
    {
        public virtual double calcArea() 
        {
            return 0;
        }

        public virtual double calcPerimeter()
        {
            return 0;
        }
    }

    public class Poligon : Shape 
    { 
        public int NumSides { get; set; }

        public Poligon(int numSides)
        {
            this.NumSides = numSides;
        }

        public override string ToString()
        {
            return $"Sides: {NumSides},";
        }
    }

    public class Ellipse : Shape
    {
        public double MinorAxis { get; set; }
        public double MajorAxis { get; set; }

        public override double calcArea()
        {
            return Math.PI * MinorAxis * MajorAxis;
        }

        public override double calcPerimeter()
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
            return $"Minor Axis: {MinorAxis}, Major Axis: {MajorAxis}, Area: {calcArea()}, Perimeter: {calcPerimeter()}";
        }
    }

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

        public override double calcArea() 
        {
            return Length * Height;
        }

        public override double calcPerimeter() 
        {
            return (Length + Height) * 2;
        }

        public override string ToString() 
        {
            return base.ToString() + $"Length: {Length}, Height: {Height}, Area: {calcArea()}";
        } 
    }

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

        public override double calcArea()
        {
            return (SideA * SideB * Math.Sin(Angle)) / 2;
        }

        public override double calcPerimeter()
        {
            return SideA + SideB + SideC;
        }

        public override string ToString()
        {
            return base.ToString() + $"SideA: {SideA}, SideB: {SideB}, SideC: {SideC}, Angle A&B: {Angle}, Area: {calcArea()}, Perimeter: {calcPerimeter()}";
        }
    }

    public class Square : Rectangle
    {
        public Square(double length) : base(length, length)
        {
            
        }

        public override string ToString()
        {
            return $"Sides: {NumSides}, SideLength: {Length}, Area: {calcArea()}, Perimeter: {calcPerimeter()}";
        }
    }

    public class Circle : Ellipse
    {
        public Circle(double radius) : base(radius, radius)
        { 
        }

        public override string ToString()
        {
            return $"Radius: {MajorAxis}, Area: {calcArea()}, Perimeter: {calcPerimeter()}";
        }
    }
}
