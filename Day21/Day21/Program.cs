﻿using System;
using System.IO;
using System.Collections.Generic;

namespace Day21
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string[] Rules = File.ReadAllLines("../../Day21.txt");

            string[][] FormattedRules = new string[Rules.Length][];

            for (int i = 0; i < Rules.Length; i++)
            {
                FormattedRules[i] = Rules[i].Split('>');
                FormattedRules[i][0] = FormattedRules[i][0].Replace(" =", "");
                FormattedRules[i][1] = FormattedRules[i][1].Replace(" ", "");
            }

            // Also erst Mergen
            // dann splitten
            // dann alle enhancen
            // dann mergen


            string Pattern = ".#./..#/###";
            string[] Patterns = new string[] { Pattern };

            for (int i = 0; i < 18; i++)
            {
                Console.WriteLine("i = {0}; Patterns.Length = {1}; Pattern.Length = {2}", i, Patterns.Length, Pattern.Length);
                Console.WriteLine("on: "+ GetOn(Pattern));
                Patterns = SplitPattern(Pattern);

                for (int j = 0; j < Patterns.Length; j++)
                {
                    Patterns[j] = EnhancePattern(FormattedRules, Patterns[j]);
                }

                Pattern = MergePattern(Patterns);
            }

            int Count = GetOn(Pattern);
            Console.WriteLine(Count);
            // Part1 205
            // Part2 3389823
        }


        private static string EnhancePattern(string[][] FormattedRules, string Pattern)
        {
            // Alle Permutationen durchgehen
            if (Pattern.Length == 5)
            {
                // Nur drehen 3 Mal
                for (int i = 0; i < 4; i++)
                {
                    Pattern = RotatePattern(Pattern);

                    // Jetzt mit Mustern vergleichen
                    foreach (var FormattedRule in FormattedRules)
                    {
                        if (Pattern == FormattedRule[0])
                        {
                            return FormattedRule[1];
                        }
                    }
                }
            }
            else if (Pattern.Length == 11)
            {
                // 3 Mal drehen 1 Mal flippen und 3 Mal drehen
                for (int i = 0; i < 4; i++)
                {
                    Pattern = RotatePattern(Pattern);

                    // Jetzt mit Mustern vergleichen
                    foreach (var FormattedRule in FormattedRules)
                    {
                        if (Pattern == FormattedRule[0])
                        {
                            return FormattedRule[1];
                        }
                    }
                }

                // Flippen
                Pattern = FlipPattern(Pattern);

                for (int i = 0; i < 4; i++)
                {
                    Pattern = RotatePattern(Pattern);

                    // Jetzt mit Mustern vergleichen
                    foreach (var FormattedRule in FormattedRules)
                    {
                        if (Pattern == FormattedRule[0])
                        {
                            return FormattedRule[1];
                        }
                    }
                }
            }
            else
            {
                throw new Exception("Unmatching Length");
            }

            throw new Exception("Keine passende Regel gefunden");
        }


        // Immer im Uhrzeigersinn
        private static string RotatePattern(string Pattern)
        {
            if (Pattern.Length == 5)
            {
                return Pattern[3] + "" + Pattern[0] + "/" + Pattern[4] + Pattern[1];
            }
            else if (Pattern.Length == 11)
            {
                return Pattern[8] + "" + Pattern[4] + "" + Pattern[0] + "/" + Pattern[9] + "" + Pattern[5] + "" + Pattern[1] + "/" + Pattern[10] + "" + Pattern[6] + "" + Pattern[2];
            }
            else
            {
                throw new Exception("Unmatching length");
            }
        }


        // Nur für 3 gedacht
        private static string FlipPattern(string Pattern)
        {
            return Pattern[8] + "" + Pattern[9] + "" + Pattern[10] + "/" + Pattern[4] + "" + Pattern[5] + "" + Pattern[6] + "/" + Pattern[0] + "" + Pattern[1] + "" + Pattern[2];
        }


        private static string[] SplitPattern(string Pattern)
        {
            string[] FormattedPattern = Pattern.Split('/');
            int Length = FormattedPattern.Length;

            List<string> NewPatterns = new List<string>();

            if (Length % 2 == 0)
            {
                // Split into 2x2 Patterns
                for (int i = 0; i < Length; i += 2)
                {
                    // Erste und zweite Reihe hinzufügen
                    for (int j = 0; j < Length; j += 2)
                    {
                        NewPatterns.Add(FormattedPattern[i][j] + "" + FormattedPattern[i][j + 1] + "/" + FormattedPattern[i + 1][j] + "" + FormattedPattern[i + 1][j + 1]);
                    }
                }
            }
            else if (Length % 3 == 0)
            {
                // Split into 3x3 Patterns
                for (int i = 0; i < Length; i += 3)
                {
                    for (int j = 0; j < Length; j += 3)
                    {
                        NewPatterns.Add(
                            FormattedPattern[i][j] + "" + FormattedPattern[i][j + 1] + "" + FormattedPattern[i][j + 2] + "/" +
                            FormattedPattern[i + 1][j] + "" + FormattedPattern[i + 1][j + 1] + "" + FormattedPattern[i + 1][j + 2] + "/" +
                            FormattedPattern[i + 2][j] + "" + FormattedPattern[i + 2][j + 1] + "" + FormattedPattern[i + 2][j + 2]
                        );
                    }
                }
            }
            else
            {
                throw new Exception("Unknown length");
            }

            return NewPatterns.ToArray();
        }


        private static string MergePattern(string[] Patterns)
        {
            int PatternLength = 0;
            switch (Patterns[0].Length)
            {
                case 5:
                    PatternLength = 2;
                    break;
                case 11:
                    PatternLength = 3;
                    break;
                case 19:
                    PatternLength = 4;
                    break;
                default:
                    throw new Exception("Unknown Length");

            }
            int Length = (int)Math.Sqrt(Patterns.Length);
            int SideLength = Length * PatternLength;

            //string Pattern = "";

            // Die Patterns müssen irgendwie im Quadrat angeordnet werden
            // Dazu ist es sinnvoll sie zuerst im Quadrat anzuordnen (evtl.)
            int PatternsIndex = 0;
            string[][] NewPatterns = new string[Length][];

            for (int i = 0; i < NewPatterns.Length; i++)
            {
                NewPatterns[i] = new string[Length];

                for (int j = 0; j < NewPatterns[i].Length; j++)
                {
                    NewPatterns[i][j] = Patterns[PatternsIndex];
                    PatternsIndex++;
                }
            }
            // Das funktioniert schon mal

            string NewPattern = "";

            if (PatternLength == 2)
            {
                for (int i = 0; i < Length; i++)
                {
                    for (int j = 0; j < NewPatterns[i].Length; j++)
                    {
                        NewPattern += NewPatterns[i][j].Substring(0, 2);
                    }

                    NewPattern += "/";

                    for (int k = 0; k < NewPatterns[i].Length; k++)
                    {
                        NewPattern += NewPatterns[i][k].Substring(3);
                    }

                    NewPattern += "/";
                }
            }
            else if (PatternLength == 3)
            {
                for (int i = 0; i < Length; i++)
                {
                    for (int j = 0; j < NewPatterns[i].Length; j++)
                    {
                        NewPattern += NewPatterns[i][j].Substring(0, 3);
                    }

                    NewPattern += "/";

                    for (int k = 0; k < NewPatterns[i].Length; k++)
                    {
                        NewPattern += NewPatterns[i][k].Substring(4, 3);
                    }

                    NewPattern += "/";

                    for (int l = 0; l < NewPatterns[i].Length; l++)
                    {
                        NewPattern += NewPatterns[i][l].Substring(8);
                    }

                    NewPattern += "/";
                }
            }
            else
            {
                for (int i = 0; i < Length; i++)
                {
                    for (int j = 0; j < NewPatterns[i].Length; j++)
                    {
                        NewPattern += NewPatterns[i][j].Substring(0, 4);
                    }

                    NewPattern += "/";

                    for (int k = 0; k < NewPatterns[i].Length; k++)
                    {
                        NewPattern += NewPatterns[i][k].Substring(5, 4);
                    }

                    NewPattern += "/";

                    for (int l = 0; l < NewPatterns[i].Length; l++)
                    {
                        NewPattern += NewPatterns[i][l].Substring(10, 4);
                    }

                    NewPattern += "/";

                    for (int m = 0; m < NewPatterns[i].Length; m++)
                    {
                        NewPattern += NewPatterns[i][m].Substring(15);
                    }

                    NewPattern += "/";
                }
            }

            // Am Ende das letzte Zeichen wegnehmen
            NewPattern = NewPattern.Remove(NewPattern.Length - 1);

            return NewPattern;
        }

        private static void PrintPattern(string Pattern)
        {
            foreach (var element in Pattern)
            {
                if (element == '/')
                {
                    Console.WriteLine();
                }
                else
                {
                    Console.Write(element);
                }
            }
            Console.WriteLine();
        }

        private static int GetOn(string Pattern)
        {
            int On = 0;
            foreach (var element in Pattern)
            {
                if (element == '#')
                {
                    On++;
                }
            }
            return On;
        }
    }
}
