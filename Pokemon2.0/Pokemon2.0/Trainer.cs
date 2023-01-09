using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon2
{
    internal class Trainer
    {
        string name;
        string gender; //Boy, Girl
        long trainerID;
        DateTime trainerCreationDate;
        Pokemon[] currentPokemons; //The pokemons the player has
        //Currencies:
        int pokedollars;
        int pokeseeds;
        int battlePoints;

        public Trainer(string name, string gender)
        {
            this.name = name;
            this.gender = gender;
            trainerID = GenerateTrainerID();
            trainerCreationDate = DateTime.Now;
            currentPokemons = new Pokemon[6];
            pokedollars = 0;
            pokeseeds = 0;
            battlePoints = 0;
        }

        public string GetName()
        {
            return name;
        }

        public DateTime GetCreationDate()
        {
            return trainerCreationDate;
        }

        public long GetTrainerID()
        {
            return trainerID;
        }

        public Pokemon[] GetPokemons()
        {
            return currentPokemons;
        }

        private long GenerateTrainerID()
        {
            Random random = new Random();
            string id = Convert.ToString(random.Next(100000000,1000000000));
            id = id + 1;
            long trainerID = Convert.ToInt64(id);
            return trainerID;
        }

        public void CapturePokemon(Pokemon capturedPokemon) //I should pass this to the Game class, right now its working fine so i'll let it be
        {
            IO io = new IO();

            for (int position = 0; position < currentPokemons.Length; ++position)
            {
                if (currentPokemons[position] == null)
                {
                    currentPokemons[position] = capturedPokemon;
                    break;
                }
                if (position == currentPokemons.Length - 1)
                {
                    io.PrintMessage("You don´t have any free pokemon slots!");
                }
            }
        }
    }
}
