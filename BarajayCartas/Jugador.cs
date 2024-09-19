using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarajaYCartas
{
    public class Jugador
    {
        public string Nombre { get ; set ; }
        Baraja barajaJugador;

        public Baraja BarajaJugador { get { return barajaJugador; }}

        public Jugador()
        {
            this.Nombre = "";
            barajaJugador = new Baraja(null);
        }

        public Jugador(Jugador j) 
        {
            this.Nombre = j.Nombre;
            this.barajaJugador = j.barajaJugador;
        }

        public Jugador(string nombre) 
        {
            this.Nombre = nombre;
            this.barajaJugador = new Baraja(null);
        }

        public override string ToString()
        {
            return $"{this.Nombre}";
        }
    }
}
