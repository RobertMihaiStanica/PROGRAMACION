namespace ADN
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person();

            Person person2 = new Person("Pablo", "Picaso");

            Console.WriteLine(person.GetDNA());

            Console.WriteLine(person2.GetDNA());

            Console.WriteLine(person.DNACompatibility(person2) + " match percentage");
        }
    }
}