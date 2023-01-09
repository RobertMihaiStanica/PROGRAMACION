using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuscaMinas
{
    class GameBoard
    {
        int rows;
        int columns;
        int mines;
        int treasure;
        string[][] axis;
        int xPosition;
        int yPosition;


        public GameBoard(int dimension, int mines, int treasures)
        {
            this.columns = dimension;
            this.rows = dimension;
            this.mines = mines;
            this.treasure = treasures;
            axis = new string[this.rows][];
            GenerateBoard();
            xPosition = 0;
            yPosition = 0;
        }

        public void SetMines(int mines)
        {
            this.mines = mines;
        }

        public int GetMines()
        {
            return mines;
        }

        public void SetTreasure(int treasure)
        {
            this.treasure = treasure;
        }

        public int GetTreasure()
        {
            return treasure;
        }

        public void SetDimensions(int rows, int columns)//Here we decide the size of the board
        {
            this.rows = rows;
            this.columns = columns;
            axis = new string[rows][];
        }

        public void GenerateBoard() //We generate the board based on the values we give it
        {   
            for (int rowPosition = 0; rowPosition < rows; ++rowPosition)
            {
                axis[rowPosition] = GenerateXAxis(columns);
            }
            PlaceItems(mines, "[M]");
            PlaceItems(treasure, "[T]");
        }

        private string[] GenerateXAxis(int columns) //We generate different arrays to fill the lines of the table
        {
            string[] xAxis = new string[columns];
            for (int columnPosition = 0; columnPosition < columns; ++columnPosition)
            {
                xAxis[columnPosition] = "["+ columnPosition + "]";
            }
            return xAxis;
        }

        private void PrintBoard()//This metod will print the game board changing the color of the element we are standig
        {
            for (int rowPosition = 0; rowPosition < columns; ++rowPosition) //This will run throught the different columns
            {
                for (int columnPosition = 0; columnPosition < rows; ++columnPosition) //This will run throught the rows of the column
                {
                    if (axis[rowPosition][columnPosition] == "[X]")
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else if(axis[rowPosition][columnPosition] == "[D]")
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else
                    {
                        NavigationColor(rowPosition, columnPosition);
                    }
                    Console.Write(axis[rowPosition][columnPosition]);
                }
                Console.WriteLine();
            } //We change the color back to the default values so the whole console doesn´t change it´s color
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }

        private void NavigationColor(int row, int column) //This will change the color of the position we are at
        {
            if (yPosition == row && xPosition == column)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.BackgroundColor = ConsoleColor.DarkYellow;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.White;
            }
        }

        public void GameStart()//Here we will calculate the movement of our position
        {
            ConsoleKeyInfo input;//We have to declare the input outside 

            do
            {
                PrintBoard(); //We print the board once, then each time there is a movement

                input = Console.ReadKey(); //Then we ask the player for an input

                Console.Clear();//Then we clear the console before calculating the new movement

                if (input.Key == ConsoleKey.UpArrow) //Left and right navigation
                {
                    yPosition -= 1;
                }
                if (input.Key == ConsoleKey.DownArrow)
                {
                    yPosition += 1;
                }
                if (yPosition >= axis.Length)
                {
                    yPosition = axis.Length - 1;
                }
                if (yPosition < 0)
                {
                    yPosition = 0;
                }

                if (input.Key == ConsoleKey.RightArrow) //Up and down navigation
                {
                    xPosition += 1;
                }
                if (input.Key == ConsoleKey.LeftArrow)
                {
                    xPosition -= 1;
                }
                if (xPosition >= axis[0].Length)
                {
                    xPosition = axis[0].Length - 1;
                }
                if (xPosition < 0)
                {
                    xPosition = 0;
                }

                if (input.Key == ConsoleKey.Enter)//Here when we press the enter key we decide what will happen depending on whats in the possition we are at
                {
                    if (axis[yPosition][xPosition] == "[M]")
                    {
                        Console.WriteLine("Has pisado una mina, perdiste el juego");
                        break;
                    }
                    if (axis[yPosition][xPosition] == "[T]")
                    {
                        Console.WriteLine("Has encontrado el tesoro, ganaste el juego");
                        break;
                    }


                    if (yPosition == 0 && xPosition == 0) //This big if will calculate or possition and based on that decide wich boxes we have to ceck for mines
                    {                                     //This way we never go out of bounds and generate errors (i´m sure there is a better way to do this)
                        if (axis[yPosition][xPosition + 1] != "[M]" &&
                            axis[yPosition + 1][xPosition] != "[M]" &&
                            axis[yPosition + 1][xPosition + 1] != "[M]")
                        {
                            axis[yPosition][xPosition] = "[X]";
                        }
                        else
                        {
                            axis[yPosition][xPosition] = "[D]";
                        }
                    }
                    else if (yPosition == 0 && xPosition == axis[0].Length -1)
                    {
                        if (axis[yPosition][xPosition - 1] != "[M]" &&
                            axis[yPosition + 1][xPosition] != "[M]" &&
                            axis[yPosition + 1][xPosition - 1] != "[M]")
                        {
                            axis[yPosition][xPosition] = "[X]";
                        }
                        else
                        {
                            axis[yPosition][xPosition] = "[D]";
                        }
                    }
                    else if (yPosition == axis.Length -1 && xPosition == 0)
                    {
                        if (axis[yPosition][xPosition + 1] != "[M]" &&
                            axis[yPosition - 1][xPosition] != "[M]" &&
                            axis[yPosition - 1][xPosition + 1] != "[M]")
                        {
                            axis[yPosition][xPosition] = "[X]";
                        }
                        else
                        {
                            axis[yPosition][xPosition] = "[D]";
                        }
                    }
                    else if (yPosition == axis.Length -1 && xPosition == axis[0].Length -1)
                    {
                        if (axis[yPosition][xPosition - 1] != "[M]" &&
                            axis[yPosition - 1][xPosition] != "[M]" &&
                            axis[yPosition - 1][xPosition - 1] != "[M]")
                        {
                            axis[yPosition][xPosition] = "[X]";
                        }
                        else
                        {
                            axis[yPosition][xPosition] = "[D]";
                        }
                    }
                    else if (yPosition == 0)
                    {
                        if (axis[yPosition][xPosition + 1] != "[M]" &&
                            axis[yPosition][xPosition -1] != "[M]" &&
                            axis[yPosition + 1][xPosition] != "[M]" &&
                            axis[yPosition + 1][xPosition - 1] != "[M]" &&
                            axis[yPosition + 1][xPosition + 1] != "[M]")
                        {
                            axis[yPosition][xPosition] = "[X]";
                        }
                        else
                        {
                            axis[yPosition][xPosition] = "[D]";
                        }
                    }
                    else if (xPosition == 0)
                    {
                        if (axis[yPosition][xPosition + 1] != "[M]" &&
                            axis[yPosition - 1][xPosition] != "[M]" &&
                            axis[yPosition + 1][xPosition] != "[M]" &&
                            axis[yPosition - 1][xPosition + 1] != "[M]" &&
                            axis[yPosition + 1][xPosition + 1] != "[M]")
                        {
                            axis[yPosition][xPosition] = "[X]";
                        }
                        else
                        {
                            axis[yPosition][xPosition] = "[D]";
                        }
                    }
                    else if (xPosition == axis[0].Length -1)
                    {
                        if (axis[yPosition][xPosition - 1] != "[M]" &&
                            axis[yPosition - 1][xPosition] != "[M]" &&
                            axis[yPosition + 1][xPosition] != "[M]" &&
                            axis[yPosition + 1][xPosition - 1] != "[M]" &&
                            axis[yPosition - 1][xPosition - 1] != "[M]")
                        {
                            axis[yPosition][xPosition] = "[X]";
                        }
                        else
                        {
                            axis[yPosition][xPosition] = "[D]";
                        }
                    }
                    else if (yPosition == axis.Length - 1)
                    {
                        if (axis[yPosition][xPosition + 1] != "[M]" &&
                            axis[yPosition][xPosition - 1] != "[M]" &&
                            axis[yPosition - 1][xPosition] != "[M]" &&
                            axis[yPosition - 1][xPosition - 1] != "[M]" &&
                            axis[yPosition - 1][xPosition + 1] != "[M]")
                        {
                            axis[yPosition][xPosition] = "[X]";
                        }
                        else
                        {
                            axis[yPosition][xPosition] = "[D]";
                        }
                    }
                    else
                    {
                        if (axis[yPosition - 1][xPosition - 1] != "[M]" &&
                            axis[yPosition - 1][xPosition] != "[M]" &&
                            axis[yPosition - 1][xPosition + 1] != "[M]" &&
                            axis[yPosition][xPosition - 1] != "[M]" &&
                            axis[yPosition][xPosition + 1] != "[M]" &&
                            axis[yPosition + 1][xPosition - 1] != "[M]" &&
                            axis[yPosition + 1][xPosition] != "[M]" &&
                            axis[yPosition + 1][xPosition + 1] != "[M]"
                            )
                        {
                            axis[yPosition][xPosition] = "[X]";
                        }
                        else
                        {
                            axis[yPosition][xPosition] = "[D]";
                        }
                    }
                }

            } while (input.Key != ConsoleKey.Escape);
        }

        public void PlaceItems(int item, string type) //This generates a random string in a random position. It will have to be "[M]" for mines or "[T]" for treasure
        {

            int itemCounter = 0;
            Random randx = new Random();
            Random randy = new Random();
            while (itemCounter < item)
            {
                if (axis[randy.Next(axis.Length)][randy.Next(axis[0].Length)] != "[M]" &&
                    axis[randy.Next(axis.Length)][randy.Next(axis[0].Length)] != "[T]")
                {
                    axis[randy.Next(axis.Length)][randy.Next(axis[0].Length)] = type;
                    ++itemCounter;
                }
            }
        }
    }
}
