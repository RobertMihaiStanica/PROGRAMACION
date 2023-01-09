using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePokemon
{
    class IO //IO doesn´t need a constructor as we will use it to for the input/output methods
    {
        public void PrintMessageSlow(string message) //We use this method to slowly print messages
        {
            for (int position = 0; position < message.Length; position++)
            {
                Console.Write(message[position]);
                Thread.Sleep(30); //This decides how slow we want to print the message (The bigger the number the slower it will go)
            }
        }

        public void PrintMessage(string message) //We use this method to print strings
        {
            Console.WriteLine(message);
        }

        public string AskForString() //We use this method to asing values to strings
        {
            string value = Console.ReadLine();
            return value;
        }

        public string PrintSelectableMenu(string menuTitle, string[] menu) //We use this method to print menus with multiple choices and return the selected choice as a string
        {
            ConsoleKeyInfo key;
            int position = 0;
            
            do //This will loop the menu until we select an option
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                PrintMessage(menuTitle);
                Console.ForegroundColor = ConsoleColor.White;
                for (int counter = 0; counter < menu.Length; ++counter) //Using a "for" we can print any menu no matter how many elements it has
                {
                    if (counter == position) //This prints the text green on the current selection
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    Console.WriteLine(menu[counter]);
                }
                Console.ForegroundColor = ConsoleColor.White;
                key = Console.ReadKey();
                Console.Clear();
                switch (key.Key) //This controlls the navigation
                {
                    case ConsoleKey.UpArrow:
                        --position;
                        break;
                    case ConsoleKey.DownArrow:
                        ++position;
                        break;
                }
                if (position >= menu.Length) //Here we avoid going out of the menu bounds
                {
                    position = menu.Length - 1;
                }
                if (position < 0)
                {
                    position = 0;
                }
                if (menu[position] == null)
                {
                    position = position - 1;
                }
            } while (key.Key != ConsoleKey.Enter); //Pressing the enter key will end the loop
            return menu[position]; //Ending the loop will return the value of the last possition
        }

        public string PrintCombatScreen(Pokemon playerPokemon, Pokemon enemyPokemon, string[] menu) //Here we will print the interface for the combats
        {
            ConsoleKeyInfo key;
            int position = 0;

            do //We reuse the PrintSelectableMenu code to deliver a combat menu showing pokemon health
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                PrintMessage(Convert.ToString(playerPokemon.GetHealth + "\n")); 
                Console.ForegroundColor = ConsoleColor.Red;
                PrintMessage(Convert.ToString(enemyPokemon.GetHealth + "\n"));
                Console.ForegroundColor = ConsoleColor.White;
                PrintMessage("\n");

                for (int counter = 0; counter < menu.Length; ++counter) //Using a "for" we can print any menu no matter how many elements it has
                {
                    if (counter == position) //This prints the text green on the current selection
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    Console.WriteLine(menu[counter]);
                }
                Console.ForegroundColor = ConsoleColor.White;
                key = Console.ReadKey();
                Console.Clear();
                switch (key.Key) //This controlls the navigation
                {
                    case ConsoleKey.UpArrow:
                        --position;
                        break;
                    case ConsoleKey.DownArrow:
                        ++position;
                        break;
                }
                if (position >= menu.Length) //Here we avoid going out of the menu bounds
                {
                    position = menu.Length - 1;
                }
                if (position < 0)
                {
                    position = 0;
                }

            } while (key.Key != ConsoleKey.Enter); //Pressing the enter key will end the loop
            return menu[position]; //Ending the loop will return the value of the last possition);
        }

        public Pokemon ChoosePokemon(Pokemon[] pokemons, string menutitle) //This will show us a menu to select our current pokemon that we are going to use in combat
        {
            string[] menu = new string[pokemons.Length];
            for (int pokemon = 0; pokemon < pokemons.Length; ++pokemon) //We will create a menu with all the names of the pokemons to chose from
            {
                if (pokemons[pokemon] != null) //We only want to add the non null values to the menu list
                {
                    menu[pokemon] = pokemons[pokemon].GetName();
                }
            }
            string chosen = PrintSelectableMenu(menutitle, menu); //Here we will print the menu and return the pokemon we want to use
            Pokemon chosenPokemon = null;
            for (int pokemon = 0; pokemon < pokemons.Length; ++pokemon) //This will look for the chosen pokemon based on name and return the correct one
            {
                if (chosen == pokemons[pokemon].GetName())
                {
                    chosenPokemon = pokemons[pokemon];
                    break;
                }
            }
            return chosenPokemon;
        }
    }
}
