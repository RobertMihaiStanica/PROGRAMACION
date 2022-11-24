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
        int xPosition = 0;
        int yPosition = 0;



        public void SetDimensions(int rows, int columns)//Here we decide the size of the board
        {
            this.rows = rows;
            this.columns = columns;
            axis = new string[rows][];
        }

        public void GenerateBoard() //We generate the board based on the values we give it
        {   
            for (int rowPosition = 0; rowPosition < columns; ++rowPosition)
            {
                axis[rowPosition] = GenerateXAxis(columns);
            }
        }

        private string[] GenerateXAxis(int columns) //We generate different arrays to fill the lines of the 
        {
            string[] xAxis = new string[columns];
            for (int columnPosition = 0; columnPosition < rows; ++columnPosition)
            {
                xAxis[columnPosition] = "[]";
            }
            return xAxis;
        }

        private void PrintBoard()//This metod will print the game board changing the color of the element we are standig
        {
            for (int rowPosition = 0; rowPosition < columns; ++rowPosition) //This will run throught the different columns
            {
                for (int columnPosition = 0; columnPosition < rows; ++columnPosition) //This will run throught the rows of the column
                {
                    NavigationColor(rowPosition, columnPosition);
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

        public void Navigation()//Here we will calculate the movement of our position
        {
            ConsoleKeyInfo input;//We have to declare the input outside 

            do
            {
                PrintBoard(); //We print the board once, then each time there is a movement

                input = Console.ReadKey(); //Then we ask the player for an input

                Console.Clear();//Then we clear the console before calculating the new movement

                if (input.Key == ConsoleKey.UpArrow)
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

                if (input.Key == ConsoleKey.RightArrow)
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

            } while (input.Key != ConsoleKey.Enter);
        }
    }
}
