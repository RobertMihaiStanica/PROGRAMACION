using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (int counter = 1; counter <= 10; counter = counter + 1)
            {
                Console.WriteLine(counter);
            }
        }
    }
}