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

    }

    public class Poligon : Shape 
    { 
        public int NumSides { get; set; }
    }

    public class Ellipse : Shape
    {
        public double MinorAxis { get; set; }
        public double MajorAxis { get; set; }

        public virtual double calcArea()
        {
            return Math.PI * MinorAxis * MajorAxis;
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
        public double Heigth { get; set; }

        public virtual double calcArea() 
        {
            return Length * Heigth;
        }

        public override string ToString() 
        {
            return $"Length: {Length}, Height: {Heigth}, Area: {calcArea()}";
        } 
        public Rectangle(double length, double heigth) 
        {
            this.Length = length;
            this.Heigth = heigth;
            this.NumSides = 4;
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
