using System;

namespace PrecioIVA
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Introuce precio a calcular su 16% de IVA: ");

            double price = Convert.ToDouble(Console.ReadLine());

            double iva = price * 16 / 100;

            Console.WriteLine("Su IVA tiene un valor de " + iva);

            double priceIVA = price + iva;

            Console.WriteLine("Su precio con IVA es de " + priceIVA);

        }
    }
}