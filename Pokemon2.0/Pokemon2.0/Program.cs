using System;

namespace Pokemon2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IO io = new IO();

            Game game = new Game(io, "Robert", "Boy");

            game.Run();
        }
    }
}