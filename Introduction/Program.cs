using System;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true) 
            {
                if (Menu())
                {
                    Console.ReadLine();
                    continue;
                }
                return;
            }
        }

        static bool Menu()
        {
            int opcion = SelOpcion();

            switch (opcion)
            {
                case 0:
                    return false;
                case 1:
                    Console.Write("Introduce texto a camelCase:");
                    string camelWord = Console.ReadLine();
                    camelWord = CambiarACase(camelWord, "camelCase");
                    Console.WriteLine(camelWord);
                    break;
                case 2:
                    Console.Write("Introduce texto a PascalCase:");
                    string pascalWord = Console.ReadLine();
                    pascalWord = CambiarACase(pascalWord, "PascalCase");
                    Console.WriteLine(pascalWord);
                    break;
                case 3:
                    CompararFechas();
                    break;
                case 4:
                    ComprobarPalindrome();
                    break;
                case 5:
                    DivisionEntera();
                    break;
                case 6:
                    MediaArintmetica();
                    break;
                case 7:
                    Potencia();
                    break;
                case 8:
                    CompararTextos();
                    break;
                case 9:
                    InvertirTexto();
                    break;
                case 10:
                    InvertirNumero();
                    break;
                case 11:
                    Adivinanza();
                    break;
                case 12:
                    ContarPares();
                    break;
                default:
                    return false;
            }

            return true;
        }

        static int SelOpcion() 
        {


            while (true)
            {
                Console.Clear();
                Console.Write(@"
Selecciona una opción:

1. camelCase
2. PascalCase
3. Comparador de Fechas
4. Comprobar Palindrome
5. Division entera
6. Media arintmetica
7. Potencia
8. Comprador de textos
9. Invertir textos
10. Invertir numero
11. Adivinanza
12. Contar numeros pares hasta el 20

0. Salir

Seleccionar: "
                );

                int opcion = IntroNumero();
                return opcion;
            }
        }
        static String CambiarACase(string word, string type) 
        {
            string caseWord = "";
            int initialIndex = 0;

            if(type == "camelCase")
            {
                for (int i = 0; i < word.Length; i++)
                {
                    if (word[i] == ' ')
                        continue;
                    else
                    {
                        initialIndex = i;
                        word.ToLower();
                        break;
                    }

                }
            }


            bool isNextUpper = false;
            for (int i = initialIndex; i < word.Length; i++)
            {
                if (word[i] == ' ')
                    isNextUpper = true;
                else
                {
                    if (isNextUpper)
                    {
                        caseWord += Char.ToUpper(word[i]);
                        isNextUpper = false;
                    }
                    else
                        caseWord += Char.ToLower(word[i]);
                }
            }

            return caseWord;
        }

        static void IntroFecha(int[] day, int[] month, int[] year) 
        {
            for (int i = 0; i < 2; i++)
            {
                bool isCorrectDate = false;
                DateTime resultDate;
                string date;
                while (!isCorrectDate)
                {
                    Console.WriteLine("Introduce la fecha nº " + (i + 1) + ":");
                    date = Console.ReadLine();
                    isCorrectDate = DateTime.TryParse(date, out resultDate);
                    if (isCorrectDate)
                    {
                        day[i] = resultDate.Day;
                        month[i] = resultDate.Month;
                        year[i] = resultDate.Year;
                    }
                    else
                        Console.WriteLine("Error: Formato de fecha incorrecta");

                }
            }
        }
        static void CompararFechas()
        {
            Console.WriteLine("Introduce fecha en formato dd/MM/yyyy");
            int[] day = new int[2], month = new int[2], year = new int[2];
            IntroFecha(day, month, year);

            string[] options = { "Las fechas son iguales", "la primera fecha es antes que la segunda", "la segunda fecha es antes que la primera" };
            if (year[0] == year[1])
                if (month[0] == month[1])
                    if (day[0] == day[1])
                        Console.WriteLine(options[0]);
                    else
                        if (day[0] < day[1])
                            Console.WriteLine(options[1]);
                        else
                            Console.WriteLine(options[2]);
                else
                    if (month[0] < month[1])
                        Console.WriteLine(options[1]);
                    else
                        Console.WriteLine(options[2]);
            else
                if (year[0] < year[1])
                    Console.WriteLine(options[1]);
                else
                    Console.WriteLine(options[2]);
        }

        static void ComprobarPalindrome() 
        {
            Console.WriteLine("Introduce palabra:");
            string word = Console.ReadLine();
            word = word.ToLower();
           
            int max;

            if (word.Length % 2 == 0)
                max = word.Length / 2;
            else
                max = (word.Length / 2) + 1;
            

            for (int i = 0; i < max; i++)
            {
                if (word[i] == word[word.Length - (i + 1)])
                    continue;
                else
                    Console.WriteLine("No es palindrome.");
            }

            if (word != null)
                Console.WriteLine("Es palindrome.");
            else
                Console.WriteLine("No es palindrome.");
            
        }

        static void DivisionEntera()
        {
            int numerador, denominador;

            Console.Write("Introduce numerador: ");
            numerador = IntroNumero();
            Console.Write("Introduce denominador: ");
            denominador = IntroNumero();
            Console.Write($"Resultado de {numerador}/{denominador} = ");

            if (numerador >= 0 || denominador >= 0) 
            {
                int result = 0;
                while (numerador >= denominador)
                {
                    numerador -= denominador;
                    result++;
                }

                Console.WriteLine($"{result} \nResiduo: {numerador}");
            }
            
        }

        static void MediaArintmetica()
        {
            int sum = 0, nNum = 0;
            Console.WriteLine("Introduce numeros para la media, para dejar de escribir numeros introduce X.");
            while (true) 
            {
                Console.Write("Introduce numero: ");
                int num = IntroNumero();
                if (num == -1)
                    break;

                sum += num;
                nNum++;
            }

            if (nNum > 0)
            {
                float media = (float)sum/(float)nNum;
                Console.WriteLine($"Le media de los numberos introducidos es: {media}");
            }
                

        }

        static void Potencia() 
        {
            Console.Write("Introduce base: ");
            int num = IntroNumero();
            Console.Write("Introduce potencia: ");
            int pow = IntroNumero();

            int result = 1;
            if (pow > 0)
                for (int i = 0; i < pow; i++)
                    result *= num;

            Console.WriteLine($"La potencia de {num}^{pow} = {result}");
        }

        static void CompararTextos() 
        {
            Console.Write("Introduce texto 1: ");
            string textA = Console.ReadLine();

            Console.Write("Introduce texto 2: ");
            string textB = Console.ReadLine();

            if (textA == textB)
                Console.WriteLine("Los textos son iguales");
            else 
            {
                int maxLen;
                if (textA.Length < textB.Length)
                    maxLen = textA.Length;
                else
                    maxLen = textB.Length;

                int i = 0;
                while(i < maxLen)
                {
                    if (textA.ToLower()[i] == textB.ToLower()[i])
                    {
                        i++;
                        continue;
                    }
                    else if (textA.ToLower()[i] < textB.ToLower()[i])
                    {
                        Console.WriteLine($"{textA} va alfabéticamente antes que {textB}.");
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"{textB} va alfabéticamente antes que {textA}.");
                        break;
                    }
                }

                if (i >= maxLen)
                    if(textA.Length < textB.Length)
                        Console.WriteLine($"{textA} va alfabéticamente antes que {textB}.");
                    else
                        Console.WriteLine($"{textB} va alfabéticamente antes que {textA}.");

            }
        }

        static void InvertirTexto() 
        {
            Console.Write("Introduce texto a invertir: ");
            string text = Console.ReadLine();
            string newText = "";
            for (int i = text.Length - 1; i >= 0; i--)
                newText += text[i];

            Console.WriteLine($"El texto {text} se invierte a {newText}.");
        }

        static void InvertirNumero() 
        {
            Console.Write("Introduce un numero: ");
            int num = IntroNumero();
            int newNum = 0;
            Console.Write($"La inversa de {num} ");

            while (num > 0)
            {
                newNum = (newNum * 10) + (num % 10);
                num = num / 10;
            }

            Console.WriteLine($"es {newNum}.");

        }

        static void Adivinanza()
        {
            while (true)
            {
                int num = 0;
                while (num <= 0 || num > 20)
                {
                    Console.Write("Introduce un numero entre 1 y 20: ");
                    num = IntroNumero();
                }

                Random rnd = new Random();
                int randomNum = rnd.Next(1, 20);

                if (randomNum == num)
                {
                    Console.WriteLine("Lo adivinaste!");
                }
                else
                {
                    Console.WriteLine("No lo adivinaste :(");
                }

                Console.WriteLine("Si quieres volver a jugar escribe 'yes' o 'y': ");
                string exit = Console.ReadLine();
                if (exit == "yes" || exit == "y")
                    continue;
                else
                    break;
            }
        }

        static void ContarPares()
        {
            Console.WriteLine("Contando numeros pares hasta el 20 con for, while y do while:");

            Console.WriteLine("\nFor:");
            for (int i = 0; i <=20; i++)
                if (i % 2 == 0)
                    Console.Write($"{i} ");

            Console.WriteLine("\nWhile:");
            int j = 0;
            while (j <= 20)
            { 
                if(j % 2 == 0)
                    Console.Write($"{j} ");
                j++;
            }

            j = 0;
            Console.WriteLine("\nDo While:");
            do
            {
                if (j % 2 == 0)
                    Console.Write($"{j} ");
                j++;
            }
            while (j <= 20);

        }

        static int IntroNumero()
        {
            while (true) 
            { 
                string introNum = Console.ReadLine();
                if (introNum == "X")
                    return -1;
                int num;
                bool isNumeric = int.TryParse(introNum, out num);
                if (isNumeric)
                    return num;

                Console.Write("Error: formato incorrecto. \nVuelve a introducir el valor: ");
            }
        }
    }
}
