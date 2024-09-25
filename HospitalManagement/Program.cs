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
        static string appointmentsFile = @"C:\Bootcamp\appointments.txt";
        static string administrativesFile = @"C:\Bootcamp\administratives.txt";
        static string medicsFile = @"C:\Bootcamp\medics.txt";
        static string patientsFile = @"C:\Bootcamp\patients.txt";
        static string illnessesFile = @"C:\Bootcamp\illnesses.txt";
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
        }
    }
}
