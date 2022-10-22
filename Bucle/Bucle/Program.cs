using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bucles
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("1) Ejercicio 1 (contar hasta un numero determinado)");
            Console.WriteLine("2) Ejercicio 2 (Contar desde)");
            Console.WriteLine("3) Ejercicio 3");
            Console.WriteLine("4) Ejercicio 4");
            Console.WriteLine("5) Ejercicio 5");
            Console.WriteLine("Elige el ejercicio que deseas ejecutar:");

            int option = Convert.ToInt32(Console.ReadLine());

            if (option == 1)
            {
                Exercise1();
            }
            if (option == 2)
            {
                Exercise2();
            }
            if (option == 3)
            {
                Exercise3();
            }
            if (option == 4)
            {
                Exercise4();
            }
            if (option == 5)
            {
                Exercise5();
            }
        }
        static void Exercise1()
        {
            int counter = 1;
            Console.WriteLine("Introduce el numero hasta el que quieras contar: ");
            int number = Convert.ToInt32(Console.ReadLine());

            while (counter <= number)
            {
                Console.WriteLine(counter);
                counter++;
            }
            Console.WriteLine("FIN");
        }


        static void Exercise2()
        {
            int counter = 320;

            while (counter >= 160 && counter <= 320)
            {
                Console.WriteLine(counter);
                counter--;
            }
            Console.WriteLine("FIN");
        }

        static void Exercise3()
        {
            int add = 0;
            int number = 0;
            while (number >= 0)
            {
                Console.WriteLine("Introduce un numero: ");
                add = number + add;
                number = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("La suma de sus numeros es " + add);
        }
        static void Exercise4()
        {
            int mult = 1;
            int number = 1;
            while (number != 0)
            {
                mult = mult * number;
                Console.WriteLine("Introduce un numero: ");
                number = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("La multiplicacion de sus numeros es " + mult);
        }
        static void Exercise5()
        {
            int add = 0;
            int number = 0;
            while (number >= 0)
            {
                if (number % 2 == 0)
                {
                    add = number + add;
                }
                Console.WriteLine("Introduce un numero: ");
                number = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("La suma de sus numeros es " + add);
        }
    }
}