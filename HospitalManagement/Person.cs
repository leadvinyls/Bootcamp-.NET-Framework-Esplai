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
        public string ID { get; set; }

        public Person() 
        {
            Name = "";
            Age = 0;
            ID = "00000000X";
        }

        public Person(string name, uint age, string id)
        {
            this.Name = name;
            this.Age = age;
            this.ID = id;
        }
    }
}
