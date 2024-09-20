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
        public int Sides { get; set; }
    }
    public class Rectangle : Poligon
    {

    }

    public class Square : Rectangle
    { 
    }

    public class Ellipse : Shape
    { 

    }
}
