using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace HospitalManagement
{
    public class Administrative : Staff
    {
        public Administrative()
        {
            HID.Type = ID.EType.Administrative;
        }
        public Administrative(string name, string lastname, uint phone, uint age, uint idNum, uint hidNum) : base(name, lastname, phone, age, idNum)
        {
            HID.Num = hidNum;
        }
        public override void Register()
        {
            OutputTools.Clear();
            OutputTools.WriteWhite("Register type:\n");
            Console.WriteLine(@"1. Patient
2. Medic
3. Administrative");

            Person p = new Person();
            switch (InputTools.IntroNum(3))
            {
                case 1:
                    p = p as Person;
                    break;
                case 2:
                    p = p as Medic;
                    break;
                case 3:
                    p = p as Medic;
                    break;
                default:
                    p = null;
                    break;
            }

            p.Register();
        }

        public override void Menu()
        {
            OutputTools.Clear();
            Console.WriteLine(@"Select an option:
1. Register
2. Modify
3. Delete");
            switch (InputTools.IntroNum(3)) 
            {
                case 1:
                    Register();
                    break;
                case 2:
                    break;
                case 3:
                    break;
                default:
                    return;
            }
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
