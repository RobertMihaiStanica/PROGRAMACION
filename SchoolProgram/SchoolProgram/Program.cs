using System;

namespace SchoolProgram
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Subject maths = new Subject(1);
            Subject english = new Subject(2);
            Subject history = new Subject(3);

            Student student1 = new Student(english, maths, history, 1300, "George Bush");
            Teacher teacher1 = new Teacher("LP1R77", "Gustavo Fring", "Math");

            teacher1.ScoreAsign(student1);

            Console.WriteLine(student1.GetSubject(1));
        }
    }
}