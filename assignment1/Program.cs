using System.Diagnostics.Metrics;
using System.Runtime.InteropServices;

namespace assignment1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("invalid number of arguments!");
                Console.WriteLine("usage: assignment[1-3] <nr of rows> <nr of columns>");
                return;
            }
            int numberOfRows = int.Parse(args[0]);
            int numberOfColumns = int.Parse(args[1]);
            Program myProgram = new Program();
            myProgram.Start(numberOfRows, numberOfColumns);
        }
        void Start(int numberOfRows, int numberOfColumns)
        {
            int[,] arr = new int[numberOfRows, numberOfColumns];
            InitMatrix2D(arr);
            DisplayMatrix(arr);
            Console.WriteLine();
            InitMatrixLinear(arr);
            DisplayMatrixWithCross(arr);
        }
        void InitMatrix2D(int[,] matrix)
        {
            int counter = 1;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = counter;
                    counter++;
                }
            }
        }
        void DisplayMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($" {matrix[i, j],3}");
                }
                Console.WriteLine();
            }
        }
        void InitMatrixLinear(int[,] matrix)
        {
            int counter = 1;
            for (int i = 0; i < matrix.GetLength(0) * matrix.GetLength(1); i++)
            {
                int row = i / matrix.GetLength(0);
                int col = i % matrix.GetLength(1);

                matrix[row, col] = counter;
                counter++;
            }
        }
        void DisplayMatrixWithCross(int[,] matrix)
        {
            int red1 = 0;
            int red2 = 0;
            int yellow1 = 0;
            int yellow2 = matrix.GetLength(0) - 1;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if ((i == yellow1 && j == yellow2) && (i == red1 && j == red2))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.Write($" {matrix[i, j],3}");
                        Console.ResetColor();
                        red1++;
                        red2++;
                        yellow1++;
                        yellow2--;
                    }
                    else if (i == red1 && j == red2)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write($" {matrix[i, j],3}");
                        Console.ResetColor();
                        red1++;
                        red2++;
                    }
                    else if (i == yellow1 && j == yellow2)
                    {
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.Write($" {matrix[i, j],3}");
                        Console.ResetColor();
                        yellow1++;
                        yellow2--;
                    }
                    else
                    {
                        Console.Write($" {matrix[i, j],3}");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}