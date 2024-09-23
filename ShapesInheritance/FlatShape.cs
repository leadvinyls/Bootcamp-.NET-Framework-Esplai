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
            FlatShape shape;
            double rndA = rnd.Next(1, 100), rndB = rnd.Next(1, 100), rndC = rnd.Next(1,179);

            switch (rnd.Next(0, 4))
            {
                case 0:
                    shape = new Rectangle(rndA, rndB);
                    break;
                case 1:
                    shape = new Square(rndA);
                    break;
                case 2:
                    shape = new Triangle(rndA, rndB, rndC);
                    break;
                case 3:
                    shape = new Ellipse(rndA, rndB);
                    break;
                case 4:
                    shape = new Circle(rndA);
                    break;
                default:
                    shape = new FlatShape();
                    break;
            }

            return shape;
        }
    }
}
