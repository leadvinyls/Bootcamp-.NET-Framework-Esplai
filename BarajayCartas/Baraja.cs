using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarajaYCartas
{
    public class Baraja
    {
        List<Carta> cartas;

        public Baraja(bool? empty = false)
        {
            cartas = new List<Carta>();
            if (empty != null)
            {
                for (int numero = 1; numero <= 12; numero++)
                    foreach (EPalo palo in Enum.GetValues(typeof(EPalo)))
                        cartas.Add(new Carta(numero, palo));

            }
        }

        public List<Carta> Cartas { get { return cartas; } set { cartas = value; } }

        public override string ToString()
        {
            string sOut = "";
            foreach (Carta carta in this.cartas)
                sOut += $"{carta} .{this.cartas.IndexOf(carta) + 1}\n";

            return sOut;
        }

        public void AddCarta(Carta nuevaCarta)
        {
            cartas.Add(nuevaCarta);
        }

        public Carta RobarCarta() 
        {
            Carta cartaRobada = cartas[0];
            cartas.Remove(cartaRobada);

            return cartaRobada;
        }

        public void Barajar()
        {
            List<Carta> cartasBarajadas = new List<Carta>();
            Random rnd = new Random();

            while (this.cartas.Count() != 0)
            {
                int index = rnd.Next(0, this.cartas.Count());
                Carta cartaActual = this.cartas[index];
                cartasBarajadas.Add(cartaActual);
                this.cartas.Remove(cartaActual);
            }

            this.cartas = cartasBarajadas;
        }

        public Carta RobarCartaPosicionN(int n)
        {
            Carta carta = this.cartas[n];
            this.cartas.RemoveAt(n);
            return carta;
        }

        public Carta RobarCartaRandom()
        {
            Random rnd = new Random();
            int numCarta = rnd.Next(0, this.cartas.Count());
            return this.RobarCartaPosicionN(numCarta);
        }
    }
}
