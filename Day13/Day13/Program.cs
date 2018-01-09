using System;
using System.IO;

namespace Day13
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Part1(); // Funktioniert nicht mehr, muss wenn dann überarbeitet werden; Edit: Funktioniert wieder :)
            Part2();
        }


        public static void Part1()
        {
            string[] Lines = File.ReadAllLines("/Users/jakobbussas/Projects/AdventOfCode/Day13/Day13/Day13.txt");

            int Length = Convert.ToInt32(Lines[Lines.Length - 1].Split(':')[0]) + 1;

            int[][] ConvertedLines = new int[Lines.Length][];

            int FirstElement;
            int SecondElement;

            for (int i = 0; i < Lines.Length; i++)
            {
                FirstElement = Convert.ToInt32(Lines[i].Split(':')[0]);
                SecondElement = Convert.ToInt32(Lines[i].Split(':')[1].Trim());
                ConvertedLines[i] = new int[] { FirstElement, SecondElement };
            }

            // Firewall erstellen
            int[][] Firewall = new int[Length][];
            foreach (var Line in ConvertedLines)
            {
                Firewall[Line[0]] = new int[Line[1]];
                Firewall[Line[0]][0] = 1;
            }

            // Durchrunnen
            int Severity = 0;

            for (int i = 0; i < Firewall.Length; i++)
            {
                if (Firewall[i] != null)
                {
                    if (Firewall[i][0] != 0)
                    {
                        Severity += i * Firewall[i].Length;
                    }
                }

                // Moven
                MoveScanners(Firewall);
            }

            Console.WriteLine("Severity: " + Severity);
            // 22934 is too high
            // 6070 still too high
            // 584 too low
            // 1300
        }


        public static void Part2()
        {
            // Input formatieren etc.
            string[] Lines = File.ReadAllLines("/Users/jakobbussas/Projects/AdventOfCode/Day13/Day13/Day13.txt");

            //Lines = null;
            //Lines = new string[] { "0: 3", "1: 2", "4: 4", "6: 4" };

            int Length = Convert.ToInt32(Lines[Lines.Length - 1].Split(':')[0]) + 1;

            int[][] ConvertedLines = new int[Lines.Length][];

            int FirstElement;
            int SecondElement;

            for (int i = 0; i < Lines.Length; i++)
            {
                FirstElement = Convert.ToInt32(Lines[i].Split(':')[0]);
                SecondElement = Convert.ToInt32(Lines[i].Split(':')[1].Trim());
                ConvertedLines[i] = new int[] { FirstElement, SecondElement };
            }


            // Firewall erstellen
            int[][] Firewall = new int[Length][];
            foreach (var Line in ConvertedLines)
            {
                Firewall[Line[0]] = new int[Line[1]];
                Firewall[Line[0]][0] = 1;
            }


            // Jetzt mit Delay durchlaufen

            for (int Offset = 0; true; Offset++)
            {
                // Anfangszustand der Firewall speichern
                int[][] BackupFirewall = Copy<int>(Firewall);

                // Versuchen durchzulaufen
                bool Caught = false;
                for (int i = 0; i < Firewall.Length; i++) {
                    if (Firewall[i] != null)
                    {
                        if (Firewall[i][0] != 0)
                        {
                            // Caught
                            Console.WriteLine("You've been caught at {0} with Offset {1}", i, Offset);
                            Caught = true;
                            break;
                        }
                    }

                    // Scanner bewegen
                    Firewall = MoveScanners(Firewall);
                }


                // Wenn nicht caugth ist ein Weg gefunden
                if(!Caught) {
                    Console.WriteLine("HEUREKA: {0}", Offset);
                    // 3870382 Ich bin der absolute Gott!!!
                    break;
                }

                // Da nicht caught muss alles für den nächsten Schleifendurchlauf gespeichert werden
                Firewall = null;
                Firewall = Copy<int>(BackupFirewall);
                Firewall = MoveScanners(Firewall);
                Console.WriteLine("Log: Offset: "+ Offset);
            }
        }


        public static int[][] MoveScanners(int[][] Firewall)
        {
            for (int i = 0; i < Firewall.Length; i++)
            {
                if (Firewall[i] != null)
                {
                    if (Firewall[i][0] != 0)
                    {
                        Firewall[i][0] = 0;
                        Firewall[i][1] = 1;
                    }
                    else if (Firewall[i][Firewall[i].Length - 1] != 0)
                    {
                        Firewall[i][Firewall[i].Length - 1] = 0;
                        Firewall[i][Firewall[i].Length - 2] = -1;
                    }
                    else
                    {
                        for (int j = 0; j < Firewall[i].Length; j++)
                        {
                            if (Firewall[i][j] != 0)
                            {
                                switch (Firewall[i][j])
                                {
                                    case 1:
                                        Firewall[i][j + 1] = 1;
                                        break;
                                    case -1:
                                        Firewall[i][j - 1] = -1;
                                        break;
                                    default:
                                        throw new Exception("Keine Ahnung");
                                }
                                Firewall[i][j] = 0;

                                break;
                            }
                        }
                    }
                }
            }
            return Firewall;
        }


        private static void PrintFirewall(int[][] Firewall)
        {
            foreach (var row in Firewall)
            {
                if (row != null)
                {
                    foreach (var element in row)
                    {
                        Console.Write(element != 0 ? "[S] " : "[ ] ");
                    }
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine(".");
                }
            }
        }

        private static void PrintDirections(string[] Directions)
        {
            foreach (var element in Directions)
            {
                Console.WriteLine(element);
            }
        }

        private static T[] Copy<T>(T[] array)
        {
            T[] copy = new T[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                copy[i] = array[i];
            }
            return copy;
        }

        private static T[][] Copy<T>(T[][] array)
        {
            T[][] copy = new T[array.Length][];
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != null)
                {
                    copy[i] = new T[array[i].Length];
                    for (int j = 0; j < array[i].Length; j++)
                    {
                        copy[i][j] = array[i][j];
                    }
                }
            }
            return copy;
        }
    }
}
