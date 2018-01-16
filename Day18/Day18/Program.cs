using System;
using System.IO;
using System.Collections.Generic;

namespace Day18
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            // Part1();
            Part2();
        }


        public static void Part1()
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
            IDictionary<char, long> Registers = new Dictionary<char, long>();
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

            Console.WriteLine("Result: "+ GetFirstRcv(Registers, Commands));
            // 3675 too high
            // 3188
        }


        public static void Part2()
        {
            // Get input
            string[] Input;// = File.ReadAllLines("/Users/jakobbussas/Projects/AdventOfCode/2017/Day18/Day18/Day18.txt");

            // Test
            Input = null;
            Input = new string[] { "set a 1", "add a 2", "mul a a", "mod a 5", "snd a", "set a 0", "rcv a", "jgz a -1", "set a 1", "jgz a -2" };
			
			string[][] Commands = new string[Input.Length][];

            for (int i = 0; i < Input.Length; i++)
            {
                Commands[i] = Input[i].Split(' ');
            }

            // Set up registers
            IDictionary<char, long> Registers0 = new Dictionary<char, long>();
            Registers0.Add('a', 0);
            Registers0.Add('b', 0);
            Registers0.Add('c', 0);
            Registers0.Add('d', 0);
            Registers0.Add('e', 0);
            Registers0.Add('f', 0);
            Registers0.Add('g', 0);
            Registers0.Add('h', 0);
            Registers0.Add('i', 0);
            Registers0.Add('j', 0);
            Registers0.Add('k', 0);
            Registers0.Add('l', 0);
            Registers0.Add('m', 0);
            Registers0.Add('n', 0);
            Registers0.Add('o', 0);
            Registers0.Add('p', 0);
			
			IDictionary<char, long> Registers1 = new Dictionary<char, long>();
			Registers1.Add('a', 0);
            Registers1.Add('b', 0);
            Registers1.Add('c', 0);
            Registers1.Add('d', 0);
            Registers1.Add('e', 0);
            Registers1.Add('f', 0);
            Registers1.Add('g', 0);
            Registers1.Add('h', 0);
            Registers1.Add('i', 0);
            Registers1.Add('j', 0);
            Registers1.Add('k', 0);
            Registers1.Add('l', 0);
            Registers1.Add('m', 0);
            Registers1.Add('n', 0);
            Registers1.Add('o', 0);
            Registers1.Add('p', 0);

            int LastSound = 0;

            for (int i = 0; i < Commands.Length; i++)
            {
                // debug
                //PrintRegister(Registers);

                switch (Commands[i][0])
                {
                    case "snd":
                    //LastSound = (int)Registers[Commands[i][1][0]];
                    // Dies muss geändert werden
                    break;
                    case "set":
                    //Registers[Commands[i][1][0]] = int.TryParse(Commands[i][2], out var t) ? Convert.ToInt32(Commands[i][2]) : Registers[Commands[i][2][0]];
                    break;
                    case "add":
                    //Registers[Commands[i][1][0]] += int.TryParse(Commands[i][2], out var t0) ? Convert.ToInt32(Commands[i][2]) : Registers[Commands[i][2][0]];
                    break;
                    case "mul":
                    //Registers[Commands[i][1][0]] *= int.TryParse(Commands[i][2], out var t1) ? Convert.ToInt32(Commands[i][2]) : Registers[Commands[i][2][0]];
                    break;
                    case "mod":
                    //Registers[Commands[i][1][0]] %= int.TryParse(Commands[i][2], out var t2) ? Convert.ToInt32(Commands[i][2]) : Registers[Commands[i][2][0]];
                    break;
                    case "rcv":
                    //if (Registers[Commands[i][1][0]] != 0)
                    //{
                    //	Registers[Commands[i][1][0]] = LastSound;
                    //}
                    // und dies auch
                    break;
                    case "jgz":
                    bool Continue = false;

                    if (int.TryParse(Commands[i][1], out var n0))
                    {
                        Continue = Convert.ToInt32(Commands[i][1]) > 0;
                    }
                    else
                    {
                        //Continue = Registers[Commands[i][1][0]] > 0;
                    }

                    if (Continue)
                    {
                        if (int.TryParse(Commands[i][2], out var n1))
                        {
                            i += Convert.ToInt32(Commands[i][2]);
                        }
                        else
                        {
                            //i += (int)Registers[Commands[i][2][0]];
                        }

                        i--;
                    }
                    break;
                    default:
                    throw new Exception("Unknown command: " + Commands[i][0]);
                }
            }
        }


        private static int GetFirstRcv(IDictionary<char, long> Registers, string[][] Commands)
        {
            int LastSound = 0;

            for (int i = 0; i < Commands.Length; i++)
            {
                // debug
                //PrintRegister(Registers);

                switch (Commands[i][0])
                {
                    case "snd":
                    LastSound = (int)Registers[Commands[i][1][0]];
                    break;
                    case "set":
                    Registers[Commands[i][1][0]] = int.TryParse(Commands[i][2], out var t)
                        ? Convert.ToInt32(Commands[i][2])
                        : Registers[Commands[i][2][0]];
                    break;
                    case "add":
                    Registers[Commands[i][1][0]] += int.TryParse(Commands[i][2], out var t0)
                        ? Convert.ToInt32(Commands[i][2])
                        : Registers[Commands[i][2][0]];
                    break;
                    case "mul":
                    Registers[Commands[i][1][0]] *= int.TryParse(Commands[i][2], out var t1)
                        ? Convert.ToInt32(Commands[i][2])
                        : Registers[Commands[i][2][0]];
                    break;
                    case "mod":
                    Registers[Commands[i][1][0]] %= int.TryParse(Commands[i][2], out var t2)
                        ? Convert.ToInt32(Commands[i][2])
                        : Registers[Commands[i][2][0]];
                    break;
                    case "rcv":
                    if (Registers[Commands[i][1][0]] != 0)
                    {
                        Registers[Commands[i][1][0]] = LastSound;
                        return LastSound;
                    }
                    break;
                    case "jgz":
                    bool Continue = false;

                    if (int.TryParse(Commands[i][1], out var n0))
                    {
                        Continue = Convert.ToInt32(Commands[i][1]) > 0;
                    }
                    else
                    {
                        Continue = Registers[Commands[i][1][0]] > 0;
                    }

                    if (Continue)
                    {
                        if (int.TryParse(Commands[i][2], out var n1))
                        {
                            i += Convert.ToInt32(Commands[i][2]);
                        }
                        else
                        {
                            i += (int)Registers[Commands[i][2][0]];
                        }

                        i--;
                    }
                    break;
                    default:
                    throw new Exception("Unknown command: " + Commands[i][0]);
                }
            }
            throw new Exception("Es wurde kein Sound gefunden...");
        }


        private static void PrintRegister(IDictionary<char, long> Registers)
        {
            foreach (var element in Registers)
            {
                Console.WriteLine(element.Key + ": " + element.Value);
            }
        }
    }
}
