using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesInheritance
{
    public class FlatShape
    {
        static Random rnd = new Random();
        public FlatShape()
        {
            
        }
        public virtual double CalcArea()
        {
            return 0;
        }

        public virtual double CalcPerimeter()
        {
            return 0;
        }

        public virtual string Draw() 
        {
            return "  ?  ";
        }
        public FlatShape GenerateRandomShape()
        {
            FlatShape shape = new FlatShape();

            switch (rnd.Next(0, 4))
            {
                case 0:
                    shape = new Rectangle(2, 4);
                    break;
                case 1:
                    shape = new Square(2);
                    break;
                case 2:
                    shape = new Triangle(2, 4, 90);
                    break;
                case 3:
                    shape = new Ellipse(2, 4);
                    break;
                case 4:
                    shape = new Circle(2);
                    break;
                default:
                    break;
            }

            return shape;
        }
    }
}
