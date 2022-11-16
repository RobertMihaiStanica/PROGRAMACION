using System;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Runtime.Intrinsics.X86;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Exercise6();
        }

        static void Exercise1()
        {
            int[] numbers = new int[10];

            for (int counter = 0; counter < numbers.Length; ++counter)
            {
                Console.WriteLine("Give me a number");
                numbers[counter] = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("There are " + (numbers.Length - (counter + 1)) + " numbers left");
            }

            Console.WriteLine("Let´s print the numbers");

            for (int counter = numbers.Length - 1; counter >= 0; --counter)
            {
                Console.WriteLine(numbers[counter]);
            }
        }

        static void Exercise2()
        {
            Random random = new Random();
            int[] numbers = new int[15];
            for (int counter = 0; counter < numbers.Length; ++counter)
            {
                int rand = random.Next(numbers.Length);
                numbers[counter] = rand;
            }
            Console.WriteLine(MaxArrayNumber(numbers));
            Console.WriteLine(MinArrayNumber(numbers));
        }

        static void Exercise3()
        {
            Random random = new Random();
            int[] numbers = new int[20];
            int[] numbers2 = new int[20];
            for (int counter = 0; counter < numbers.Length; ++counter)
            {
                int rand = random.Next(numbers.Length);
                numbers[counter] = rand;
            }

            for (int counter = 0; counter < numbers.Length; ++counter)
            {
                if (counter == numbers.Length - 1)
                {
                    numbers2[0] = numbers[counter];
                }
                else
                {
                    numbers2[counter + 1] = numbers[counter];
                }
            }

            Console.WriteLine(PrintNumArray(numbers));

            numbers = numbers2;

            Console.WriteLine(PrintNumArray(numbers));
        }

        static int[] OrderArray(int[] numbers)
        {
            for (int counter = 0; counter < numbers.Length; ++counter)
            {
                for (int counter2 = 0; counter2 < numbers.Length; ++counter2)
                {
                    if (numbers[counter] < numbers[counter2])
                    {
                        int maxnum = numbers[counter];
                        int minnum = numbers[counter2];
                        numbers[counter] = minnum;
                        numbers[counter2] = maxnum;
                    }
                }
            }
            return numbers;
        }

        static void Exercise6()
        {

            int[] temperatures = GenerateArray();

            string graph = "";

            string lastline = "MO";

            string firstline = "TEMP";

            for (int counter4 = 0; counter4 < temperatures.Length; ++counter4) //upper line print
            {
                firstline = firstline + "____";
            }
            Console.WriteLine(firstline);

            for (int counter = MaxArrayNumber(temperatures); counter >= MinArrayNumber(temperatures); --counter) //creates a line for each possible temperature
            {
                string line = "";

                ConsoleColor color = ConsoleColor.Red;

                if (counter >= 0 && counter <= 9) //here we decide if the number is made of a single digit or 2 (negative numbers count as double digits)
                {
                    line = counter + "___";
                }
                else
                {
                    line = counter + "__";
                }

                for (int counter2 = 0; counter2 < temperatures.Length; ++counter2) //decides if you have to put a level on the graph or not
                {
                    if (temperatures[counter2] >= counter) //If the temperatura is higher than the line we are in
                    {
                        line = line + "II" + "__"; //This will draw a sybol + the space to the next one
                    }
                    else
                    {
                        line = line + "____"; //this will draw a blank space
                    }
                }

                line = line + "\n";

                if (counter <= 0)
                {
                    color = ConsoleColor.DarkBlue;
                }
                else if (counter > 0 && counter <= 10)
                {
                    color = ConsoleColor.Blue;
                }
                else if (counter <= 25)
                {
                    color = ConsoleColor.Yellow;
                }
                else if (counter > 25 && counter <= 35)
                {
                    color = ConsoleColor.DarkYellow;
                }
                else if (counter > 35)
                {
                    color = ConsoleColor.DarkRed;
                }
                else
                {
                    color = ConsoleColor.White;
                }

                foreach (char block in line)
                {
                    if (block == 'I')
                    {
                        Console.BackgroundColor = color;
                        Console.ForegroundColor = color;
                        Console.Write(block);
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(block);
                    }
                }

            }
                for (int counter3 = 0; counter3 < temperatures.Length; ++counter3) //Last line print, based on how many array items there are
                {
                    if (counter3 >= 0 && counter3 < 9)
                    {
                        lastline = lastline + "   " + (counter3 + 1);
                    }
                    else
                    {
                        lastline = lastline + "  " + (counter3 + 1);
                    }
                }

                Console.WriteLine(lastline);

        }

        static int[] GenerateArray()
        {
            Console.WriteLine("Array length:");
            int length = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Min array number:");
            int min = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Max array number:");
            int max = Convert.ToInt32(Console.ReadLine()) + 1;

            Random random = new Random();

            int[] numbers = new int[length];

            for (int counter = 0; counter < length; ++counter)
            {
                numbers[counter] = random.Next(min, max);
            }

            return numbers;
        }

        static int MaxArrayNumber(int[] array)
        {
            int maxnum = array[0];

            for (int counter = 0; counter < array.Length; ++counter)
            {
                if (array[counter] > maxnum)
                {
                    maxnum = array[counter];
                }
            }
            return maxnum;
        }

        static int MinArrayNumber(int[] array)
        {
            int minnum = array[0];

            for (int counter = 0; counter < array.Length; ++counter)
            {
                if (array[counter] < minnum)
                {
                    minnum = array[counter];
                }
            }
            return minnum;
        }

        static string PrintNumArray(int[] array)
        {
            string arraynumbers = "";

            for (int counter = 0; counter < array.Length; ++counter)
            {
                arraynumbers = arraynumbers + " " + array[counter];
            }

            return arraynumbers;
        }
    }
}