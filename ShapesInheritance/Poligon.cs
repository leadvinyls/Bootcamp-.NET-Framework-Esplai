using ShapesInheritance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesInheritance
{
    public class Poligon : FlatShape
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

        public override string Draw()
        {
            return base.Draw();
        }
    }
}
