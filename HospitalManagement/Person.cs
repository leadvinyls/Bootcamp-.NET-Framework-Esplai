using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement
{
    public class Person
    {
        public string Name { get; set; }
        public uint Age { get; set; }
        public ID PID { get; set; }
        public Person() 
        {
            Name = "";
            Age = 0;
            PID = new ID();
        }

        public Person(string name, uint age)
        {
            this.Name = name;
            this.Age = age;
        }

        public virtual void Menu() { }
        public virtual string ToFileString() 
        {
            return $"{Name}█{Age}█{PID.ToFileString()}";
        }
    }
}
