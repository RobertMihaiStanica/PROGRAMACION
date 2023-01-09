using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePokemon
{
    internal class Pokemon //We are basing this on gen 1 pokemons (stats found here https://pokemondb.net/pokedex/stats/gen1)
    {
        string name;
        string species;
        double catchRate;
        int health;
        int maxhealth;
        int attack;
        int defense;
        int speed;

        public Pokemon(string species, int maxhealth, int attack, int defense, int speed, double catchRate)
        {
            name = species;
            this.species = species;
            health = maxhealth;
            this.maxhealth = maxhealth;
            this.attack = attack;
            this.defense = defense;
            this.speed = speed;
            this.catchRate = catchRate;
        }

        public Pokemon(Pokemon pokemon)
        {
            this.name = pokemon.name;
            this.species = pokemon.species;
            this.health = pokemon.health;
            this.maxhealth = pokemon.maxhealth;
            this.attack = pokemon.attack;
            this.defense = pokemon.defense;
            this.speed = pokemon.speed;
        }

        public void SetName(string name)
        {
            this.name = name;
        }

        public string GetName()
        {
            return name;
        }

        public int GetHealth()
        {
            return health;
        }

        public void SetHealth(int health)
        {
            this.health = health;
        }
    }
}
