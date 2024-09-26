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
        LinkedList<Person> people;
        public LinkedList<Person> People { get { return people; } }
        public Hospital() 
        {
            people = new LinkedList<Person>();
        }

        public bool Menu() 
        {
            Console.WriteLine(@"Select the rol you're gonna play:
1. Patient
2. Medic
3. Administrative
0. Exit");
            int option = InputTools.IntroNum(3);
            Person p = new Person();
            switch (option) 
            {
                case 1:
                    break;
                case 2:
                    p = new Medic();
                    break;
                case 3:
                    p = new Administrative();
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

        public bool SelectPerson(Type t, out Person p) 
        {
            var list = People.Where(o => o.GetType() == t );

            if (list.Count() > 0)
            {
                int n = rnd.Next(0, People.Count() - 1);
                p = list.ElementAt(n);
                return true;
            }

            p = null;
            Console.WriteLine($"No registers avaliable.");
            return false;
        }
    }
}
