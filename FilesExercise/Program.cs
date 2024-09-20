using System;
using System.Collections.Generic;
using System.IO;

namespace EjercicioArchivos
{
    internal class Program
    {
        static string filePath = @"C:\Bootcamp\equipos.txt";
        enum MenuOption
        {
            Exit,
            Add,
            Edit,
            Delete,
            Show,
        };
        static Dictionary<string, int> equipos = new Dictionary<string, int>();
        static Dictionary<string, string[]> jugadores = new Dictionary<string, string[]>();

        static void Main(string[] args)
        {
            while (true)
            {
                RecuperarRegistros();

                switch (Menu())
                {
                    case MenuOption.Add:
                        EditEquipos(null);
                        break;
                    case MenuOption.Edit:
                        EditEquipos();
                        break;
                    case MenuOption.Delete:
                        EditEquipos(true);
                        break;
                    case MenuOption.Show:
                        string e = IntroEquipo();
                        //MostrarRegistros();
                        break;
                    case MenuOption.Exit:
                        return;
                }
                ActualizarRegistros();
                Console.Clear();
                MostrarEquipos();
                Console.Write("> ");
                Console.ReadKey();
            }
        }

        static MenuOption Menu()
        {
            Console.Clear();
            Console.Write(@"
Selecciona una opción: 

 1. Añadir equipo
 2. Modificar puntuación
 3. Eliminar registro
 4. Mostrar registros

 0. Salir

");
            return (MenuOption)IntroNum(true);
        }

        static void EditEquipos(bool? del = false)
        {
            if (del != null)
            {
                MostrarEquipos();
                string e = IntroEquipo().ToLower();
                foreach (var equipo in equipos)
                    if (e == equipo.Key.ToLower())
                    {
                        if ((bool)del)
                            equipos.Remove(equipo.Key);
                        else
                            equipos[equipo.Key] = IntroNum();

                        break;
                    }
            }
            else 
                equipos[IntroEquipo()] = IntroNum();
        }

        static void MostrarEquipos()
        {
            Console.Clear();
            string line;
            try
            {
                StreamReader sr = new StreamReader(filePath);
                line = sr.ReadLine();
                while (line != null)
                {
                    string[] registro = line.Split('█');
                    Console.WriteLine($"{registro[0]}: {registro[1]}");
                    line = sr.ReadLine();
                }
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }

        static void ActualizarRegistros() 
        {
            try
            {
                StreamWriter sw = new StreamWriter(filePath);

                foreach (var equipo in equipos)
                {
                    sw.Write($"{equipo.Key}█{equipo.Value}");
                    foreach (var jugador in jugadores)
                    {
                        string[] listJugadores = jugador.Value;
                        for (int i = 0; i < listJugadores.Length; i++)
                            sw.Write($"█{listJugadores[i]}");
                    }
                    sw.Write("\n");
                }
                
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void RecuperarRegistros()
        {
            string line;
            try
            {
                StreamReader sr = new StreamReader(filePath);
                line = sr.ReadLine();
                while (line != null)
                {
                    string[] registro = line.Split('█');
                    if (int.TryParse(registro[1], out int puntuacion))
                        equipos[registro[0]] = puntuacion;

                    string[] listJugadores = { };
                    for (int i = 2; i < registro.Length; i++)
                        listJugadores[i - 2] = registro[i];

                    jugadores[registro[0]] = listJugadores;
                    

                    line = sr.ReadLine();
                }
                sr.Close();
                
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
                Console.WriteLine("Creando Archivo");
                File.Open(filePath, FileMode.Create).Close();
            }
        }

        static string IntroEquipo()
        {
            MostrarEquipos();
            Console.Write("Selecciona Equipo: ");
            string s = Console.ReadLine();
            return s;
        }

        static int IntroNum(bool isMenu = false)
        {
            while (true)
            {
                if (isMenu)
                {
                    Console.Write("> ");
                    string s = Console.ReadLine();
                    if (Enum.TryParse(s, out MenuOption menuOption))
                        return (int)menuOption;
                }
                else
                {
                    Console.Write("Introduce nueva puntuación: ");
                    string s = Console.ReadLine();
                    if (int.TryParse(s, out int num))
                        return num;
                }

                Console.WriteLine("Error, vuelva a introducir un valor");
            }
        }

        static void MostrarJugadores()
        { 
            
        }
    }
}