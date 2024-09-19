
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarajaYCartas
{
    public enum EPalo
    {
        Oros,
        Copas,
        Espadas,
        Bastos
    }
    public class Carta
    {
        public int Numero { get; set; }
        public EPalo Palo { get; set; }

        public Carta()
        {

        }
        public Carta(int numero, EPalo palo)
        {
            this.Numero = numero;
            this.Palo = palo;
        }

        public override string ToString() 
        {

            string sOut = " ___________________ \n"; 
            sOut += $"|";
            if (this.Numero < 10)
                sOut += $" {this.Numero}       ";
            else
            { 
                switch (this.Numero)
                {
                    case 10:
                        sOut += " Sota    ";
                        break;
                    case 11:
                        sOut += " Caballo ";
                        break;
                    case 12:
                        sOut += " Rey     ";
                        break;
                }
            }

            sOut += "|";

            switch (this.Palo) 
            {
                case EPalo.Oros:
                    sOut += " Oros    ";
                    break;
                case EPalo.Copas:
                    sOut += " Copas   ";
                    break;
                case EPalo.Espadas:
                    sOut += " Espadas ";
                    break;
                case EPalo.Bastos:
                    sOut += " Bastos  ";
                    break;
            }

            sOut += "|";
            

            return sOut; 
        }
    }
}
