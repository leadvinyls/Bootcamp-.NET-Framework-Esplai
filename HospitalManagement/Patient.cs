using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement
{
    public class Patient : Person
    {
        ID ssid;
        Medic familyDoctor;
        LinkedList<Illness> illnesses;
        public ID SSID { get { return ssid; } }
        public Medic FamilyDoctor { get { return familyDoctor; } }

        public Patient(Patient p) 
        {
            this.ssid = p.ssid;
            this.familyDoctor = p.familyDoctor;
            this.illnesses = p.illnesses;
        }
        public Patient() : base()
        {
            ssid = new ID();
            ssid.Type = ID.EType.Patient;

        }

        public Patient(string name, uint age) : base(name, age)
        { 
        }

        public void AssignFamilyDoctor(Medic doc) 
        {
            familyDoctor = doc;
        }

        public void AddIllness(Illness ill) 
        {
            illnesses.AddFirst(ill);
        }

        public override void Menu() 
        {
            Console.WriteLine("Patient Menu");
        }
    }
}
