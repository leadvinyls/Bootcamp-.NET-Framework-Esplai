using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement
{
    public class Medic : Staff
    {
        LinkedList<Patient> patients;
        public Medic() : base()
        {
            HID.Type = ID.EType.Medic;
            patients = new LinkedList<Patient>();
        }
    }
}
