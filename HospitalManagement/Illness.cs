using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement
{
    public class Illness
    {
        string Name { get; set; }
        string Description { get; set; }

        public Illness(string name, string description) 
        {
            this.Name = name;
            this.Description = description;
        }
        public override string ToString()
        {
            return $"Name: {Name}, Description: {Description}";
        }
    }
}
