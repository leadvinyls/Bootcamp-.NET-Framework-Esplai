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
            this.MinorAxis = minorAxis;
            this.MajorAxis = majorAxis;
        }
    }

    public class Rectangle : Poligon
    {
        public double Length { get; set; }
        public double Height { get; set; }

        public Rectangle(double length, double height)
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
            return $"Length: {Length}, Height: {Height}, Area: {calcArea()}";
        } 
    }

    public class Triangle : Poligon
    {
        public double SideA { get; set; }
        public double SideB { get; set; }
        public double Angle { get; set; }

        public Triangle(double sideA, double sideB, double angle) 
        {
            this.SideA = sideA;
            this.SideB = sideB;
            this.Angle = angle;
        }

        public override double calcArea()
        {
            return (SideA * SideB * Math.Sin(Angle)) / 2;
        }

        public override double calcPerimeter()
        {
            double sideC = Math.Sqrt(Math.Pow(SideA, 2) + Math.Pow(SideB, 2) - (2 * SideA * SideB * Math.Cos(Angle)));
            return SideA + SideB + sideC;
        }
    }

    public class Square : Rectangle
    {
        public Square(double length) : base(length, length)
        {
            
        }
    }

    public class Circle : Ellipse
    {
        public Circle(double radius) : base(radius, radius)
        { 
        }
    }
}
