using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePokemon
{
    internal class Game
    {
        string name;
        string sex;
        int maxPokemons;    //The maximum number of pokemons the player may carry with him (by default 3)
        Pokemon[] pokemonSpecies; //The different pokemon species
        Pokemon[] currentPokemons; //The pokemons the player has
        Random random; //We declare random here so we can use it anywhere without the need to declare it again
        IO io; //The IO class will let us use any of its methods anywhere for the input and output of the program
        

        public Game() //The constructor will act as an introuction where we will give the game the basic information about our player
        {
            random = new Random();
            maxPokemons = 3;
            currentPokemons = new Pokemon[maxPokemons];
            PokemonSpeciesList();
            io = new IO();
            StartingScreen();
        }

        public void Run() //Here we will run the game itself (menus, combat, healing, etc)
        {
            MainMenu();
        }
        
        private void PokemonSpeciesList() //Here we will save all the pokemon species for when we need to create a new pokemon of the same species
        {
            Pokemon bulbasur = new Pokemon("Bulbasur", 45, 49, 49, 65, 45);
            Pokemon charmander = new Pokemon("Charmander", 39, 52, 43, 65, 45);
            Pokemon squirtle = new Pokemon("Squirtle", 44, 48, 65, 43, 45);
            Pokemon pidgey = new Pokemon("Pidgey", 40, 45, 40, 56, 255);
            Pokemon rattata = new Pokemon("Rattata", 30, 56, 35, 72, 255);
            pokemonSpecies = new Pokemon[] {bulbasur, charmander, squirtle, pidgey, rattata};
        }

        private Pokemon StarterPokemon(string name) //This will run throught all the pokemons in our game and return the one we´ve chosen from the starter list
        {
            Pokemon pokemon = null;
            for (int pcounter = 0; pcounter < pokemonSpecies.Length; ++pcounter)
            {
                if (name == pokemonSpecies[pcounter].GetName())
                {
                    pokemon = pokemonSpecies[pcounter];
                }
            }
            return pokemon;
        }

        private void NamePokemon(Pokemon pokemon) //We will use this to name new pokemons
        {
            string[] yesNoMenu = { "Yes", "No" };
            string answer = io.PrintSelectableMenu("Would you like to give your new " + pokemon.GetName() + " a new nickname?", yesNoMenu);
            if (answer == yesNoMenu[0])
            {
                do
                {
                    io.PrintMessageSlow("What name would you like to give to " + pokemon.GetName() + "?\n ");
                    pokemon.SetName(io.AskForString());
                    answer = io.PrintSelectableMenu("Before we continue, are you sure about your choice?", yesNoMenu);
                } while (answer != yesNoMenu[0]);
                io.PrintMessageSlow("Your pokemons nickname has changed to " + pokemon.GetName() + "!\n ");
            }
        }

        private void StartingScreen() //This will show the starting screen of the game
        {
            string answer;
            string[] sexMenu = { "Boy", "Girl" };
            string[] yesNoMenu = { "Yes", "No" };
            string[] starterPokemonMenu = { pokemonSpecies[0].GetName(), pokemonSpecies[1].GetName(), pokemonSpecies[2].GetName() };
            io.PrintMessageSlow("Welcome to the amazing world of pokemon! ");
            do //We will loop this in case the player wants to change something before proceed
            {
                sex = io.PrintSelectableMenu("Are you a boy or a girl?", sexMenu);
                io.PrintMessageSlow("So you are a " + sex + "! ");
                io.PrintMessageSlow("What´s your name?\n");
                name = io.AskForString();
                io.PrintMessageSlow("Nice to meet you " + name + "! ");
                answer = io.PrintSelectableMenu("Chose your starter Pokemon!", starterPokemonMenu);
                currentPokemons[0] = StarterPokemon(answer);
                io.PrintMessageSlow("Wow! Your first pokemon is a " + currentPokemons[0].GetName() + "! ") ;
                NamePokemon(currentPokemons[0]);
                answer = io.PrintSelectableMenu("Before we continue, are you sure about your choices?", yesNoMenu);
            } while (answer != yesNoMenu[0]);
        }

        private void MainMenu() //This will print the main menu of the game
        {
            string[] mainMenu = { "Combat", "See Team Stats", "Pokemon Center", "Close Game", };
            string choice = io.PrintSelectableMenu("Main Menu", mainMenu);
            if (choice == mainMenu[0]) //Initialize combat
            {
                StartCombat(pokemonSpecies[random.Next(pokemonSpecies.Length)]);
            }
        }

        private void StartCombat(Pokemon enemy) //This will display the combat menu
        {
            io.PrintMessageSlow("You´ve found a  " + enemy.GetName() + "!\n");
            io.PrintMessageSlow("Prepare for combat!\n");
            Pokemon chosenPokemon = io.ChoosePokemon(currentPokemons, "Choose your pokemon!");
            string[] combatMenu = { "Attack", "Capture", "Change Pokemom", "Retreat" };
        }
    }
}
