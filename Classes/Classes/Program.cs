using System;
using System.Transactions;
using System.Xml;

namespace Classes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Polynomial pol1 = new Polynomial(2, 3, 2);
            Console.WriteLine(pol1.Value(2));
            Console.WriteLine(pol1.Write());
        }
        class Rational
        {
            double numerator;
            double denominator;

            public Rational()
            {
                numerator = 0;
                denominator = 1;
            }

            public Rational(double newNum, double newDenom)
            {
                numerator = newNum;
                denominator = newDenom;
            }
        }
        class Circle
        {
            double x;
            double y;
            double radius;

            public Circle(double newX, double newY, double newRadius)
            {
                x = newX;
                y = newY;
                radius = newRadius;
            }

            public Circle(double newRadius)
            {
                x = 0;
                y = 0;
                radius = newRadius;
            }
            public Circle()
            {
                x = 0;
                y = 0;
                radius = 0;
            }
            public double CalcArea()
            {
                double pi = 3.14;
                return pi * (radius * radius);
            }
            public double CalcLenght()
            {
                double pi = 3.14;
                return 2 * pi * radius;
            }
            public void PrintCirData()
            {
                Console.WriteLine("X es igual a " + x);
                Console.WriteLine("Y es igual a " + y);
                Console.WriteLine("El radio es igual a " + radius);
            }
        }
    }
    class Polynomial
    {
        int firstNum;
        int secondNum;
        int thirdNum;
        int x;

        public Polynomial(int firstNum, int secondNum, int thirdNum)
        {
            this.firstNum = firstNum;
            this.secondNum = secondNum;
            this.thirdNum = thirdNum;
        }
        public int CalcPoly()
        {
            int result = firstNum * (x * x) + secondNum * x + thirdNum;
            return result;
        }
        public int Value(int x)
        {
            this.x = x;
            return CalcPoly();
        }

        public string Write()
        {
            string poly = firstNum + "*" + x + "^2" + "+" + secondNum + "*" + x + "+" + thirdNum + "=" + CalcPoly();
            return poly;
        }
    }
}