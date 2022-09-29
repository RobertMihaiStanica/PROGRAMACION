//Here we declare our variables

int hour;

//This line asks the user for the hour they want to convert

Console.WriteLine("Introduce la hora en formato 24h: ");

//This try will catch an exception if the user doesn´t input a number

try
{
    hour = Convert.ToInt32(Console.ReadLine());
}
catch (FormatException)
{
    Console.WriteLine("Error: no se ha introducido un caracter valido");
    return;
}

//Here we do the conversion

if (hour > 24 ^ hour < 0)
{
    Console.WriteLine("El numero intorducido no corresponde a un hora valida");
}
else if (hour > 12)
{
    hour = hour - 12;
    Console.WriteLine("Son las " + hour + "PM");
}
else
{
    Console.WriteLine("Son las " + hour + "AM");
}