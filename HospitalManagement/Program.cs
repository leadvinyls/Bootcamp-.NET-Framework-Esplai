using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace HospitalManagement
{
    internal class Program
    {

        static List<ID> regIds = new List<ID>();
        static string appointmentsFile = @"C:\Bootcamp\ids.txt";
        static void Main(string[] args)
        {
            Hospital h = new Hospital();
            while (true)
            {
                OutputTools.Clear();
                if (!h.Menu())
                    break;
                Console.ReadKey();
            }
            foreach (Person p in h.People)
                p.Draw();

                //Console.WriteLine(p);
            Console.ReadKey();
        }
    }
}
