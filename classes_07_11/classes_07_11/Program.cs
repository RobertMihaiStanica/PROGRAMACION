using classes_07_11;
using System;

namespace classes_07
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Account acount = new Account("Fernando");
            //acount.SetQuantity(13000);
            //Console.WriteLine(acount.GetQuantity());
            //acount.Deposit(2000);
            //Console.WriteLine(acount.GetQuantity());
            //acount.SetQuantity(-3000);
            //Console.WriteLine(acount.GetQuantity());
            //acount.Withdraw(17000);
            //Console.WriteLine(acount.GetQuantity());
            //acount.Withdraw(2500);
            //Console.WriteLine(acount.GetQuantity());
            //Console.WriteLine(acount.GetHolder());

            Password password = new Password();

            password.SetLenght(10);

            password.GenPass();

            Console.WriteLine(password.GetPassword());

            Console.WriteLine(password.IsPassStrong());
        }
    }
}