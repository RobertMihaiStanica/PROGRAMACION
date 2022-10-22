using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace statics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Elige la opccion que quieres usar:");
            Console.WriteLine("1) Ejercicio 1 (Multiplos)");
            Console.WriteLine("2) Ejercicio 2 (Elevar un numero a otro)");
            Console.WriteLine("3) Ejercicio 3 (Calculadora)");
            Console.WriteLine("4) Ejercicio 4 (Numero Primo)");
            Console.WriteLine("5) Ejercicio 5 (Tarot)");

            int option = Convert.ToInt32(Console.ReadLine());
            switch (option)
            {
                case 1:
                    Console.WriteLine("Has elegido la primera opccion, ejecutando primer ejercicio");
                    Exercise1();
                    break;
                case 2:
                    Console.WriteLine("Has elegido la segunda opccion, ejecutando segundo ejercicio");
                    Exercise2();
                    break;
                case 3:
                    Console.WriteLine("Has elegido la tercera opccion, ejecutando tercer ejercicio");
                    Exercise3();
                    break;
                case 4:
                    Console.WriteLine("Has elegido la cuarta opccion, ejecutando cuarto ejercicio");
                    Exercise4();
                    break;
                case 5:
                    Console.WriteLine("Has elegido la quinta opccion, ejecutando quinto ejercicio");
                    Exercise5();
                    break;
            }
        }
        static void Exercise1()
        {
            Console.WriteLine("Dame el numero principal:");
            int number = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("La multiplicacion de los multiplos es " + MultsMultiply(number));
        }
        static int MultsMultiply(int num)
        {
            int num2;
            int mult = 1;
            do
            {
                Console.WriteLine("Introduce el numero a multiplicar:");
                num2 = Convert.ToInt32(Console.ReadLine());
                if (num2 % num == 0 && num2 != 0)
                {
                    mult = mult * num2;
                }
            } while (num2 != 0);
            return mult;
        }
        static void Exercise2()
        {
            Console.WriteLine("Introduce el numero que vas a elevar");
            int num = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("El resultado es " + Power(num));
        }
        static int Power(int num)
        {
            int num2;
            int total = num;
            int counter = 0;
            Console.WriteLine("Introduce el numero al que va a ser elevado");
            num2 = Convert.ToInt32(Console.ReadLine());
            while (counter != num2 && num2 != 0)
            {
                total = total * num;
                counter++;
                Console.WriteLine(counter);
            }
            if (num2 == 0)
            {
                total = 1;
            }
            return total;
        }
        static void Exercise3()
        {

            Console.WriteLine("¿Que tipo de operacion te gustaria realizar?");
            Console.WriteLine("1) Sumar dos numeros");
            Console.WriteLine("2) Multiplicar dos numeros");
            Console.WriteLine("3) Dividir dos numeros");
            int option = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("El resultado de su operacion es " + Calc(option));
        }
        static int Calc(int option)
        {
            int num1;
            int num2;
            int result;
            Console.WriteLine("Introduce el primer numero:");
            num1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Introduce el segundo numero:");
            num2 = Convert.ToInt32(Console.ReadLine());
            switch (option)
            {
                case 1:
                    result = num1 + num2;
                    return result;
                case 2:
                    result = num1 * num2;
                    return result;
                case 3:
                    result = num1 / num2;
                    return result;
                default:
                    result = 0;
                    return result;
            }
        }
        static void Exercise4()
        {
            Console.WriteLine("Dime el numero que quieras averiguar si es primo o no:");
            int primenum = Convert.ToInt32(Console.ReadLine());
            bool prime;
            Console.WriteLine("Para saber si el numero es primo escribe true");
            Console.WriteLine("Paber saber si el numero es compuesto escribe false");
            prime = Convert.ToBoolean(Console.ReadLine());
            bool answer = IsNumberPrime(primenum, prime);
            Console.WriteLine(answer);
        }
        static bool IsNumberPrime(int num, bool isPrime)
        {
            bool prime = true;
            int counter = 2;
            do
            {
                if (num % counter == 0)
                {
                    prime = false;
                }
                counter = counter +1;
            } while (counter < num && prime);
            
            if (isPrime == true)
            {
                return prime;
            }
            else
            {
                return !prime;
            }
        }
        static void Exercise5()
        {
            int year;
            int month = 0;
            int day = 0;
            int sum;
            int total = 0;
            Console.WriteLine("Dame el año de nacimiento:");
            year = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Dame el mes de nacimiento:");
            month = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Dame el dia de nacimiento:");
            day = Convert.ToInt32(Console.ReadLine());
            sum = year + month + day;
            string sumchar = Convert.ToString(sum, 10);
            foreach (char number in sumchar)
            { 
                int num2 = (int)Char.GetNumericValue(number);
                total = total + num2;
            }
            Console.WriteLine("La suma es "+ total);
        }
    }
}