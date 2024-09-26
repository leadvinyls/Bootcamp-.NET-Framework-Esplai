using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement
{
    public class Medic : Staff
    {
        LinkedList<Person> patients;
        public string Specialty { get; set; }

        public Medic() : base()
        {
            HID.Type = ID.EType.Medic;
            patients = new LinkedList<Person>();
            Specialty = "";
        }
        public Medic(string name, string lastname, uint phone, uint age, uint idNum) :  base(name, lastname, phone, age, idNum)
        {
            HID.Type = ID.EType.Medic;
            patients = new LinkedList<Person>();
        }

        public void Menu() 
        { 
            
        }

        public override string ToString()
        {
            return base.ToString() + $"█{Specialty}█{patients}";
        }
    }
}
