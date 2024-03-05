using System;
using System.Diagnostics.Metrics;

namespace assignment3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            program.Start();
        }
        void Start()
        {
            RegularCandies[,] playingField = new RegularCandies[10, 10];
            InitCandies(playingField);
            DisplayCandies(playingField);
        }
        void InitCandies(RegularCandies[,] candies)
        {
            Random random = new Random();
            for (int i = 0; i < candies.GetLength(0); i++)
            {
                for (int j = 0; j < candies.GetLength(1); j++)
                {
                    candies[i, j] = (RegularCandies)random.Next(0, 6);
                }
            }
        }
        void DisplayCandies(RegularCandies[,] candies)
        {
            for (int i = 0; i < candies.GetLength(0); i++)
            {
                Console.WriteLine();
                for (int j = 0; j < candies.GetLength(1); j++)
                {
                    if (candies[i, j] == RegularCandies.JellyBean)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("# ");
                        Console.ResetColor();
                    }
                    else if (candies[i, j] == RegularCandies.Lozenge)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("# ");
                        Console.ResetColor();
                    }
                    else if (candies[i, j] == RegularCandies.LemonDrop)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("# ");
                        Console.ResetColor();
                    }
                    else if (candies[i, j] == RegularCandies.GumSquare)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("# ");
                        Console.ResetColor();
                    }
                    else if (candies[i, j] == RegularCandies.LollipopHead)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("# ");
                        Console.ResetColor();
                    }
                    else if (candies[i, j] == RegularCandies.JujubeCluster)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("# ");
                        Console.ResetColor();
                    }
                }
            }
        }
        bool ScoreRowPresent(RegularCandies[,] candies)
        {
            for (int i = 0; i < candies.GetLength(1); i++)
            {
                int counter = 1;
                RegularCandies currentCandie = candies[i, 0];

                for (int j = 0; j < candies.GetLength(0); j++)
                {
                    if (candies[i,j] == currentCandie)
                    {
                        counter++;
                        if (counter >= 3)
                        {
                            return true;
                        }
                        else
                        {
                            currentCandie = candies[i, j];
                            counter = 1;
                        }
                    }
                }
            }
            return false;
        }

        bool ScoreColumnPresent(RegularCandies[,] candies)
        {
            for (int i = 0; i < candies.GetLength(1); i++)
            {
                int counter = 1;
                RegularCandies currentCandie = candies[0, i];

                for (int j = 0; j < candies.GetLength(0); j++)
                {
                    if (candies[i, j] == currentCandie)
                    {
                        counter++;
                        if (counter >= 3)
                        {
                            return true;
                        }
                        else
                        {
                            currentCandie = candies[i, j];
                            counter = 1;
                        }
                    }
                }
            }
            return false;
        }
    }
}