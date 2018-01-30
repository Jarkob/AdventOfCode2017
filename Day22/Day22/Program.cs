using System;
using System.IO;
using System.Collections.Generic;

namespace Day22
{
    class MainClass
    {
        public static void Main()
        {
            Part1();
            Part2();
        }


        public static void Part1()
        {
            string[] Input = File.ReadAllLines("../../Day22.txt");

            // Test
            //Input = null;
            //Input = new string[]
            //{
            //".........",
            //".........",
            //".........",
            //".....#...",
            //"...#.....",
            //".........",
            //".........",
            //"........."
            //};

            IDictionary<(int, int), char> Grid = new Dictionary<(int, int), char>();

            for (int i = 0; i < Input.Length; i++)
            {
                for (int j = 0; j < Input[i].Length; j++)
                {
                    Grid.Add((j, i), Input[i][j]);
                }
            }

            // Jetzt moven
            int X = Input[0].Length / 2;
            int Y = Input.Length / 2;
            string Direction = "up";

            int Infections = 0;

            for (int i = 0; i < 10000; i++)
            {
                if (!Grid.ContainsKey((X, Y)))
                {
                    Grid.Add((X, Y), '.');
                }

                switch (Grid[(X, Y)])
                {
                    case '#':
                        switch (Direction)
                        {
                            case "up":
                                Direction = "right";
                                break;
                            case "down":
                                Direction = "left";
                                break;
                            case "left":
                                Direction = "up";
                                break;
                            case "right":
                                Direction = "down";
                                break;
                            default:
                                throw new Exception("Unknown direction");
                        }

                        Grid[(X, Y)] = '.';
                        break;
                    case '.':
                        switch (Direction)
                        {
                            case "up":
                                Direction = "left";
                                break;
                            case "down":
                                Direction = "right";
                                break;
                            case "left":
                                Direction = "down";
                                break;
                            case "right":
                                Direction = "up";
                                break;
                            default:
                                throw new Exception("Unknown direction");
                        }

                        Infections++;

                        Grid[(X, Y)] = '#';
                        break;
                    default:
                        throw new Exception("Unknown state");
                }

                // Moven
                switch (Direction)
                {
                    case "up":
                        Y--;
                        break;
                    case "down":
                        Y++;
                        break;
                    case "left":
                        X--;
                        break;
                    case "right":
                        X++;
                        break;
                    default:
                        throw new Exception("Unknown direction");
                }
            }

            Console.WriteLine("Anzahl Infektionen: " + Infections);
            // 5460
        }


        public static void Part2()
        {
            string[] Input = File.ReadAllLines("../../Day22.txt");

            // Test
            //Input = null;
            //Input = new string[]
            //{
            //".........",
            //".........",
            //".........",
            //".....#...",
            //"...#.....",
            //".........",
            //".........",
            //"........."
            //};

            IDictionary<(int, int), char> Grid = new Dictionary<(int, int), char>();

            for (int i = 0; i < Input.Length; i++)
            {
                for (int j = 0; j < Input[i].Length; j++)
                {
                    Grid.Add((j, i), Input[i][j]);
                }
            }

            // Jetzt moven
            int X = Input[0].Length / 2;
            int Y = Input.Length / 2;
            string Direction = "up";

            int Infections = 0;

            for (int i = 0; i < 10000000; i++)
            {
                if (!Grid.ContainsKey((X, Y)))
                {
                    Grid.Add((X, Y), '.');
                }

                switch (Grid[(X, Y)])
                {
                    case '#':
                        switch (Direction)
                        {
                            case "up":
                                Direction = "right";
                                break;
                            case "down":
                                Direction = "left";
                                break;
                            case "left":
                                Direction = "up";
                                break;
                            case "right":
                                Direction = "down";
                                break;
                            default:
                                throw new Exception("Unknown direction");
                        }

                        Grid[(X, Y)] = 'F';
                        break;
                    case '.':
                        switch (Direction)
                        {
                            case "up":
                                Direction = "left";
                                break;
                            case "down":
                                Direction = "right";
                                break;
                            case "left":
                                Direction = "down";
                                break;
                            case "right":
                                Direction = "up";
                                break;
                            default:
                                throw new Exception("Unknown direction");
                        }

                        Grid[(X, Y)] = 'W';
                        break;
                    case 'W':
                        Grid[(X, Y)] = '#';
                        Infections++;
                        break;
                    case 'F':
                        // Reverse direction
                        switch(Direction)
                        {
                            case "up":
                                Direction = "down";
                                break;
                            case "down":
                                Direction = "up";
                                break;
                            case "left":
                                Direction = "right";
                                break;
                            case "right":
                                Direction = "left";
                                break;
                            default:
                                throw new Exception("Unknown direction");
                        }

                        Grid[(X, Y)] = '.';
                        break;
                    default:
                        throw new Exception("Unknown state");
                }

                // Moven
                switch (Direction)
                {
                    case "up":
                        Y--;
                        break;
                    case "down":
                        Y++;
                        break;
                    case "left":
                        X--;
                        break;
                    case "right":
                        X++;
                        break;
                    default:
                        throw new Exception("Unknown direction");
                }
            }

            Console.WriteLine("Anzahl Infektionen: " + Infections);
            // 2511702
        }


        private static void PrintGrid(IDictionary<(int, int), char> Grid)
        {
            // Von oben links nach unten rechts
            // Erst Maximalwerte herausfinden
            int MaxX = 0;
            int MaxY = 0;
            int MinX = 0;
            int MinY = 0;

            foreach (var element in Grid)
            {
                if (element.Key.Item1 > MaxX)
                {
                    MaxX = element.Key.Item1;
                }
                if (element.Key.Item1 < MinX)
                {
                    MinX = element.Key.Item1;
                }
                if (element.Key.Item2 > MaxY)
                {
                    MaxY = element.Key.Item2;
                }
                if (element.Key.Item2 < MinY)
                {
                    MinY = element.Key.Item2;
                }
            }


            // Jetzt anzeigen
            for (int i = MinY; i <= MaxY; i++)
            {
                for (int j = MinX; j <= MaxX; j++)
                {
                    if (!Grid.ContainsKey((j, i)))
                    {
                        Grid.Add((j, i), '.');
                    }
                    Console.Write(Grid[(j, i)]);
                }
                Console.WriteLine();
            }
        }
    }
}
