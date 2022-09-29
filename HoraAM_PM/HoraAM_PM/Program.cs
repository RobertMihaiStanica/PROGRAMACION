internal class Program
{
    private static void Main(string[] args)
    {
        //We are declaring the variable and giving it a blank value for the code to work properly

        int hour = -1;

        //This line asks the user for the hour they want to convert

        Console.WriteLine("Introduce la hora en formato 24h: ");

        /*This try will catch an exception if the user doesn´t input a number
         The "do" function will create a loop that asks the user to type the number again*/

        do
        {
            try
            {
                hour = Convert.ToInt32(Console.ReadLine());

                if (hour < 0 ^ hour > 24)
                {
                    Console.WriteLine("El valor introducido no corresponde a una hora, intentalo de nuevo: ");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: no se ha introducido un caracter valido, intentalo de nuevo: ");
            }
        } while (hour <= -1 ^ hour > 24);

        //Here we do the conversion

        
        if (hour > 12)
        {
            hour = hour - 12;
            Console.WriteLine("Son las " + hour + "PM");
        }
        else
        {
            Console.WriteLine("Son las " + hour + "AM");
        }
    }
}