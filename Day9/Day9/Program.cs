using System;
using System.IO;

namespace Day9
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            //Part1();
            Part2();
        }


        public static void Part1()
        {
            Console.WriteLine("Part1:");
            string Stream = File.ReadAllText("/Users/jakobbussas/Projects/AdventOfCode/Day9/Day9/Day9.txt");

            int StreamValue = GetScore(Stream);

            Console.WriteLine("Der Stream: \"" + Stream + "\"");
            Console.WriteLine("hat den Wert: " + StreamValue);
            // 15922
        }


        public static void Part2()
        {
            Console.WriteLine("Part2:");
            string Stream = File.ReadAllText("/Users/jakobbussas/Projects/AdventOfCode/Day9/Day9/Day9.txt");

            int StreamValue = GetNonCanceledCharacters(Stream);

            Console.WriteLine("Der Stream: \"" + Stream + "\"");
            Console.WriteLine("hat den Wert: " + StreamValue);
        }


        public static int GetScore(string input)
        {
            int Score = 0;

            bool Ignore = false;
            char LastBracket = ' ';
            int AmountOfOpenGroups = 0;

            int InputLength = input.Length;
            for (int i = 0; i < InputLength; i++)
            {
                if (!Ignore)
                {
                    switch (input[i])
                    {
                        case '{':
                            if (LastBracket == '}')
                            {
                                AmountOfOpenGroups++;
                            }
                            else
                            {
                                AmountOfOpenGroups++;
                            }

                            LastBracket = '{';
                            break;
                        case '}':
                            if (LastBracket == '}')
                            {
                                Score += AmountOfOpenGroups;
                                AmountOfOpenGroups--;
                            }
                            else
                            {
                                Score += AmountOfOpenGroups;
                                AmountOfOpenGroups--;
                            }

                            LastBracket = '}';
                            break;
                        case '<':
                            Ignore = true;
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    // Garbage
                    if (input[i] == '!')
                    {
                        i++;
                        continue;
                    }
                    else if (input[i] == '>')
                    {
                        Ignore = false;
                    }
                }
            }

            return Score;
        }


        public static int GetNonCanceledCharacters(string input)
        {
            int Score = 0;

            bool Ignore = false;

            int InputLength = input.Length;
            for (int i = 0; i < InputLength; i++)
            {
                if (Ignore)
                {
                    // Garbage
                    if (input[i] == '!')
                    {
                        i++;
                        continue;
                    }
                    else if (input[i] == '>')
                    {
                        Ignore = false;
                    }
                    else
                    {
                        Score++;
                    }
                } else {
                    if (input[i] == '<')
                    {
                        Ignore = true;
                    }
                }
            }

            return Score;
        }
    }
}
