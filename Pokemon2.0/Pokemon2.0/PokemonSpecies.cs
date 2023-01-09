using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon2
{
    internal class PokemonSpecies
    {
        int speciesNumber;
        string speciesName;
        int catchRate;
        double maleChance;
        //Base stats
        int defense;
        int attack;
        int speed;
        int health;

        public PokemonSpecies(int speciesNumber, string speciesName, int catchRate, double maleChance, int defense, int attack, int speed, int health)
        {
            this.speciesNumber = speciesNumber;
            this.speciesName = speciesName;
            this.catchRate = catchRate;
            this.maleChance = maleChance;
            this.defense = defense;
            this.attack = attack;
            this.speed = speed;
            this.health = health;
        }

        public int GetHealth()
        {
            return health;
        }

        public string GetSpeciesName()
        {
            return speciesName;
        }

        public double GetMaleChance()
        {
            return maleChance;
        }

        public int GetSpeed()
        {
            return speed;
        }

        public int GetAttack()
        {
            return attack;
        }

        public int GetDefense()
        {
            return defense;
        }

        public int GetCatchrate()
        {
            return catchRate;
        }
    }
}
