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
            // Try to refactor
            long a = 1;
            long b = 0;
            long c = 0;
            long d = 0;
            long e = 0;
            long f = 0;
            long g = 0;
            long h = 0;

            // Backup
            //    b = 65;
            //    c = b;
            //    if (a != 0) { goto A; }
            //    goto B;
            //A:
            //    b *= 100;
            //    b -= -100000;
            //    c = b;
            //    c -= -17000;
            //B:
            //    f = 1;
            //    d = 2;
            //E:
            //    e = 2;
            //D:
            //    g = d;
            //    g *= e;
            //    g -= b;
            //    if (g != 0) { goto C; }
            //    f = 0;
            //C:
            //    e -= -1;
            //    g = e;
            //    g -= b;
            //    if (g != 0) { goto D; }
            //    d -= -1;
            //    g = d;
            //    g -= b;
            //    if (g != 0) { goto E; }
            //    if (f != 0) { goto F; }
            //    h -= -1;
            //F:
            //    g = b;
            //    g -= c;
            //    if (g != 0) { goto G; }
            //    goto H;
            //G:
            //    b -= -17;
            //    goto B;
            //H:
            //Console.WriteLine("Programm ist terminiert, h = " + h);

            // Backup2
            //b = 65;
            //c = b;
            //b *= 100;
            //b -= -100000;
            //c = b;
            //c -= -17000;
            //while (true)
            //{
            //    f = 1;
            //    d = 2;
            //    do
            //    {
            //        e = 2;
            //        do
            //        {
            //            g = d;
            //            g *= e;
            //            g -= b;
            //            if (g == 0)
            //            {
            //                f = 0;
            //            }
            //            e -= -1;
            //            g = e;
            //            g -= b;
            //        } while (g != 0);
            //        d -= -1;
            //        g = d;
            //        g -= b;
            //    } while (g != 0);
            //    if (f == 0)
            //    {
            //        h -= -1;
            //    }
            //    g = b;
            //    g -= c;
            //    if (g == 0)
            //    {
            //        throw new Exception("Program terminated: h = " + h);
            //    }
            //    b -= -17;
            //}


            // Backup3
            //b = 106500;
            //c = 123500;

            //while (true)
            //{
            //    f = 1;
            //    d = 2;

            //    do
            //    {
            //        e = 2;

            //        do
            //        {
            //            g = d;
            //            g *= e;
            //            g -= b;

            //            if (g == 0)
            //            {
            //                f = 0;
            //            }

            //            e++;
            //            g = e;
            //            g -= b;

            //        } while (g != 0);

            //        d++;
            //        g = d;
            //        g -= b;

            //    } while (g != 0);

            //    if (f == 0)
            //    {
            //        h++;
            //    }

            //    // 2. Program terminates when b - c == 0, when b == c
            //    g = b;
            //    g -= c;

            //    if (g == 0) // 1. Program terminates when g == 0
            //    {
            //        throw new Exception("Program terminated: h = " + h);
            //    }

            //    b -= -17;
            //}

            // Rework
            b = 106500;
            c = 123500;

            do
            {
                f = 1;
                d = 2;
                e = 2;

                for (d = 2; d < b; d++)
                {
                    if (b % d == 0)
                    {
                        f = 0;
                        break;
                    }
                }
                if (f == 0)
                {
                    h++;
                }
                g = b - c;
                b += 17;
            } while (g != 0);
            Console.WriteLine("Programm ist terminiert, h = " + h);
        }
    }
}
