using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesInheritance
{
    public class Rhombus : Poligon
    {
        double MajorDiag { get; set; }
        double MinorDiag { get; set; }
        public Rhombus(double majorDiag, double minorDiag) : base(4)
        { 

        }
    }
}
