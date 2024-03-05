using System;
using System.Transactions;

namespace assignment2
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
            InitMatrixRandom(arr, 1, 100);
            DisplayMatrix(arr);
            Console.Write("Enter a number (to search for): ");
            int number = Convert.ToInt32(Console.ReadLine());
            Console.Write($"Number {number} is found (first) at position ");
            PrintPerson(SearchNumber(arr, number));
            Console.WriteLine();
            Console.Write($"Number {number} is found (last) at position ");
            PrintPerson(SearchNumberBackwards(arr, number));
        }
        void InitMatrixRandom(int[,] matrix, int min, int max)
        {
            Random random = new Random();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = random.Next(min, max);
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
        Position SearchNumber(int[,] matrix, int number)
        {
            Position position = new Position();
            bool hasToEnd = false;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (hasToEnd == false)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        if (matrix[i, j] == number)
                        {
                            position.Rows = i;
                            position.Columns = j;
                            hasToEnd = true;
                            break;
                        }
                    }
                }
                else
                {
                    break;
                }
            }
            return position;
        }
        Position SearchNumberBackwards(int[,] matrix, int number)
        {
            Position position = new Position();
            bool hasToEnd = false;
            for (int i = matrix.GetLength(0) - 1; i >= 0; i--)
            {
                if (hasToEnd == false)
                {
                    for (int j = matrix.GetLength(1) - 1; j >= 0; j--)
                    {
                        if (matrix[i, j] == number)
                        {
                            position.Rows = i;
                            position.Columns = j;
                            hasToEnd = true;
                            break;
                        }
                    }
                }
                else
                {
                    break;
                }
            }
            return position;
        }
        void PrintPerson(Position p)
        {
            Console.Write($"[{p.Rows},{p.Columns}]");
        }
    }
}