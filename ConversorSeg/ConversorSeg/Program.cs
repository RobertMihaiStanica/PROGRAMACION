using System;

namespace ConversorSeg
{
    class Program
    {
        static void Main(string[] args)
        {
            int sec;

            int min;

            int hours;

            Console.WriteLine("Introduce segundos a convertir:");

            sec = Convert.ToInt32(Console.ReadLine());

            min = sec / 60;

            sec = sec % 60;

            hours = min / 60;

            min = min % 60;

            Console.WriteLine("Los segundos equivalen a " + hours + ":" + min + ":" + sec);

        }
    }
}