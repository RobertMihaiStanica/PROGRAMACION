Console.WriteLine("Introduce la hora en formato 24h: ");

int hour = Convert.ToInt32(Console.ReadLine());

if (hour > 12)
{
    hour = hour - 12;
    Console.WriteLine("Son las " + hour + "PM");
}
else
{
    Console.WriteLine("Son las " + hour + "AM");
}