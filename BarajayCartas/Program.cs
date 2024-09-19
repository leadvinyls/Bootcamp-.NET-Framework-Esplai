using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Utilidades;
using Utilities;

namespace BarajaYCartas
{
    internal class Program
    {
        static List<Jugador> jugadores = new List<Jugador>();
        static Baraja barajaCentral = new Baraja();
        static void Main()
        {
            while (true)
            {
                if (Menu())
                    Partida();
                else
                    break;
            }
        }

        static bool Menu()
        {
            Console.Write(@"Batalla de Cartas

Introduce el numero de jugadores (entre 2 y 5)
");
            while (true)
            {
                int nJugadores = InputTools.IntroNum();
                if (2 <= nJugadores && nJugadores <= 5)
                {
                    InitJugadores(nJugadores);
                    return true;
                }
                else if (nJugadores == 0)
                    return false;
                else
                    Console.WriteLine("Error: Numero de jugadores fuera de rango");
            }      
        }
        static void InitJugadores(int nJugadores)
        {
            for (int jugador = 1; jugador <= nJugadores; jugador++)
                jugadores.Add(new Jugador($"Jugador {jugador}"));

        }
        static void Partida()
        {
            OutputTools.Clear();

            Dictionary<Jugador, Carta> mesa = new Dictionary<Jugador, Carta>();
            barajaCentral.Barajar();
            RepartirCartas();

            Console.WriteLine("Cartas Repartidas");
            while (jugadores.Count() >= 2)
            {
                Jugador jugadorActual = jugadores[0];
                while (mesa.Count() < jugadores.Count())
                {
                    OutputTools.Clear();
                    JugarCarta(ref jugadorActual, ref mesa);
                    jugadorActual = CambiarTurno();
                }
                CheckCartaGanadora(ref mesa);
            }

            Console.WriteLine($"El ganador es: {jugadores[0]}");
        }

        static Jugador CambiarTurno() 
        {
            Jugador turnoActual = jugadores[0];
            jugadores.RemoveAt(0);
            jugadores.Add(turnoActual);
            return jugadores[0];
        }

        static void RepartirCartas() 
        {
            while (barajaCentral.Cartas.Count() > 0)
                foreach (Jugador jugador in jugadores)
                    jugador.BarajaJugador.AddCarta(barajaCentral.RobarCarta());
        }

        static void JugarCarta(ref Jugador jugadorActual, ref Dictionary<Jugador, Carta> mesa) 
        {
            //Carta cartaJugada = jugadorActual.BarajaJugador.RobarCarta();
            Console.Write("Selecciona carta\n");
            Baraja b = jugadorActual.BarajaJugador;
            Carta cartaJugada = b.RobarCartaPosicionN(IntroCarta(b));

            if(jugadorActual.BarajaJugador.Cartas.Count() > 0)
                mesa.Add(jugadorActual,cartaJugada);

            OutputTools.Clear();
            Console.WriteLine($"{jugadorActual} ha jugado la carta\n{cartaJugada}");
            Console.ReadKey();
        }
        static void CheckCartaGanadora(ref Dictionary<Jugador, Carta> mesa)
        {
            Dictionary<Jugador, Carta> mesaEmpate = new Dictionary<Jugador, Carta>();
            Jugador jugadorGanador = jugadores[0];
            Carta cartaGanadora = mesa[jugadorGanador];

            foreach (var element in mesa)
            {
                Carta cartaActual = element.Value;
                Jugador jugadorActual = element.Key;

                if ((cartaActual.Numero > cartaGanadora.Numero) || ((int)cartaActual.Palo < (int)cartaGanadora.Palo))
                {
                    cartaGanadora = cartaActual;
                    jugadorGanador = jugadorActual;
                }
            }

            OutputTools.Clear();
            Console.WriteLine($"{jugadorGanador.Nombre} ha ganado la ronda!");
            Console.ReadKey();

            foreach (Carta carta in mesa.Values)
                jugadorGanador.BarajaJugador.AddCarta(carta);

            mesa = new Dictionary<Jugador, Carta>();
        }

        static void CheckPlayerLoss()
        {
            foreach (var player in jugadores)
                if (player.BarajaJugador.Cartas.Count() <= 0)
                    jugadores.Remove(player);
        }

        static int IntroCarta(Baraja b) 
        {
            int num;

            do
            {
              num = InputTools.IntroNum();
            } while (num < 0 && num > b.Cartas.Count());

            return num - 1;
        }
    }
}
