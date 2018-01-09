using System;
using System.IO;

namespace Day5
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
            // Datei einlesen und Anweisungen in int Array abspeichern
            string[] Lines = File.ReadAllLines("/Users/jakobbussas/Projects/AdventOfCode/Day5/Day5/Day5.txt");
            int[] Commands = new int[Lines.Length];
            for (int i = 0; i < Lines.Length; i++)
            {
                Commands[i] = Convert.ToInt32(Lines[i]);
            }

            int Counter = 0;
            int Position = 0;
            int OldPosition = 0;
            while (Position < Commands.Length)
            {
                Position += Commands[Position];
                Commands[OldPosition]++;
                OldPosition = Position;
                Counter++;
            }

            Console.WriteLine(Counter);
            // 358131
        }


        public static void Part2()
        {
            // Datei einlesen und Anweisungen in int Array abspeichern
            string[] Lines = File.ReadAllLines("/Users/jakobbussas/Projects/AdventOfCode/Day5/Day5/Day5.txt");
            int[] Commands = new int[Lines.Length];
            for (int i = 0; i < Lines.Length; i++)
            {
                Commands[i] = Convert.ToInt32(Lines[i]);
            }

            int Counter = 0;
            int Position = 0;
            int OldPosition = 0;
            while (Position < Commands.Length)
            {
                Position += Commands[Position];
                Commands[OldPosition] = Commands[OldPosition] >= 3 ? Commands[OldPosition] - 1 : Commands[OldPosition] + 1;
                OldPosition = Position;
                Counter++;
            }

            Console.WriteLine(Counter);
            // 358131
        }


        private static void Print(int[] array)
        {
            foreach(var element in array) {
                Console.Write(element +", ");
            }
            Console.WriteLine();
        }
    }
}
