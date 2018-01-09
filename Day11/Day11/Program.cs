using System;
using System.IO;

namespace Day11
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Part1();
            Part2();
        }

        public static void Part1()
        {
            string Text = File.ReadAllText("/Users/jakobbussas/Projects/AdventOfCode/Day11/Day11/Day11.txt");

            string[] Directions = Text.Split(',');

            int North = 0;
            int NorthEast = 0;
            int NorthWest = 0;

            foreach (var Direction in Directions)
            {
                switch (Direction)
                {
                    case "n":
                        North++;
                        break;
                    case "ne":
                        NorthEast++;
                        break;
                    case "nw":
                        NorthWest++;
                        break;
                    case "s":
                        North--;
                        break;
                    case "se":
                        NorthWest--;
                        break;
                    case "sw":
                        NorthEast--;
                        break;
                    default:
                        throw new Exception("Error: Unbekannte Richtung!");
                }
            }

            // Jetzt ausrechnen
            int Steps = GetDistance(North, NorthEast, NorthWest);
            Console.WriteLine(Steps);
            // 524 too low
            // 670
        }

        public static void Part2()
        {
            string Text = File.ReadAllText("/Users/jakobbussas/Projects/AdventOfCode/Day11/Day11/Day11.txt");

            string[] Directions = Text.Split(',');

            int North = 0;
            int NorthEast = 0;
            int NorthWest = 0;

            int MaxDistance = 0;

            foreach (var Direction in Directions)
            {
                switch (Direction)
                {
                    case "n":
                        North++;
                        break;
                    case "ne":
                        NorthEast++;
                        break;
                    case "nw":
                        NorthWest++;
                        break;
                    case "s":
                        North--;
                        break;
                    case "se":
                        NorthWest--;
                        break;
                    case "sw":
                        NorthEast--;
                        break;
                    default:
                        throw new Exception("Error: Unbekannte Richtung!");
                }

                if(MaxDistance < GetDistance(North, NorthEast, NorthWest)) {
                    MaxDistance = GetDistance(North, NorthEast, NorthWest);
                }
            }

            Console.WriteLine("Maximale Distanz = "+ MaxDistance);
            // 1426
        }

        private static int GetDistance(int North, int NorthEast, int NorthWest)
        {
            bool Changing;
            do
            {
                Changing = false;
                while (NorthWest > 0 && NorthEast > 0)
                {
                    NorthWest--;
                    NorthEast--;
                    North++;
                    Changing = true;
                }
                while (North > 0 && NorthWest < 0)
                {
                    North--;
                    NorthWest++;
                    NorthEast++;
                    Changing = true;
                }
                while (NorthEast > 0 && North < 0)
                {
                    NorthEast--;
                    North++;
                    NorthWest--;
                    Changing = true;
                }
                while (NorthWest < 0 && NorthEast < 0)
                {
                    NorthWest++;
                    NorthEast++;
                    North--;
                    Changing = true;
                }
                while (North < 0 && NorthWest > 0)
                {
                    North++;
                    NorthWest--;
                    NorthEast--;
                    Changing = true;
                }
                while (NorthEast < 0 && North > 0)
                {
                    NorthEast++;
                    North--;
                    NorthWest++;
                    Changing = true;
                }
            } while (Changing);

            // Jetzt ausrechnen
            return Math.Abs(North) + Math.Abs(NorthEast) + Math.Abs(NorthWest);
        }
    }
}
