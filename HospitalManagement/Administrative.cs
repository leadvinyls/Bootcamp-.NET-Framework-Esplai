using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement
{
    public class Administrative : Staff
    {
        public Administrative(string name, uint age) : base(name, age)
        {
            HID.Type = ID.EType.Administrative;
        }
        public void Register()
        {
        }
    }
}
