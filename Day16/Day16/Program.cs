﻿using System;
using System.IO;

namespace Day16
{
    public class Program
    {
        public static void Main()
        {
            char[] Line = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p' };

            // Test
            //Line = null;
            //Line = new char[] { 'a', 'b', 'c', 'd', 'e' };

            string Input = File.ReadAllText("/Users/jakobbussas/Projects/AdventOfCode/2017/Day16/Day16/Day16.txt");

            // Test
            //Input = "s1,x3/4,pe/b";

            string[] Commands = Input.Split(',');

            // Hilfsvariablen für mehr Übersichtlichkeit
            string TempCommand;
            int TempA;
            int TempB;

            foreach (var Command in Commands)
            {
                switch (Command[0])
                {
                    case 's':
                        // Spin
                        TempCommand = Command.Substring(1);
                        TempA = Convert.ToInt32(TempCommand);

                        Spin(ref Line, TempA);
                        break;
                    case 'x':
                        // Exchange
                        TempCommand = Command.Substring(1);
                        string[] TempParts = TempCommand.Split('/');

                        TempA = Convert.ToInt32(TempParts[0]);
                        TempB = Convert.ToInt32(TempParts[1]);

                        Exchange(ref Line, TempA, TempB);
                        break;
                    case 'p':
                        // Partner
                        TempCommand = Command.Substring(1);
                        string[] TempParts2 = TempCommand.Split('/');

                        Partner(ref Line, TempParts2[0][0], TempParts2[1][0]);
                        break;
                    default:
                        throw new Exception("Unknown Command: " + Command[0]);
                }
            }

            foreach (var element in Line)
            {
                Console.Write(element);
            }
            Console.WriteLine();
        }


        // Hier ist der Wurm drin
        private static void Spin(ref char[] Line, int X)
        {
            char Swap;

            // Do X rotations
            for (int i = 0; i < X; i++)
            {
                // Perform one rotation
                Swap = Line[Line.Length - 1];
                Line[Line.Length - 1] = Line[0];
                Line[0] = Swap;

                for (int j = Line.Length - 1; j > 1; j--)
                {
                    Swap = Line[j];
                    Line[j] = Line[j - 1];
                    Line[j - 1] = Swap;
                }
            }
        }


        private static void Exchange(ref char[] Line, int A, int B)
        {
            char Swap = Line[A];
            Line[A] = Line[B];
            Line[B] = Swap;
        }


        private static void Partner(ref char[] Line, char A, char B)
        {
            // Tauschindizes suchen
            int Index1 = -1;
            int Index2 = -1;

            for (int i = 0; i < Line.Length; i++)
            {
                if (Line[i] == A)
                {
                    Index1 = i;
                }

                if (Line[i] == B)
                {
                    Index2 = i;
                }
            }

            // Tauschen
            Exchange(ref Line, Index1, Index2);
        }
    }
}
