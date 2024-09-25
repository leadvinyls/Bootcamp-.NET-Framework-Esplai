using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement
{
    public class Staff : Person
    {
        public ID HID { get; set; }

        public Staff() 
        { 
        }
        public Staff(string name, uint age) : base(name, age)
        { 

        }
    }
}
