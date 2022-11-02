using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    class Person
    {
        string name;
        int age;
        //string nif;
        //char gender; // F, M

        public void PrintName()
        {
            Console.WriteLine("El nombre de esta persona es " + name);
        }
        public Person(string newName, int newAge)
        {
            name = newName;
            age = newAge;
        }
        public void SetName(string newName)
        {
            name = newName;
        }

        public string GetName()
        {
            return name;
        }

        public void SetAge(int newAge)
        {
            age = newAge;
        }

        public int GetAge()
        {
            return age;
        }

        public void Birthday()
        {
            age = age + 1;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Probando");

            Person p1;
            p1 = new Person("Pedro", 16);
            p1.SetAge(5);
            Console.WriteLine("La edad de " + p1.GetName + "es " + p1.GetAge());
        }
    }
}