using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ConsoleApp3
{
    internal class TikTakToe
    {
        enum GameMode
        {
            Salir,
            Bidimensional,
            Tridimensional
        };

        enum Ejes
        {
            xy,
            yz,
            xz
        };

        static void Main(string[] args)
        {
            while (true)
            {
                switch (menu())
                {
                    case GameMode.Bidimensional:
                        PartidaBidimensional(IntroduceDimension());
                        break;
                    case GameMode.Tridimensional:
                        PartidaTridimensional(IntroduceDimension());
                        break;
                    case GameMode.Salir:
                        return;
                }


                Console.Write("Quieres volver a jugar? (yes) / (Key): ");
                string s = Console.ReadLine();
                if (s == "yes" || s == "y")
                {
                    Console.Clear();
                    continue;
                }

                break;
            }
        }

        static Enum menu()
        {
            while (true)
            {
                Console.Write(@"Selecciona modo de juego:
1. 2D, n en raya
2. 3D, 3 en raya
0. Salir
> ");
                string s = Console.ReadLine();
                bool isValid = Enum.TryParse(s, out GameMode gameMode);
                if (isValid)
                    return gameMode;

                Console.WriteLine("Error, vuelve a introducir opción");

            }
        }

        static int IntroduceDimension()
        {
            int dimension;
            Console.Write("Introduce dimension: ");
            while (true)
            {
                string s = Console.ReadLine();
                bool isCorrect = int.TryParse(s, out dimension);
                if (isCorrect)
                    if (dimension > 0)
                        break;

                Console.Write("Error: Valor incorrecto.\nVuelve a introducir: ");
            }
            Console.Clear();

            return dimension;
        }
        static void PartidaBidimensional(int dim)
        {
            Console.WriteLine($"Tamaño del tablero: {dim} x {dim}");

            bool?[,] tablero = new bool?[dim, dim];

            int jugadas = dim*dim;
            ImprimirTablero(tablero, dim);
            while (jugadas > 0)
            {
                bool turno = jugadas % 2 != 0;
                //Si el numero de la Jugada es impar el jugador es true (X), si es par es false (O)
                JugarFicha(ref tablero, turno);
                ImprimirTablero(tablero, dim);
                if (ComprobarVictoria(ref tablero, dim, turno))
                {
                    ImprimirTablero(tablero, dim, turno);
                    Console.ReadKey();
                    break;
                }

                jugadas--;
            }

            if (jugadas == 0)
                Console.WriteLine("Empate técnico por falta de espacio");
        }

        static void JugarFicha(ref bool?[,] tablero, bool turno)
        {
            Point p = new Point();

            while (true)
            {
                Console.WriteLine($"Es el turno del jugador {(turno ? "X" : "O")}.");
                Console.Write("Introduce fila: ");
                p.X = InputPosicion(tablero.GetLength(0));
                Console.Write("Introduce columna: ");
                p.Y = InputPosicion(tablero.GetLength(0));

                if (tablero[p.X - 1, p.Y - 1] == null)
                {
                    tablero[p.X - 1, p.Y - 1] = turno;
                    break;
                }
                else
                    Console.WriteLine("Error: Espacio ocupado por otra ficha.");
            }
        }

        static int InputPosicion(int dimension)
        {
            int value;
            while (true)
            {
                string s = Console.ReadLine();
                bool isCorrect = int.TryParse(s, out value);
                if (isCorrect)
                    if (value <= dimension && value > 0)
                        break;

                Console.Write("Error: Valor incorrecto.\nVuelve a introducir: ");
            }

            return value;
        }

        static bool ComprobarVictoria(ref bool?[,] tablero, int dim, bool turno)
        {
            //Para la pantalla de victoria, limpiamos los valores y solo nos quedamos con la linea ganadora
            bool?[,] tableroVacio = new bool?[dim, dim];

            bool isRightDiag = true, isLeftDiag = true;
            for (int i = 0; i < dim; i++)
            {
                bool isCol = true, isRow = true;
                for (int j = 0; j < dim - 1; j++)
                {
                    //Comprobamos filas
                    if (isRow && ((tablero[i, j] != tablero[i, j + 1]) || (tablero[i, j] == null)))
                        isRow = false;

                    //Comprobamos columnas
                    if (isCol && ((tablero[j, i] != tablero[j + 1, i]) || (tablero[j, i] == null)))
                        isCol = false;

                    //Left Diag
                    if (isLeftDiag && ((tablero[j, j] != tablero[j + 1, j + 1]) || (tablero[j, j] == null)))
                        isLeftDiag = false;

                    //Right Diag
                    if (isRightDiag && ((tablero[dim - 1 - j, j] != tablero[dim - 1 - (j + 1), j + 1]) || (tablero[dim - 1 - j, j] == null)))
                        isRightDiag = false;

                }

                if (isRow || isCol || isRightDiag || isLeftDiag)
                {
                    tablero = tableroVacio;
                    if (isRow)
                        for (int k = 0; k < dim; k++)
                            tablero[i, k] = (bool?)turno;
                    else if (isCol)
                        for (int k = 0; k < dim; k++)
                            tablero[k, i] = (bool?)turno;
                    else if (isRightDiag)
                        for (int k = 0; k < dim; k++)
                            tablero[dim - 1 - k, k] = (bool?)turno;
                    else
                        for (int k = 0; k < dim; k++)
                            tablero[k, k] = (bool?)turno;

                    return true;
                }
            }

            return false;
        }

        static void ImprimirTablero(bool?[,] tablero, int dim, bool? victoria = null)
        {
            Console.Clear();

            //Si los caracteres exceden el tamaño de la consola, limpiamos el buffer de scrollbar
            //Si no se limpia ese buffer, la impresion es erronea.
            Console.Write("\x1b[3J");

            //Traducimos la matriz de booleanos nulleables a una matriz de strings
            string[,] tableroString = new string[dim, dim];
            for (var i = 0; i < dim; i++)
            {
                for (var j = 0; j < dim; j++)
                {
                    if (victoria != null)
                    {
                        if (tablero[i, j] == victoria)
                            tableroString[i, j] = "█";
                        else
                            tableroString[i, j] = " ";
                    }
                    else
                    {
                        if (tablero[i, j] == true)
                            tableroString[i, j] = "X";
                        else if (tablero[i, j] == false)
                            tableroString[i, j] = "O";
                        else
                            tableroString[i, j] = " ";
                    }
                }
            }

            for (int i = 0; i < dim; i++)
            {
                Console.Write("\n");
                for (int j = 0; j < dim; j++)
                {
                    if (j == 0)
                        Console.Write(" ");

                    Console.Write($"{tableroString[i, j]}");
                    if (j < dim - 1)
                        Console.Write($" | ");
                }

                if (i < dim - 1)
                {
                    Console.Write("\n");
                    for (int k = 0; k < dim; k++)
                        if (k < dim)
                            Console.Write("- - ");
                        else
                            Console.Write("-");
                }
            }

            Console.Write("\n\n");

            if (victoria != null)
            {
                Console.ForegroundColor= ConsoleColor.Black;
                Console.BackgroundColor= ConsoleColor.White;
                Console.WriteLine($" ¡Fin de la partida, gana el jugador {((bool)victoria ? "X" : "O")}! ");
                Console.ForegroundColor= ConsoleColor.White;
                Console.BackgroundColor= ConsoleColor.Black;
            }
        }

        static void PartidaTridimensional(int dim)
        {
            Console.WriteLine($"Tamaño del tablero: {dim} x {dim} x {dim}");
            bool?[,,] tablero = new bool?[dim, dim, dim];
            int jugadas = dim*dim*dim;

            while (jugadas > 0)
            {
                bool turno = jugadas % 2 != 0;
                
                ImprimirTableroTridimensional(tablero, dim);
                JugarFichaTridmensional(ref tablero, turno);

                if (ComprobarVictoriaTridimensional(ref tablero, dim, turno))
                {
                    ImprimirTableroTridimensional(tablero, dim);
                    Console.WriteLine($" ¡Fin de la partida, gana el jugador {((bool)turno ? "X" : "O")}! ");
                    return;
                }

                jugadas--;
                
            }
            
        }

        static void JugarFichaTridmensional(ref bool?[,,] tablero, bool turno)
        {
            
            int fila, columna, profundidad;

            while (true)
            {
                Console.WriteLine($"Es el turno del jugador {(turno ? "X" : "O")}.");
                Console.Write("Introduce fila: ");
                fila = InputPosicion(tablero.GetLength(0));
                Console.Write("Introduce columna: ");
                columna = InputPosicion(tablero.GetLength(0));
                Console.Write("Introduce profundidad: ");
                profundidad = InputPosicion(tablero.GetLength(0));

                if (tablero[fila - 1, columna - 1, profundidad - 1] == null)
                {
                    tablero[fila - 1, columna - 1, profundidad - 1] = turno;
                    break;
                }
                else
                    Console.WriteLine("Error: Espacio ocupado por otra ficha.");
            }


        }

        static void ImprimirTableroTridimensional(bool?[,,] tablero, int dim, bool? victoria = null)
        {
            Console.Clear();

            //Si los caracteres exceden el tamaño de la consola, limpiamos el buffer de scrollbar
            //Si no se limpia ese buffer, la impresion es erronea.
            Console.Write("\x1b[3J");

            for (int p = 0; p < dim; p++)
            {
                Console.WriteLine($"Profundidad: {p + 1}");

                string[,,] tableroString = new string[dim, dim, dim];
                for (var i = 0; i < dim; i++)
                {
                    for (var j = 0; j < dim; j++)
                    {
                        if (victoria != null)
                        {
                            if (tablero[i, j, p] == victoria)
                                tableroString[i, j, p] = "█";
                            else
                                tableroString[i, j, p] = " ";
                        }
                        else
                        {
                            if (tablero[i, j, p] == true)
                                tableroString[i, j, p] = "X";
                            else if (tablero[i, j, p] == false)
                                tableroString[i, j, p] = "O";
                            else
                                tableroString[i, j, p] = " ";
                        }
                    }
                }

                for (int i = 0; i < dim; i++)
                {
                    Console.Write("\n");
                    for (int j = 0; j < dim; j++)
                    {
                        if (j == 0)
                            Console.Write(" ");

                        Console.Write($"{tableroString[i, j, p]}");
                        if (j < dim - 1)
                            Console.Write($" | ");
                    }

                    if (i < dim - 1)
                    {
                        Console.Write("\n");
                        for (int k = 0; k < dim; k++)
                            if (k < dim)
                                Console.Write("- - ");
                            else
                                Console.Write("-");
                    }
                }
                Console.Write("\n\n");
            }

            //Traducimos la matriz de booleanos nulleables a una matriz de strings
            

            Console.Write("\n\n");

            if (victoria != null)
            {
                Console.ForegroundColor= ConsoleColor.Black;
                Console.BackgroundColor= ConsoleColor.White;
                Console.WriteLine($" ¡Fin de la partida, gana el jugador {((bool)victoria ? "X" : "O")}! ");
                Console.ForegroundColor= ConsoleColor.White;
                Console.BackgroundColor= ConsoleColor.Black;
            }
        }

        static bool ComprobarVictoriaTridimensional(ref bool?[,,] tablero, int dim, bool turno)
        {
            bool isVictory = false;

            //Analizamos los planos del cubo por los 3 ejes x y z, en total son 9 posibles planos
            for (int i = 0; i < 3; i++) // selecionamos uno de los 3 planos, xy, yz, xz
                for (int j = 0; j < dim; j++) //seleccionamos la profundidad del plano
                {
                    bool?[,] planoActual = new bool?[dim, dim];
                    planoActual = selecPlano(tablero, (Ejes)i, j, dim);
                    isVictory = ComprobarVictoria(ref planoActual, dim, turno);
                    if (isVictory)
                        return true;
                }

            //Analizamos las diagonales, en total son 4

            //Diag 1
            bool diagA = true, diagB = true, diagC = true, diagD = true;

            for (int i = 0; i < dim - 1; i++)
            {
                if ((diagA && (tablero[i, i, i] != tablero[i + 1, i + 1, i + 1])) || (tablero[i, i, i] == null))
                    diagA = false;

                if ((diagB && (tablero[i, i, dim - 1 - i] != tablero[i + 1, i + 1, dim - 1 - (i + 1)])) || (tablero[i, i, dim - 1 - i] == null))
                    diagB = false;

                if ((diagC && (tablero[i, dim - 1 - i, i] != tablero[i + 1, dim - 1 - (i + 1), i + 1])) || (tablero[i, dim - 1 - i, i] == null))
                    diagC = false;

                if ((diagD && (tablero[dim - 1 - i, i, i] != tablero[dim - 1 - (i + 1), i + 1, i + 1])) || (tablero[dim - 1 - i, i, i] == null))
                    diagD = false;

                if (!diagA && !diagB && !diagC && !diagD)
                    break;
            }

            isVictory = diagA || diagB || diagC || diagD;

            return isVictory;
        }

        static bool?[,] selecPlano(bool?[,,] tableroTridimensional, Ejes eje, int profundidad, int dim) 
        {
            bool?[,] tableroEje = new bool?[dim,dim];


            switch (eje)
            {
                case Ejes.xy:
                    for (int i = 0; i < dim; i++)
                        for (int j = 0; j < dim; j++)
                            tableroEje[i, j] = tableroTridimensional[i,j,profundidad];
                    break;
                case Ejes.xz:
                    for (int i = 0; i < dim; i++)
                        for (int j = 0; j < dim; j++)
                            tableroEje[i, j] = tableroTridimensional[i, profundidad, j];
                    break;
                case Ejes.yz:
                    for (int i = 0; i < dim; i++)
                        for (int j = 0; j < dim; j++)
                            tableroEje[i, j] = tableroTridimensional[profundidad, i, j];
                    break;

            }

            return tableroEje;
        }
    }


}
