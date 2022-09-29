using System.Linq.Expressions;

Console.WriteLine("Escribe el primer numero:");

double num1 = Convert.ToDouble(Console.ReadLine());

Console.WriteLine("Escribe el segundo numero");

double num2 = Convert.ToDouble(Console.ReadLine());

if (num1 == num2)
{
    Console.WriteLine("Los numeros son iguales");
}
else if (num1 > num2 )
{
    Console.WriteLine(num1 + " es mayor que " + num2);
}
else
{
    Console.WriteLine(num2 + " es mayor que " + num1);
}