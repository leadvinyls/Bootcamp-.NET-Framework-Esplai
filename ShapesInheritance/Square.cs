﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerenciaFormas
{
    public class Square : Rectangle
    {
        public Square(double length) : base(length, length)
        {

        }

        public override string ToString()
        {
            return $"Sides: {NumSides}, SideLength: {Length}, Area: {CalcArea()}, Perimeter: {CalcPerimeter()}";
        }
    }
}
