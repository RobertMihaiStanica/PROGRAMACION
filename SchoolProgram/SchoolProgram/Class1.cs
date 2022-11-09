using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProgram
{
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

        public Subject GetSubject(int option)
        {
            if (option == 1)
            {
                return subject1;
            }
            if (option == 2)
            {
               
                return subject2;
            }
            if (option == 3)
            {
                return subject3;
            }
            else
            {
                return null;
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
