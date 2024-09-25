using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace HospitalManagement
{
    public class Hospital
    {
        static Random rnd = new Random();
        LinkedList<Person> patients;
        LinkedList<Person> medics;
        LinkedList<Person> administratives;

        public Hospital() 
        {
            patients = new LinkedList<Person>();
            medics = new LinkedList<Person>();
            administratives = new LinkedList<Person>();
        }

        public bool Menu() 
        {
            Console.WriteLine(@"Select the rol you're gonna play:
1. Patient
2. Medic
3. Administrative
0. Exit");
            int option = InputTools.IntroNum(3);
            Person p;
            switch (option) 
            {
                case 1:
                    SelectRandom(patients, out p);
                    break;
                case 2:
                    SelectRandom(medics, out p);
                    break;
                case 3:
                    SelectRandom(administratives, out p);
                    break;
                default:
                    p = null;
                    return false;
            }
            if (p != null)
                p.Menu();
            return true;
        }
        public void Register() 
        { 
            
        }

        public bool SelectRandom(LinkedList<Person> list, out Person p) 
        {
            if (list.Count() > 0)
            {
                int n = rnd.Next(0, list.Count() - 1);
                p = list.ElementAt(n);
                return true;
            }

            p = null;
            Console.WriteLine($"No registers avaliable.");
            return false;
        }
    }
}
