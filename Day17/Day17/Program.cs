using System;
using System.Collections.Generic;

namespace Day17
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
            int Input = 356;

            List<int> Spinlock = new List<int>();
            Spinlock.Add(0);

            int CurrentPosition = 0;

            for (int i = 1; i < 2018; i++)
            {
                // Move circular through spinlock the amount of times of the puzzle input
                for (int j = 0; j < Input; j++)
                {
                    CurrentPosition = CurrentPosition == Spinlock.Count - 1 ? 0 : CurrentPosition + 1;
                }

                // Insert i and make index new currentPosition
                CurrentPosition++;
                Spinlock.Insert(CurrentPosition, i);
            }

            // Jetzt 2017 finden
            for (int i = 0; i < Spinlock.Count; i++)
            {
                if (Spinlock[i] == 2017)
                {
                    if (i == Spinlock.Count - 1)
                    {
                        Console.WriteLine(Spinlock[0]);
                    }
                    else
                    {
                        Console.WriteLine(Spinlock[i + 1]);
                    }
                }
            }
            // 808
        }


        public static void Part2()
        {
            int Input = 356;

            List<int> Spinlock = new List<int>();
            Spinlock.Add(0);

            int ListLength = 1;
            int CurrentPosition = 0;

            Console.WriteLine("Inserting values...");
            for (int i = 1; i <= 50000000; i++)
            {
                // Move circular through spinlock the amount of times of the puzzle input
                for (int j = 0; j < Input; j++)
                {
                    CurrentPosition = CurrentPosition == ListLength - 1 ? 0 : CurrentPosition + 1;
                }

                // Insert i and make index new currentPosition
                CurrentPosition++;
                ListLength++;

                if(CurrentPosition == 1) {
                    Spinlock.Insert(CurrentPosition, i);
                }
            }

            // Jetzt 0 finden
            Console.WriteLine(Spinlock[0]);
            Console.WriteLine(Spinlock[1]);

            // Keine Chance die Berechnung ist viel zu aufwändig
            // Idee ich inserte nur wenn i = 0 und erhöhe ansonsten einfach nur die Listenlänge, welche ich in einer zusätzlichen Variable zwischenspeichere

            // 47465686
        }
    }
}
