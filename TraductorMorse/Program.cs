using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TraductorMorse
{
    internal class Program
    {
        enum eWeek
        {
            Lunes,
            Martes,
            Miercoles,
            Jueves,
            Viernes,
            Sabado,
            Domingo
        }

        static Dictionary<string, string> morseHumano = new Dictionary<string, string>
        {
            {" ", "/"},{"A", ".-"}, {"B", "-..."}, {"C", "-.-."}, {"CH", "----"}, {"D", "-.."}, {"E", "."}, {"F", "..-."}, {"G", "--."}, {"H", "...."}, 
            {"I", ".."}, {"J", ".---"}, {"K", "-.-"}, {"L", ".-.."}, {"M", "--"}, {"N", "-."}, {"Ñ", "--.--"}, {"O", "---"}, {"P", ".--."}, {"Q", "--.-"},
            {"R", ".-."}, {"S", "..."}, {"T", "-"}, {"U", "..-"}, {"V", "...-"}, {"W", ".--"}, {"X", "-..-"}, {"Y", "-.--"}, {"Z", "--.."}, {"0", "-----"}, 
            {"1", ".----"}, {"2", "..---"}, {"3", "...--"}, {"4", "....-"}, {"5", "....."}, {"6", "-...."}, {"7", "--..."}, {"8", "---.."}, {"9", "----."}, 
            {".", ".-.-.-"}, {",", "--..--"}, {"?", "..--.."}, {"\"", ".-..-."}
        };
        static void Main(string[] args)
        {
            while (true)
            {
                bool? option = menu();
                if (option != null)
                {
                    if ((bool)option)
                        HumanToMorse();
                    else
                        MorseToHuman();

                    Console.ReadKey();
                }
                else
                    break;
            }

            return;
        }

        static bool? menu() 
        {
            while (true)
            {
                Console.Clear();
                Console.Write(@"Introduce un dia de la semana: 
0. Lunes
1. Martes
2. Miercoles
3. Jueves
4. Viernes
5. Sabado
6. Domingo
> ");
                string s = Console.ReadLine();
                bool isValid = eWeek.TryParse(s, out eWeek dia);
                if (isValid)
                {
                    Console.WriteLine($"El dia {dia} es el día nº: {(int)dia}");
                    Console.ReadKey();
                    break;
                }
                    
            }
           
            

            //Preguntar al usuario el dia de la semana

            Console.Clear();
            Console.WriteLine(@"Seleccione Traducción:
1. Humano a Morse
2. Morse a Humano
0. Salir");

            while (true) 
            {
                Console.Write("> ");
                string s = Console.ReadLine();
                bool isValid = int.TryParse(s, out int option);

                if (isValid)
                {
                    switch (option)
                    {
                        case 0:
                            return null;
                        case 1:
                            return true;
                        case 2:
                            return false;
                    }
                }
                else
                    Console.WriteLine("\nError: El valor introducido es incorrecto.");   
            }
        }

        static void HumanToMorse()
        {
            Console.Write("Introduce Frase: ");
            string phrase = Console.ReadLine();
            string newPhrase = "";
            bool isSpace = true;

            for (int i = 0; i < phrase.Length; i++)
            {
                string symbol = phrase[i].ToString().ToUpper();

                //El programa omitira simbolos no existentes en el diccionario morse
                if (!morseHumano.ContainsKey(symbol))
                {
                    isSpace = true;
                    continue;
                }

                // Casos especiales en los espacios y CH
                if (symbol == " ")
                {
                    if (isSpace)
                        continue;
                    else
                        isSpace = true;
                }
                else if (symbol == "C" && phrase[i + 1].ToString().ToUpper() == "H")
                {
                    i++;
                    symbol = "CH";
                }

                isSpace = false;
                newPhrase += morseHumano[symbol] + " ";
            }

            Console.WriteLine($"Frase traducida a Morse: {newPhrase}");
        }

        static void MorseToHuman() 
        {
            Console.Write("Introduce Morse: ");
            string phrase = Console.ReadLine();
            string newPhrase = "";
            string symbol = "";

           
            for (int i = 0; i < phrase.Length; i++) 
            { 
                while (i < phrase.Length && phrase[i].ToString() != " ")
                {
                    symbol += phrase[i].ToString();
                    i++;
                }
                
                if (morseHumano.ContainsValue(symbol))
                    foreach (KeyValuePair<string, string> element in morseHumano)
                        if (element.Value == symbol)
                            newPhrase += element.Key;

                symbol = "";
            }

            Console.WriteLine($"Frase traducida a Humano: {newPhrase}");
        }
    }
}
