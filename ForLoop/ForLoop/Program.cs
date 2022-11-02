using System;
using System.Diagnostics.Metrics;
using System.Security.Claims;

namespace ForLoop;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine(DivideTimesNum(1));
    }
    static void Exercise1()
    {
        Console.WriteLine("Dame el numero hasta el que quieras crear la piramide comprendido entre el 3 y el 10:");
        int num = Convert.ToInt32(Console.ReadLine());
        FloydTriangle(num);
    }
    static void FloydTriangle(int num)
    {
        if ( num <= 10 && num >= 3)
        {
            string chain = "";      
            for ( int counter = 1; counter <= num; counter = counter + 1)
            {
                chain = chain + counter;
                Console.WriteLine(chain);
            }
        }
        else
        {
            Console.WriteLine("El numero no entra en los parametros determinados");
        }
    }

    static void NumTimesNum(int countTo)
    {
        string chain = "";
        for (int counter = 1; counter < countTo; counter = counter + 1) //El numero que vamos ea repetir
        {
            for (int count = 0; count < counter; count = count +1) //El numero de veces que se va a repetir
            {
                chain = chain + counter;
            }
        }
        Console.WriteLine(chain);

        /*int count = 0;
        string chain = "";
        for ( int num = countTo; count < countTo; count++)
        {
            chain = chain + num;
        }
        Console.WriteLine(chain);*/
    }

    static void NumChar(int num1, int num2)
    {
        for (int counter = num1; counter <= num2; counter = counter + 1)
        {
            Console.WriteLine(counter);
        }

    }

    static void PrintFrase(int num, string phrase)
    {
        for (int counter = 0; counter < num; counter = counter + 1)
        {
            Console.WriteLine(phrase);
        }
    }

    static void AnyFloydTriangle(int num)
    {
        string chain = "";
        for (int counter = 1; counter <= num; counter = counter + 1)
        {
            chain = chain + counter;
            Console.WriteLine(chain);
        }
    }
    static double DivideTimesNum(int num)
    {
        const double FIXEDNUM = 1;
        double result = 0;

        for ( double counter = 1; counter <= num; counter = counter + 1)
        {
            result = result + FIXEDNUM/counter;
        }
        return result;
    }
}