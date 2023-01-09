using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon2
{
    internal class IO
    {
        public void PrintMessage(string message) //This will slowly print a message on screen
        {
            for (int counter = 0; counter < message.Length; ++counter)
            {
                Console.Write(message[counter]);
                Thread.Sleep(30);
            }
        }

        public string AskForString(string message) //Here we will ask the player to write a string that we can later save on a variable
        {
            string answer;
            Console.ForegroundColor = ConsoleColor.Blue;
            PrintMessage(message);
            Console.ForegroundColor = ConsoleColor.White;
            answer = Console.ReadLine();
            return answer;
        }

        public int SelectableMenu(string[] choices, string menuTitle) //This will print a selectable menu with key navigation (up, and down, enter for selection an option)
        {
            int currentPosition = 0;
            ConsoleKeyInfo key;

            do
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(menuTitle); //Here we print the menu title
                Console.ForegroundColor = ConsoleColor.White;

                for (int position = 0; position < choices.Length; ++position)
                {
                    if (position == currentPosition)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    Console.WriteLine(choices[position]);
                }

                key = Console.ReadKey();

                if (key.Key == ConsoleKey.UpArrow)
                {
                    --currentPosition;
                }
                if (key.Key == ConsoleKey.DownArrow)
                {
                    ++currentPosition;
                }

                if (currentPosition >= choices.Length)
                {
                    currentPosition = choices.Length - 1;
                }
                if (currentPosition < 0)
                {
                    currentPosition = 0;
                }

                Console.Clear();

            } while (key.Key != ConsoleKey.Enter);

            Console.ForegroundColor = ConsoleColor.White;
            return currentPosition;
        }

        public string[] SpeciesArrayToString(PokemonSpecies[] starterPokemons) //We use this for the starter pokemon menu (maybe it could also be used for a spawn menu)
        {
            string[] pokemons = new string[starterPokemons.Length];

            for (int position = 0; position < pokemons.Length; ++position)
            {
                string name = starterPokemons[position].GetSpeciesName();
                pokemons[position] = name;
            }

            return pokemons;
        }

        public string[] PokemonArrayToString(Pokemon[] pokemons) //We will use this to make a string[] to use it on a selectable pokemon menu
        {
            int pokemonCounter = 0; //We will use the counter to create a string[] without the null positions

            for (int position = 0; position < pokemons.Length; ++position)
            {
               if (pokemons[position] != null)
                {
                    ++pokemonCounter;
                } 
            }

            string[] pokemonNames = new string[pokemonCounter];

            for (int position = 0; position < pokemons.Length; ++position)
            {
                if (pokemons[position] != null)
                {
                    pokemonNames[position] = pokemons[position].GetName();
                }
            }

            return pokemonNames;
        }

        public void PrintCombatHealt(Pokemon playerPokemon, Pokemon enemyPokemon) //This will print the health of the player pokemon and enemy pokemon
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Your " + playerPokemon.GetName());
            Console.WriteLine(playerPokemon.GetHealth() + "HP");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Wild " + enemyPokemon.GetName());
            Console.WriteLine(enemyPokemon.GetHealth() +"HP");
        }

        public int SelectableCombatMenu(string[] choices, string menuTitle, Pokemon playerPokemon, Pokemon enemyPokemon) //This will print a selectable menu with key navigation (up, and down, enter for selection an option)
        {
            int currentPosition = 0;
            ConsoleKeyInfo key;

            do
            {
                PrintCombatHealt(playerPokemon, enemyPokemon);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(menuTitle); //Here we print the menu title
                Console.ForegroundColor = ConsoleColor.White;

                for (int position = 0; position < choices.Length; ++position)
                {
                    if (position == currentPosition)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    Console.WriteLine(choices[position]);
                }

                key = Console.ReadKey();

                if (key.Key == ConsoleKey.UpArrow)
                {
                    --currentPosition;
                }
                if (key.Key == ConsoleKey.DownArrow)
                {
                    ++currentPosition;
                }

                if (currentPosition >= choices.Length)
                {
                    currentPosition = choices.Length - 1;
                }
                if (currentPosition < 0)
                {
                    currentPosition = 0;
                }

                Console.Clear();

            } while (key.Key != ConsoleKey.Enter);

            Console.ForegroundColor = ConsoleColor.White;
            return currentPosition;
        }
    }
}
