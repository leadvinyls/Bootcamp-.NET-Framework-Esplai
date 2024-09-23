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
        public virtual double CalcArea() 
        {
            return 0;
        }

        public virtual double CalcPerimeter()
        {
            return 0;
        }
    }
}
