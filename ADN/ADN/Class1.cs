using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADN
{
    class Person
    {
        string name;
        string surname;
        char[] chromosomes = new char[20];

        public Person(string name, string surname)
        {
            this.name = name;
            this.surname = surname;
            chromosomes = GenerateDNA(chromosomes);
        }

        public Person()
        {
            name = "Unknown";
            surname = "Unknown";
            chromosomes = GenerateDNA(chromosomes);
        }

        public char[] GenerateDNA(char[] dna)
        {
            for (int counter = 0; counter < dna.Length; counter++)
            {
                Random random = new Random();
                int number = random.Next(4);
                char letter = ' ';

                if (number == 0)
                {
                    letter = 'A';
                }
                if (number == 1)
                {
                    letter = 'C';
                }
                if (number == 2)
                {
                    letter = 'G';
                }
                if (number == 3)
                {
                    letter = 'T';
                }

                dna[counter] = letter;
            }
            return dna;
        }

        public char[] GetDNA()
        {
            return chromosomes;
        }

        public string DNACompatibility(Person person2)
        {
            decimal matches = 0;

            char[] dna1 = chromosomes;

            char[] dna2 = person2.GetDNA();

            for (int counter = 0; counter < dna1.Length; ++counter)
            {
                if (dna1[counter] == dna2[counter])
                {
                    ++matches;
                }
            }

            decimal percentage = matches / dna1.Length * 100;

            return (percentage + "%");
        }
    }
}
