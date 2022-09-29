using System;

namespace CalculoDiametro
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Escribe el numero de centimetros del diametro: ");

            double diametro = Convert.ToDouble(Console.ReadLine());

            double area = Math.Pow(diametro/2 ,2) * 3.14;

            Console.WriteLine("El area de su circulo es de " + area + " centimetros cuadrados");

        }
    }
}