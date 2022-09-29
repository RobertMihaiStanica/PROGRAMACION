internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Introduce el numero de kilometros recorrido: ");

        //We have to give km a blank value for the code to work

        int km = 0;

        //This will exit the program if the user writes anything exept a number

        try
        {
            km = Convert.ToInt32(Console.ReadLine());
        }
        catch (FormatException)
        {
            Console.WriteLine("Error, no se ha introducido un caracter valido");
            return;
        }

        int price = 100;

        //Here we start calculating the cost based on the value of km

        if (km <= 0)
        {
            Console.WriteLine("No se ha introducido ningun valor calculable");
        }
        else if (km <= 300)
        {
            Console.WriteLine("Su precio es de " + price + " euros");
        }
        else if (km > 300 & km <= 1000)
        {
            price = price + (km - 300) * 10;

            Console.WriteLine("Su precio es de " + price + " euros");
        }
        else if (km > 1000)
        {
            price = price + 700 * 10;

            price = price + (km - 1000) * 5;

            Console.WriteLine("Su precio es de " + price + " euros");
        }
    }
}