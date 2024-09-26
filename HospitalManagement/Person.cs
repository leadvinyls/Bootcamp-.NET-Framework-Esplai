using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace HospitalManagement
{
    public class Person
    {
        const int drawSize = 25;
        Medic familyDoctor;
        LinkedList<Illness> illnesses;
        List<DateTime> cites;
        public Medic FamilyDoctor { get { return familyDoctor; } set { familyDoctor = value; } }
        public string Name { get; set; }
        public string LastName { get; set; }
        public uint Age { get; set; }
        public uint Phone { get; set; }
        public ID PID { get; set; }
        public LinkedList<Illness> Illnesses { get { return illnesses; } }
        public Illness AddIllness 
        { 
            set
            {
                if (illnesses.Find(value) == null)
                    illnesses.AddFirst(value);
            } 
        }
        public Person() 
        {
            familyDoctor = null;
            illnesses = new LinkedList<Illness>();
            Name = "";
            LastName = "";
            Age = 0;
            PID = new ID();
            Phone = 0;
            cites = new List<DateTime>();
        }

        public Person(string name, string lastname, uint phone, uint age, uint idNum) : this ()
        {
            this.Name = name;
            this.LastName = lastname;
            this.Age = age;
            this.PID.Num = idNum;
        }

        public virtual void Menu() { }

        public override string ToString()
        {
            return $"{PID}█{Age}█{Name}█{FamilyDoctor?.HID}█{illnesses}";
        }

        public void Draw() 
        {
            string sOut = "";
            sOut += " ";
            sOut += $"Name: {Name} {LastName}";
            for (int i = 0; i < drawSize - Name.Length - PID.ToString().Length; i++)
                sOut += " ";
            sOut += $"{PID} ";

            OutputTools.WriteWhite(sOut + "\n\n");
            Console.WriteLine($"  Age: {Age}");
            Console.WriteLine($"  Phone: {Phone.ToString("D9")}");
            Console.WriteLine($"  Family doctor: {(familyDoctor == null ? "Not assigned" : familyDoctor.HID.ToString())}");

            Console.WriteLine("  Cites:");
            foreach (var cite in cites)
                Console.WriteLine($"   {cite}");

            Console.WriteLine("  Illnesses:");
            foreach (var illness in Illnesses)
                Console.WriteLine($"   {illness}");
            

        }

        public virtual void Register() 
        {
            Console.Write("Name: ");
            Name = Console.ReadLine();
            Console.Write("Last Name: ");
            LastName = Console.ReadLine();
            Console.Write("Phone ");
            Phone = (uint)InputTools.IntroNum(999999999);
            Console.Write("Age ");
            Age = (uint)InputTools.IntroNum(130);
            Console.Write("PID: ");
            ID pid = new ID(); 
            while (!ID.TryParse(Console.ReadLine(), out pid)) { }
            PID = pid;
            PID.Type = ID.EType.Patient;



            Console.WriteLine("");
            this.Draw();
        }
    }
}
