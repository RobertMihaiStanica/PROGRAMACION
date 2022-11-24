using System.Drawing;

namespace ConsolePokemon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] menu = {"NUEVA PARTIDA", "COMBATE", "OPCIONES", "SALIR"};
            MenuNavigation(menu);

        }

        static void PrintArrayMenu(string[] menu, int position)
        {   
            for (int i = 0; i < menu.Length; ++i)
            {
                if (i == position - 1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine(menu[i]);
            }
        }

        static void MenuNavigation(string[] menu)
        {
            int position = 0;
            PrintArrayMenu(menu, position);
            ConsoleKeyInfo input;
            do {
                input = Console.ReadKey();

                Console.Clear();

                int startingPossition = position;

                if (input.Key == ConsoleKey.UpArrow)
                {
                    position -= 1;
                }
                else if (input.Key == ConsoleKey.DownArrow)
                {
                    position += 1;
                }
                PrintArrayMenu(menu, position);

            } while (input.Key != ConsoleKey.Enter);
        }
    }
}