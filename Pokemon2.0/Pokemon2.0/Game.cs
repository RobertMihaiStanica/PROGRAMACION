using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon2
{
    internal class Game
    {
        IO io;
        Trainer playerTrainer; //Our player
        Random random; //A random value we will use throught the code
        PokemonSpecies[] pokemons; //All the pokemon species in the game
        Pokemon? currentPlayerPokemon; //The current active pokemon
        bool isPlayerTurn; //This boolean will decide if it´s the player turn or not
        int escapeAttempts;

        public Game(IO io)
        {
            this.io = io;
            random = new Random();
            CreatePokemonSpecies();
            PlayerCreationScreen();
        }

        public Game(IO io, string name, string gender) //Fast constructor (useful for debugging)
        {
            this.io = io;
            random = new Random();
            CreatePokemonSpecies();
            playerTrainer = new Trainer(name, gender);
        }

        public void Run() //Main game
        {
            StarterPokemonScreen();
            MainMenu();
        }
        private void CreatePokemonSpecies() //We will create all the pokemon species will need at the start of the game
        {
            //Here we create all the pokemon species we will use in the game
            PokemonSpecies bulbasur = new PokemonSpecies(1, "Bulbasur", 45, 87.5, 49, 49, 45, 45);
            PokemonSpecies charmander = new PokemonSpecies(4, "Charmander", 45, 87.5, 43, 52, 65, 39);
            PokemonSpecies squirtle = new PokemonSpecies(7, "Squirtle", 45, 87.5, 65, 48, 43, 44);
            PokemonSpecies rattata = new PokemonSpecies(19, "Rattata", 255, 50, 35, 56, 72, 30);

            //Below we will add the created species to an array
            PokemonSpecies[] pokemons = {bulbasur, charmander, squirtle, rattata};

            //After the step above we will add the species to the game itself in the line below
            this.pokemons = pokemons;
        }

        private void PlayerCreationScreen() //Here we will chose our name nad gender
        {
            string[] genderMenu = { "Boy", "Girl" };
            string[] yesNoMenu = { "Yes", "No" };
            string gender;
            string name;
            string answer;

            do {
                //Welcome message
                io.PrintMessage("Welcome to the amazing world of pokemon!\n");
                //Gender selection
                gender = genderMenu[io.SelectableMenu(genderMenu, "Are you a boy or a girl?")];
                io.PrintMessage("So you are a " + gender + "!\n");
                //Name selection
                name = io.AskForString("What is your name?\n");
                io.PrintMessage("Nice to meet you " + name + "!\n");
                //Confirm choices
                io.PrintMessage("So your name is " + name + " and you are a " + gender + "\n");
                answer = yesNoMenu[io.SelectableMenu(yesNoMenu, "Are you sure about your choices?")];
            } while (answer != yesNoMenu[0]);

            playerTrainer = new Trainer(name, gender); //We create the playerTrainer with the information we got from the questions above

            //We display the message below as a way of checking if everything is correct
            io.PrintMessage("Your trainer is called " + playerTrainer.GetName() + ", your adventure began at " + playerTrainer.GetCreationDate() + " and yout ID is " + (playerTrainer.GetTrainerID()).ToString() + "\n");
        }

        public void StarterPokemonScreen() //The starting screen where we will chose our first pokemon
        {
            string[] yesNoMenu = { "Yes", "No" };
            string answer;
            Pokemon starterPokemon;

            do
            {
                //This will display the starter pokemon menu
                io.PrintMessage("Now lets chose your firs pokemon!\n");
                int choice = io.SelectableMenu(io.SpeciesArrayToString(pokemons), "Chose your first pokemon!");
                starterPokemon = new Pokemon(pokemons[choice]);

                //Confirm choice
                answer = yesNoMenu[io.SelectableMenu(yesNoMenu, "Do you want " + starterPokemon.GetName() + " as your first pokemon?")];

            } while (answer != yesNoMenu[0]);

            starterPokemon.SetCaptureDate();
            ChangePokemonName(starterPokemon);
            playerTrainer.CapturePokemon(starterPokemon);

            io.PrintMessage("Congratulations! You and " + playerTrainer.GetPokemons()[0].GetName() + " have begun your adventure together on " + playerTrainer.GetPokemons()[0].GetCaptureDate() + "!\n");
           
        }

        public void MainMenu() //The main menu of the game
        {
            string[] mainMenu = { "New Combat", "Show Stats", "Pokemon Center", "Close Game" }; //The different menu options
            int answer = io.SelectableMenu(mainMenu, "What do you want to do?"); //We will store the position of the menu as the answer
            
            switch (answer) //We will use the answer value as a trigger for the different options on the menu
            {
                case 0:
                    int ranPokeNum = random.Next(pokemons.Length);
                    Pokemon enemyPokemon = new Pokemon(pokemons[ranPokeNum]);
                    CombatScreen(enemyPokemon);
                    break;
                case 1:
                    break;
                case 2:
                    HealPokemons();
                    MainMenu();
                    break;
                case 3:
                    io.PrintMessage("Closing Game...");
                    System.Environment.Exit(1); //We exit the application
                    break;
            }
        }

        public void HealPokemons() //Healing pokemons throught the pokemon center
        {
            //Starting to heal pokemons
            io.PrintMessage("Healing your pokemons...\n");
            io.PrintMessage("Almost ready...\n");
            io.PrintMessage("...\n");
            //Give each pokemon it's max health
            for (int position = 0; position < playerTrainer.GetPokemons().Length; ++position)
            {
                if (playerTrainer.GetPokemons()[position] != null)
                {
                    playerTrainer.GetPokemons()[position].SetHealth(playerTrainer.GetPokemons()[position].GetMaxHealth());
                }
            }
            //Finish message
            io.PrintMessage("Your pokemons have been healed!\n");
        }

        public void CombatScreen(Pokemon enemyPokemon) //Have to finish this (missing turn detection based on pokemon speed)
        {
            escapeAttempts = 0;
            AlivePokemonCheck();
            io.PrintMessage("You´ve encountered a wild " + enemyPokemon.GetName() + "\n");
            DecideFirstTurn(enemyPokemon);
            
            while (enemyPokemon.GetHealth() > 0)
            {
                if (isPlayerTurn == true) //The logic behind the combat based on turns
                {
                    if (currentPlayerPokemon.GetHealth() <= 0)
                    {
                        io.PrintMessage("Your " + currentPlayerPokemon.GetName() + " has been defeated!\n");
                        AlivePokemonCheckCombat();
                        io.PrintMessage("Chose a new pokemon!\n");
                        ChangeCurrentPokemon();
                    }
                    PlayerTurn(enemyPokemon);
                }
                if (isPlayerTurn == false)
                {
                    if (enemyPokemon.GetHealth() <= 0)
                    {
                        io.PrintMessage("You have defeated the wild " + enemyPokemon.GetName() + "!\n");
                        break;
                    }
                    EnemyTurn(enemyPokemon);
                }
            }
            MainMenu();
            return;
        }

        public void DecideFirstTurn(Pokemon enemyPokemon) //Here we will decide if the player starts firs, or the ennemy
        {
            if (currentPlayerPokemon.GetSpeed() > enemyPokemon.GetSpeed())
            {
                isPlayerTurn = true;
            }
            if (currentPlayerPokemon.GetSpeed() < enemyPokemon.GetSpeed())
            {
                isPlayerTurn=false;
            }
            if (currentPlayerPokemon.GetSpeed() == enemyPokemon.GetSpeed())
            {
                int randTurn = random.Next(2);

                switch (randTurn)
                {
                    case 0:
                        isPlayerTurn = true;
                        break;
                    case 1:
                        isPlayerTurn = false;
                        break;
                }
            }
        }

        public void PlayerTurn(Pokemon enemyPokemon) //The actions available to the player during his turn
        {
            string[] combatMenu = { "Attack", "Change Pokemon", "Capture Pokemon", "Escape" };
            int answer = io.SelectableCombatMenu(combatMenu, "What are you going to do?", currentPlayerPokemon, enemyPokemon);

            switch (answer)
            {
                case 0:
                    Attack(currentPlayerPokemon, enemyPokemon);
                    break;
                case 1:
                    ChangeCurrentPokemon();
                    break;
                case 2:
                    CapturePokemon(enemyPokemon);
                    break;
                case 3:
                    EscapeCombat(enemyPokemon);
                    break;
            }
        }

        public void CapturePokemon(Pokemon targetPokemon) //The logic behind the capture of the pokemons
        {
            io.PrintMessage("Throwing pokeball to the wild " + targetPokemon.GetName() + "\n");

            int succesfulShake = 0; //We will store the succesful shakes number here
            int mcrnumber = ((3 * targetPokemon.GetMaxHealth() - 2 * targetPokemon.GetHealth()) * 4096 * targetPokemon.GetCatchRate()) / 3 * targetPokemon.GetMaxHealth(); //This is the Modified Capture Ratio

            Console.WriteLine("The catchrate is " + mcrnumber);

            for (int shake = 0; shake < 4; ++shake)
            {
                double shakeNumber = 65536 / Math.Pow((255 / mcrnumber), 0.1875);
                io.PrintMessage("The ball is shaking...\n");
                io.PrintMessage("...\n");

                if (shakeNumber >= random.Next(65536))
                {
                    ++succesfulShake;
                }
                else
                {
                    break;
                }
            }

            if (succesfulShake == 4)
            {
                io.PrintMessage("You have captured the wild " + targetPokemon.GetName() + "!\n");
                playerTrainer.CapturePokemon(targetPokemon);
                ChangePokemonName(targetPokemon);
                MainMenu();
            }
            if (succesfulShake < 4)
            {
                io.PrintMessage("The pokemon has escaped!\n");
                isPlayerTurn = false;
            }
        }

        public void EnemyTurn(Pokemon enemyPokemon) //The enemy will always attack
        {
            Attack(enemyPokemon, currentPlayerPokemon);
        }

        public void Attack(Pokemon attackingPokemon, Pokemon targetPokemon)
        {
            io.PrintMessage(attackingPokemon.GetName() + " is attacking " + targetPokemon.GetName() + "!\n");
            //Below we calculate the dammage
            double rand = Convert.ToDouble(random.Next(85, 101)) / 100; ;
            double damage = (2 * 50 * (attackingPokemon.GetAttack() / targetPokemon.GetDefense()) / 50 + 2) * rand * 5;
            io.PrintMessage(attackingPokemon.GetName() + " does " + damage + " damage to " + targetPokemon.GetName() + "!\n");

            //Below we apply the damage
            targetPokemon.SetHealth(Convert.ToInt32(targetPokemon.GetHealth() - damage));

            if (targetPokemon.GetHealth() < 0)
            {
                targetPokemon.SetHealth(0);
            }

            if (isPlayerTurn == false)
            {
                isPlayerTurn = true;
            }
            else
            {
                isPlayerTurn = false;
            }
        }

        public void ChangeCurrentPokemon() //This will let us change the pokemon in the middle of the combat
        {
            string[] playerPokemons = io.PokemonArrayToString(playerTrainer.GetPokemons());
            string[] yesNoMenu = { "Yes", "No" };
            int answer = io.SelectableMenu(playerPokemons, "Chose your pokemon:");

            if (playerTrainer.GetPokemons()[answer].GetHealth() <= 0) //This is a temporal solution, if the pokemon has 0HP you shouldn't be able to select it
            {
                io.PrintMessage("The pokemon you have chosen is weakened! Chose another one\n");
                ChangeCurrentPokemon();
                return;
            }

            if (playerTrainer.GetPokemons()[answer] == currentPlayerPokemon)
            {
                io.PrintMessage("You have selected the same pokemon! If you chose the same pokemon you wont lose your turn!\n");
                answer = io.SelectableMenu(yesNoMenu, "Do you want to chose a different pokemon?");
                if (yesNoMenu[answer] == yesNoMenu[0])
                {
                    ChangeCurrentPokemon();
                    return;
                }
                if (yesNoMenu[answer] == yesNoMenu[1])
                {
                    return;
                }
            }
            currentPlayerPokemon = playerTrainer.GetPokemons()[answer];
            io.PrintMessage("You have selected " + currentPlayerPokemon.GetName() + " for combat!\n");
            isPlayerTurn = false;
        }

        public void EscapeCombat(Pokemon enemyPokemon)
        {
            ++escapeAttempts;

            if (enemyPokemon.GetSpeed() < currentPlayerPokemon.GetSpeed())
            {
                io.PrintMessage("You escaped!\n");
                MainMenu();
            }
            else
            {
                int rand = random.Next(256);
                int oddsEscape = (((currentPlayerPokemon.GetSpeed() * 128) / enemyPokemon.GetSpeed()) + 30 * escapeAttempts) % 256;
                Console.WriteLine("the odds to escape are " + oddsEscape);

                if (oddsEscape > rand)
                {
                    io.PrintMessage("You escaped!\n");
                    MainMenu();
                }
                else
                {
                    io.PrintMessage("You didn´t mannage to escape...\n");
                    isPlayerTurn = false;
                }
            }
        }

        public void AlivePokemonCheck() //We check if the pokemon is alive, the first combat able pokemon will be selected as the current pokemon
        {
            for (int position = 0; position < playerTrainer.GetPokemons().Length; position++)
            {
                if (playerTrainer.GetPokemons()[position] != null && playerTrainer.GetPokemons()[position].GetHealth() > 0)
                {
                    currentPlayerPokemon = playerTrainer.GetPokemons()[position];
                    break;
                }

                if (position == playerTrainer.GetPokemons().Length - 1) //We want to make sure there is no available pokemon if none of them have enought health
                {
                    currentPlayerPokemon = null;
                }
            }
            if (currentPlayerPokemon == null) //If no pokemon is able to combat we will return to the main menu
            {
                io.PrintMessage("You have no pokemons ready to combat! Escaping combat...\n");
                MainMenu();
                return;
            }
            
        }

        public void AlivePokemonCheckCombat() //We check if the pokemon is alive, the first combat able pokemon will be selected as the current pokemon
        {
            for (int position = 0; position < playerTrainer.GetPokemons().Length; position++)
            {
                if (playerTrainer.GetPokemons()[position].GetHealth() > 0)
                {
                    break;
                }

                if (position == playerTrainer.GetPokemons().Length - 1) //We want to make sure there is no available pokemon if none of them have enought health
                {
                    currentPlayerPokemon = null;
                }
            }
            if (currentPlayerPokemon == null) //If no pokemon is able to combat we will return to the main menu
            {
                io.PrintMessage("You have no pokemons ready to combat! Escaping combat...\n");
                MainMenu();
                return;
            }

        }

        public void ChangePokemonName(Pokemon pokemon) //This is used to change the name of a newly obtained pokemon
        {
            string[] yesNoMenu = { "Yes", "No" };
            string answer;

            answer = yesNoMenu[io.SelectableMenu(yesNoMenu, "Do you want to change the name of " + pokemon.GetName())];

            if (answer == yesNoMenu[0])
            {
                string newName = io.AskForString("Whats the new name you want to give " + pokemon.GetName() + "?\n");
                pokemon.SetName(newName);
            }
            //It would be possible to implemet this as an option in the menu for the player to use without limitations
        }
    }
}
