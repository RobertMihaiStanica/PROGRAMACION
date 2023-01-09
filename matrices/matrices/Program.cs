using System.Drawing;

namespace matrices
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1) Generar array y señalar su maximo y su minimo");
            int option = Convert.ToInt32(Console.ReadLine());

            int rows;
            int cols;
            int limit;
            int[][] matrix;

            switch (option){
                case 1:
                    Console.WriteLine("Dime el numero de filas: ");
                    rows = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Dime el numero de columnas: ");
                    cols = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Dime el limite de los numeros que se van a generar: ");
                    limit = Convert.ToInt32(Console.ReadLine());
                    matrix = FillMatrix(rows, cols, limit);
                    PrintMaxMinArray(matrix, MaxMatrixNum(matrix), MinMatrixNum(matrix));
                    break;
                case 2:
                    Console.WriteLine("Dime el numero de filas: ");
                    rows = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Dime el numero de columnas: ");
                    cols = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Dime el limite de los numeros que se van a generar: ");
                    limit = Convert.ToInt32(Console.ReadLine());
                    matrix = FillMatrix(rows, cols, limit);
                    break;
                case 3:

                    break;
                case 4:

                    break;
                case 5:

                    break;
                default:
                    Console.WriteLine("No has introducido una opccion valida");
                    break;
            }
                
        }

        static int[][] FillMatrix(int rows, int colms, int limit)
        {
            int[][] matrix = new int[rows][];
            Random rand = new Random();

            for (int rowCount = 0; rowCount < matrix.Length; ++rowCount)
            {
                matrix[rowCount] = new int[colms];

                for (int colCount = 0; colCount < matrix[0].Length; ++colCount)
                {
                    matrix[rowCount][colCount] = rand.Next(limit);
                }
            }
            return matrix;
        }

        static void AskForMatrixInput()
        {

        }

        static int MinMatrixNum(int[][] matrix)
        {
            int min = matrix[0][0];

            for (int rowCount = 0; rowCount < matrix.Length; ++rowCount)
            {
                for (int colCount = 0; colCount < matrix[0].Length; ++colCount)
                {
                    if (matrix[rowCount][colCount] < min)
                    {
                        min = matrix[rowCount][colCount];
                    } 
                }
            }
            return min;
        }

        static int MaxMatrixNum(int[][] matrix)
        {
            int max = matrix[0][0];

            for (int rowCount = 0; rowCount < matrix.Length; ++rowCount)
            {
                for (int colCount = 0; colCount < matrix[0].Length; ++colCount)
                {
                    if (matrix[rowCount][colCount] > max)
                    {
                        max = matrix[rowCount][colCount];
                    }
                }
            }
            return max;
        }

        static void PrintMaxMinArray(int[][] matrix, int max, int min)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("El rojo es el numero mas grande");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("El azul es el numero mas pequeño");
            
            for (int rowCount = 0; rowCount < matrix.Length; ++rowCount)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write(rowCount + " -");

                for (int colCount = 0; colCount < matrix[0].Length; ++colCount)
                {
                    if (matrix[rowCount][colCount] == max)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else if (matrix[rowCount][colCount] == min)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    Console.Write(" [" + matrix[rowCount][colCount] + "] ");
                }
                Console.WriteLine();
            }
        }
    }
}