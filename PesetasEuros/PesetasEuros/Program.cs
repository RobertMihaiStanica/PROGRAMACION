using System;

namespace PesetasAEuros
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Escribe el numero de pesetas a convertir: ");

            double pesetas = Convert.ToDouble(Console.ReadLine());

            double euros = pesetas / 166.386;

            Console.WriteLine("Sus pesetas tienen un valor de " + Math.Round(euros, 2) + " euros");

        }
    }
}