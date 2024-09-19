using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

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
                {
                    Partida();
                }
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
                int nJugadores = IntroNum();
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

        static int IntroNum()
        {
            while (true)
            {
                Console.Write("> ");
                string s = Console.ReadLine();
                if (int.TryParse(s, out int num))
                    return num;

                Console.WriteLine("Error: El valor introducido no es un número");
            }
        }

        static void InitJugadores(int nJugadores)
        {
            for (int jugador = 1; jugador <= nJugadores; jugador++)
                jugadores.Add(new Jugador($"Jugador {jugador}"));

        }

        static void Partida()
        {
            Console.Clear();

            Dictionary<Jugador, Carta> mesa = new Dictionary<Jugador, Carta>();
            barajaCentral.Barajar();
            RepartirCartas();
            Console.WriteLine("Cartas Repartidas");
            while (jugadores.Count() >= 2)
            {
                Jugador jugadorActual = jugadores[0];
                while (mesa.Count() < jugadores.Count())
                {
                    Console.Clear();
                    Console.WriteLine("\x1b[3J");

                    Console.WriteLine($"Turno: {jugadorActual}");
                    Console.WriteLine($"{jugadorActual.BarajaJugador}");
                    
                    //Console.ReadKey();
                    JugarCarta(ref jugadorActual, ref mesa);
                    //Console.ReadKey();

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

            Console.Clear();
            Console.WriteLine("\x1b[3J");
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
                if (cartaActual.Numero > cartaGanadora.Numero)
                {
                    cartaGanadora = element.Value;
                    jugadorGanador = element.Key;
                }
                else
                {
                    if (!mesaEmpate.ContainsValue(cartaGanadora) && !mesaEmpate.ContainsValue(cartaActual) && jugadorActual != jugadorGanador)
                    {
                        mesaEmpate.Add(jugadorGanador, cartaGanadora);
                        mesaEmpate.Add(jugadorActual, cartaActual);
                    }
                }
            }

            if (mesaEmpate.Count() > 0)
            {
                foreach (var element in mesaEmpate)
                {
                    Jugador jugadorActual = element.Key;
                    JugarCarta(ref jugadorActual, ref mesa);
                }
                CheckCartaGanadora(ref mesa);
            }

            Console.Clear();
            Console.WriteLine("\x1b[3J");
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
              num = IntroNum();
            } while (num < 0 && num > b.Cartas.Count());

            return num - 1;
        }
    }
}
