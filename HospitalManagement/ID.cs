using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HospitalManagement
{
    public class ID
    {
        public enum EType
        {
            Patient = 'P',
            Administrative = 'A',
            Medic = 'M'
        }
        public uint Num { get; set; }
        public EType Type { get; set; }
        public ID() 
        {
            Num = 00000000;
            Type = (EType)'U';
        }

        public ID(uint number, char type) : this()
        {
            this.Num = number;
            if (EType.TryParse(char.ToUpper(type).ToString(), out EType t))
                this.Type = t;
        }

        public static bool TryParse(string sId, out ID id) 
        {
            id = null;
            string sNumber = "";
            char type = ' ';

            for (int i = 0; i < 8; i++)
                if (uint.TryParse(sId[i].ToString(), out uint n))
                    sNumber += sId[i];
                else
                    return false;

            uint.TryParse(sNumber, out uint number);

            if (EType.TryParse(((EType)sId[8]).ToString(), out EType t))
                type = (char)t;
            else
                return false;

            id = new ID(number, type);
            return true;
        }

        public override string ToString()
        {
           return $"{Num.ToString("D8")}{(char)Type}";
        }
    }
}
