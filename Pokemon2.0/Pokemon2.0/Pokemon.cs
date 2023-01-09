using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon2
{
    internal class Pokemon
    {
        PokemonSpecies species;
        string name;
        int currentHealth;
        char gender; //M (Male), F (Female)
        DateTime captureDate;
        Trainer originalTrainer;

        public Pokemon(PokemonSpecies species)
        {
            this.species = species;
            name = species.GetSpeciesName();
            currentHealth = species.GetHealth();
            gender = CalculateGender(species);
            originalTrainer = null;
        }

        public void SetCaptureDate()
        {
            captureDate = DateTime.Now;
        }

        public int GetSpeed()
        {
            return species.GetSpeed();
        }

        public DateTime GetCaptureDate()
        {
            return captureDate;
        }

        public PokemonSpecies GetPokemonSpecies()
        {
            return species;
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
            return currentHealth;
        }

        public int GetMaxHealth()
        {
            return species.GetHealth();
        }

        public int GetCatchRate()
        {
            return species.GetCatchrate();
        }

        public void SetHealth(int newHealth)
        {
            currentHealth = newHealth;
        }

        public int GetAttack()
        {
            return species.GetAttack();
        }

        public int GetDefense()
        {
            return species.GetDefense();
        }

        private char CalculateGender(PokemonSpecies species)
        {
            char generatedGender = 'N'; //We give it a default value of N
            Random random = new Random();
            double chance = random.NextDouble();
            double maleChance = species.GetMaleChance();

            if (chance <= maleChance / 100)
            {
                generatedGender = 'M';
            }
            else
            {
                generatedGender = 'F';
            }

            return generatedGender;
        }
    }
}
