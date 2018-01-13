using System;
using System.IO;
using System.Collections.Generic;

namespace Day18
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            // Get input
            string[] Input = File.ReadAllLines("/Users/jakobbussas/Projects/AdventOfCode/2017/Day18/Day18/Day18.txt");
            string[][] Commands = new string[Input.Length][];

            // Test
            //Input = null;
            //Input = new string[] { "set a 1", "add a 2", "mul a a", "mod a 5", "snd a", "set a 0", "rcv a", "jgz a -1", "set a 1", "jgz a -2" };

            for (int i = 0; i < Input.Length; i++)
            {
                Commands[i] = Input[i].Split(' ');
            }

            // Set up registers
            IDictionary<char, int> Registers = new Dictionary<char, int>();
            Registers.Add('a', 0);
            Registers.Add('b', 0);
            Registers.Add('c', 0);
            Registers.Add('d', 0);
            Registers.Add('e', 0);
            Registers.Add('f', 0);
            Registers.Add('g', 0);
            Registers.Add('h', 0);
            Registers.Add('i', 0);
            Registers.Add('j', 0);
            Registers.Add('k', 0);
            Registers.Add('l', 0);
            Registers.Add('m', 0);
            Registers.Add('n', 0);
            Registers.Add('o', 0);
            Registers.Add('p', 0);

            int LastSound = 0;


            // Arbeiten
            int Index = 0;
            while (Index < Commands.Length && Index > -1)
            {
                // debug
                switch (Commands[Index][0])
                {
                    case "snd":
                        Snd(ref Registers, Commands[Index][1][0], ref LastSound);
                        break;
                    case "set":
                        if (int.TryParse(Commands[Index][2], out var n))
                        {
                            Set(ref Registers, Commands[Index][1][0], Convert.ToInt32(Commands[Index][2]));
                        }
                        else
                        {
                            Set(ref Registers, Commands[Index][1][0], Commands[Index][2][0]);
                        }
                        break;
                    case "add":
                        if (int.TryParse(Commands[Index][2], out var n0))
                        {
                            Add(ref Registers, Commands[Index][1][0], Convert.ToInt32(Commands[Index][2]));
                        }
                        else
                        {
                            Add(ref Registers, Commands[Index][1][0], Commands[Index][2][0]);
                        }
                        break;
                    case "mul":
                        if (int.TryParse(Commands[Index][2], out var n1))
                        {
                            Mul(ref Registers, Commands[Index][1][0], Convert.ToInt32(Commands[Index][2]));
                        }
                        else
                        {
                            Mul(ref Registers, Commands[Index][1][0], Commands[Index][2][0]);
                        }
                        break;
                    case "mod":
                        if (int.TryParse(Commands[Index][2], out var n2))
                        {
                            Mod(ref Registers, Commands[Index][1][0], Convert.ToInt32(Commands[Index][2]));
                        }
                        else
                        {
                            Mod(ref Registers, Commands[Index][1][0], Commands[Index][2][0]);
                        }
                        break;
                    case "rcv":
                        Rcv(ref Registers, Commands[Index][1][0], LastSound);
                        break;
                    case "jgz":
                        // debug
                        Console.WriteLine("Jgz commando: "+ Commands[Index][0] +" "+ Commands[Index][1] +" "+ Commands[Index][2]);

                        // Hier ist der Wurm drin
                        // Wenn Y numerisch ist
                        if (int.TryParse(Commands[Index][2], out var n3))
                        {
                            // Wenn X numerisch ist
                            if (int.TryParse(Commands[Index][1], out var n4))
                            {
                                // debug
                                Console.WriteLine("Result: Y numerisch, X numerisch");

                                if (Convert.ToInt32(Commands[Index][1]) > 0)
                                {
                                    Index += Convert.ToInt32(Commands[Index][2]);
                                    Index--; // Um das am Ende zu neutralisieren
                                }
                            }
                            // Wenn X nicht numerisch ist
                            else
                            {
                                // debug
                                Console.WriteLine("Result: Y numerisch, X nicht numerisch");

                                if (Jgz(Registers, Commands[Index][1][0]))
                                {
                                    Index += Convert.ToInt32(Commands[Index][2]);
                                    Index--; // Um das am Ende zu neutralisieren
                                }
                            }
                        }
                        // Wenn Y nicht numerisch ist
                        else
                        {
                            // Wenn X numerisch ist
                            if (int.TryParse(Commands[Index][1], out var n5))
                            {
                                // debug
                                Console.WriteLine("Result: Y nicht numerisch, X numerisch");

                                if (Convert.ToInt32(Commands[Index][1]) > 0)
                                {
                                    Index += Registers[Commands[Index][2][0]];
                                    Index--; // Um das am Ende zu neutralisieren
                                }
                            }
                            // Wenn X nicht numerisch ist
                            else
                            {
                                // debug
                                Console.WriteLine("Result: Y nicht numerisch, X nicht numerisch");

                                if (Jgz(Registers, Commands[Index][1][0]))
                                {
                                    Index += Registers[Commands[Index][2][0]];
                                    Index--; // Um das am Ende zu neutralisieren
                                }
                            }
                        }
                        break;
                    default:
                        throw new Exception("Unknown command: " + Commands[Index][0]);
                }

                Index++; // tricky
            }

            // 3675 too high
        }


        private static void Snd(ref IDictionary<char, int> Registers, char X, ref int LastSound)
        {
            LastSound = Registers[X];
        }


        private static void Set(ref IDictionary<char, int> Registers, char X, int Y)
        {
            Registers[X] = Y;
        }

        private static void Set(ref IDictionary<char, int> Registers, char X, char Y)
        {
            Registers[X] = Registers[Y];
        }


        private static void Add(ref IDictionary<char, int> Registers, char X, int Y)
        {
            Registers[X] += Y;
        }

        private static void Add(ref IDictionary<char, int> Registers, char X, char Y)
        {
            Registers[X] += Registers[Y];
        }


        private static void Mul(ref IDictionary<char, int> Registers, char X, int Y)
        {
            Registers[X] *= Y;
        }

        private static void Mul(ref IDictionary<char, int> Registers, char X, char Y)
        {
            Registers[X] *= Registers[Y];
        }


        private static void Mod(ref IDictionary<char, int> Registers, char X, int Y)
        {
            Registers[X] %= Y;
        }

        private static void Mod(ref IDictionary<char, int> Registers, char X, char Y)
        {
            Registers[X] %= Registers[Y];
        }


        private static void Rcv(ref IDictionary<char, int> Registers, char X, int LastSound)
        {
            if (Registers[X] != 0)
            {
                Registers[X] = LastSound;
                throw new Exception("First Last Sound: " + LastSound);
            }
        }


        private static bool Jgz(IDictionary<char, int> Registers, char X)
        {
            return Registers[X] > 0;
        }
    }
}
