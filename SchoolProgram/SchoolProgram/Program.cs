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

            Student student1 = new Student(maths, english, history, 1300, "George Bush");
            Teacher teacher1 = new Teacher("LP1R77", "Gustavo Fring", "Math");

            teacher1.ScoreAsign(student1);

            Console.WriteLine(student1.GetSubject(1));
        }
        class Subject
        {
            int id;
            public float score;

            public Subject(int id)
            {
                this.id = id;
                score = 0;
            }
            public int GetId()
            {
                return id;
            }
            public float GetScore()
            {
                return score;
            }
            public void SetScore(float score)
            {
                this.score = score;
            }
        }
        class Student
        {
            public Subject subject1;
            public Subject subject2;
            public Subject subject3;
            int tuitionNumber;
            string name;

            public Student(Subject subject1, Subject subject2, Subject subject3, int tuitionNumber, string name)
            {
                this.subject1 = subject1;
                this.subject2 = subject2;
                this.subject3 = subject3;
                this.tuitionNumber = tuitionNumber;
                this.name = name;
            }

            public string GetSubject(int subject)
            {
                string info;
                if (subject == 1)
                {
                    info = "id:" + Convert.ToString(subject1.GetId()) + "\n" + "score:" + Convert.ToString(subject1.GetScore());
                    return info;
                }
                if (subject == 2)
                {
                    info = "id:" + Convert.ToString(subject2.GetId()) + "\n" + "score:" + Convert.ToString(subject2.GetScore());
                    return info;
                }
                if (subject == 3)
                {
                    info = "id:" + Convert.ToString(subject3.GetId()) + "\n" + "score:" + Convert.ToString(subject3.GetScore());
                    return info;
                }
                else
                {
                    return "No subject selected";
                }
            }
        }
        class Teacher
        {
            string nif;
            string name;
            string specialty;
            public Teacher(string nif, string name, string specialty)
            {
                this.nif = nif;
                this.name = name;
                this.specialty = specialty;
            }
            public void ScoreAsign(Student student)
            {
                Random ran1 = new Random();
                Random ran2 = new Random();
                Random ran3 = new Random();
                student.subject1.score = ran1.Next(0, 10);
                student.subject2.score = ran2.Next(0, 10);
                student.subject3.score = ran3.Next(0, 10);
            }
            public double AverageScore(Student student)
            {
                return (student.subject1.score + student.subject2.score + student.subject3.score) / 3;
            }
        }
    }
}