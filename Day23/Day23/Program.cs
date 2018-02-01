using System;
using System.IO;
using System.Collections.Generic;

namespace Day23
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
            // Get input
            string[] Input = File.ReadAllLines("../../Day23.txt");
            string[][] Commands = new string[Input.Length][];

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

            int MulInvokes = 0;

            for (int i = 0; i < Commands.Length; i++)
            {
                switch (Commands[i][0])
                {
                    case "set":
                        if (int.TryParse(Commands[i][2], out var Trash00))
                        {
                            Registers[Commands[i][1][0]] = Convert.ToInt32(Commands[i][2]);
                        }
                        else
                        {
                            Registers[Commands[i][1][0]] = Registers[Commands[i][2][0]];
                        }
                        break;
                    case "sub":
                        if (int.TryParse(Commands[i][2], out var Trash01))
                        {
                            Registers[Commands[i][1][0]] -= Convert.ToInt32(Commands[i][2]);
                        }
                        else
                        {
                            Registers[Commands[i][1][0]] -= Registers[Commands[i][2][0]];
                        }
                        break;
                    case "mul":
                        if (int.TryParse(Commands[i][2], out var Trash02))
                        {
                            Registers[Commands[i][1][0]] *= Convert.ToInt32(Commands[i][2]);
                        }
                        else
                        {
                            Registers[Commands[i][1][0]] *= Registers[Commands[i][2][0]];
                        }

                        MulInvokes++;
                        break;
                    case "jnz":
                        // TODO möglicherweise funktionieren diese breaks nicht richtig
                        if (int.TryParse(Commands[i][1], out var Trash03))
                        {
                            if (Convert.ToInt32(Commands[i][1]) == 0)
                            {
                                break;
                            }
                        }
                        else
                        {
                            if (Registers[Commands[i][1][0]] == 0)
                            {
                                break;
                            }
                        }

                        if (int.TryParse(Commands[i][2], out var Trash04))
                        {
                            i += Convert.ToInt32(Commands[i][2]);
                        }
                        else
                        {
                            i += (int)Registers[Commands[i][2][0]]; // TODO mögliches Problem
                        }
                        i--;
                        break;
                    default:
                        throw new Exception("Unknown command: " + Commands[i][0]);
                }
            }

            Console.WriteLine("Amount of mul: " + MulInvokes);
            // 3969
        }


        public static void Part2()
        {
            // Get input
            string[] Input = File.ReadAllLines("../../Day23.txt");
            string[][] Commands = new string[Input.Length][];

            for (int i = 0; i < Input.Length; i++)
            {
                Commands[i] = Input[i].Split(' ');
            }

            // Set up registers
            IDictionary<char, long> Registers = new Dictionary<char, long>();
            Registers.Add('a', 1);
            Registers.Add('b', 0);
            Registers.Add('c', 0);
            Registers.Add('d', 0);
            Registers.Add('e', 0);
            Registers.Add('f', 0);
            Registers.Add('g', 0);
            Registers.Add('h', 0);

            int MulInvokes = 0;

            // Test
            long ChangeA = 0;
            long ChangeB = 0;
            long ChangeC = 0;
            long ChangeD = 0;
            long ChangeE = 0;
            long ChangeF = 0;
            long ChangeG = 0;
            long ChangeH = 0;

            int Counter = 0;

            for (int i = 0; i < Commands.Length; i++)
            {
                // delter g -1 e -1

                // debug
                Counter++;
                Console.WriteLine(i);
                Console.WriteLine("a: " + ChangeA);
                Console.WriteLine("b: " + ChangeB);
                Console.WriteLine("c: " + ChangeC);
                Console.WriteLine("d: " + ChangeD);
                Console.WriteLine("e: " + ChangeE);
                Console.WriteLine("f: " + ChangeF);
                Console.WriteLine("g: " + ChangeG);
                Console.WriteLine("h: " + ChangeH);

                if (Counter > 10000)
                {
                    string Interrupt = Console.ReadLine();
                    if(Interrupt == "exe")
                    {
                        i = 11;
                        Registers['e'] = 0;
                        Registers['g'] = -106499;
                    }

                    foreach(var element in Registers) {
                        Console.WriteLine(element.Key +": "+ element.Value);
                    }
                }

                ChangeA = Registers['a'];
                ChangeB = Registers['b'];
                ChangeC = Registers['c'];
                ChangeD = Registers['d'];
                ChangeE = Registers['e'];
                ChangeF = Registers['f'];
                ChangeG = Registers['g'];
                ChangeH = Registers['h'];

                switch (Commands[i][0])
                {
                    case "set":
                        if (int.TryParse(Commands[i][2], out var Trash00))
                        {
                            Registers[Commands[i][1][0]] = Convert.ToInt32(Commands[i][2]);
                        }
                        else
                        {
                            Registers[Commands[i][1][0]] = Registers[Commands[i][2][0]];
                        }
                        break;
                    case "sub":
                        if (int.TryParse(Commands[i][2], out var Trash01))
                        {
                            Registers[Commands[i][1][0]] -= Convert.ToInt32(Commands[i][2]);
                        }
                        else
                        {
                            Registers[Commands[i][1][0]] -= Registers[Commands[i][2][0]];
                        }
                        break;
                    case "mul":
                        if (int.TryParse(Commands[i][2], out var Trash02))
                        {
                            Registers[Commands[i][1][0]] *= Convert.ToInt32(Commands[i][2]);
                        }
                        else
                        {
                            Registers[Commands[i][1][0]] *= Registers[Commands[i][2][0]];
                        }

                        MulInvokes++;
                        break;
                    case "jnz":
                        // TODO möglicherweise funktionieren diese breaks nicht richtig
                        if (int.TryParse(Commands[i][1], out var Trash03))
                        {
                            if (Convert.ToInt32(Commands[i][1]) == 0)
                            {
                                break;
                            }
                        }
                        else
                        {
                            if (Registers[Commands[i][1][0]] == 0)
                            {
                                break;
                            }
                        }

                        if (int.TryParse(Commands[i][2], out var Trash04))
                        {
                            i += Convert.ToInt32(Commands[i][2]);
                        }
                        else
                        {
                            i += (int)Registers[Commands[i][2][0]]; // TODO mögliches Problem
                        }
                        i--;
                        break;
                    default:
                        throw new Exception("Unknown command: " + Commands[i][0]);
                }

                // debug
                ChangeA -= Registers['a'];
                ChangeB -= Registers['b'];
                ChangeC -= Registers['c'];
                ChangeD -= Registers['d'];
                ChangeE -= Registers['e'];
                ChangeF -= Registers['f'];
                ChangeG -= Registers['g'];
                ChangeH -= Registers['h'];
            }

            Console.WriteLine("Value of h: " + Registers['h']);
        }
    }
}
