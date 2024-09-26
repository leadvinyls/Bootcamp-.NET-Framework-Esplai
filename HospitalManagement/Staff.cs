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
            HID = new ID();
        }
        public Staff(string name, string lastname, uint phone, uint age, uint idNum) : base(name, lastname, phone, age, idNum)
        {
            HID = new ID();
        }

        public override string ToString()
        {
            return base.ToString() + $"█{HID}";
        }

        public override void Register()
        { 
            
        }
    }
}
