﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesInheritance
{
    public class FluxDiagram
    {
        LinkedList<FlatShape> diagram;
        public LinkedList<FlatShape> Diagram { get { return diagram; } }

        public FluxDiagram() 
        {
            diagram = new LinkedList<FlatShape>();
        }

        public void CreateFluxDiagram(int nShapes)
        {
            for (int i = 0; i < nShapes; i++)
                diagram.AddFirst(new FlatShape().GenerateRandomShape());
        }

        public override string ToString()
        {
            string sOut = "";
            foreach (FlatShape shape in diagram)
            {
                sOut += $"{shape.Draw()}\n";
                if (shape != diagram.Last())
                    sOut += "     ║\n     ║\n";
            }

            return sOut;
        }
    }
}
