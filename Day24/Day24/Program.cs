using System;
using System.IO;
using System.Collections.Generic;

namespace Day24
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
            string[] Input = File.ReadAllLines("../../Day24.txt");

            // Test
            //Input = null;
            //Input = new string[] { "0/2", "2/2", "2/3", "3/4", "3/5", "0/1", "10/1", "9/10" };

            List<(int, int)> Components = new List<(int, int)>();

            foreach (var element in Input)
            {
                Components.Add((Convert.ToInt32(element.Split('/')[0]), Convert.ToInt32(element.Split('/')[1])));
            }

            int StrongestBridge = GetMaxStrength(0, 0, Components);
            Console.WriteLine("Part1: " + StrongestBridge);
            // 1511
        }


        public static void Part2()
        {
            string[] Input = File.ReadAllLines("../../Day24.txt");

            // Test
            //Input = null;
            //Input = new string[] { "0/2", "2/2", "2/3", "3/4", "3/5", "0/1", "10/1", "9/10" };

            List<(int, int)> Components = new List<(int, int)>();

            foreach (var element in Input)
            {
                Components.Add((Convert.ToInt32(element.Split('/')[0]), Convert.ToInt32(element.Split('/')[1])));
            }

            (int, int) LongestBridge = GetMaxLength((0, 0), 0, Components);
            Console.WriteLine("Part2: " + LongestBridge.Item1);
            // 1471
        }


        private static int GetMaxStrength(int Bridge, int Ports, List<(int, int)> Components)
        {
            // Possible Followers getten
            List<(int, int)> PossibleFollowers = new List<(int, int)>();
            foreach (var element in Components)
            {
                if (element.Item1 == Ports || element.Item2 == Ports)
                {
                    PossibleFollowers.Add(element);
                }
            }

            // Wenn es keine gibt zurückgeben
            if (PossibleFollowers.Count == 0)
            {
                return Bridge;
            }

            List<int> Bridges = new List<int>();
            foreach (var element in PossibleFollowers)
            {
                int Strength = Bridge + element.Item1 + element.Item2;

                int NextPorts = Ports == element.Item1 ? element.Item2 : element.Item1;

                List<(int, int)> RemainingComponents = new List<(int, int)>(Components);
                RemainingComponents.Remove(element);

                Bridges.Add(GetMaxStrength(Strength, NextPorts, RemainingComponents));
            }

            // Stärkste Brücke finden
            int StrongestBridge = Bridges[0];
            for (int i = 1; i < Bridges.Count; i++)
            {
                if (Bridges[i] > StrongestBridge)
                {
                    StrongestBridge = Bridges[i];
                }
            }

            return StrongestBridge;
        }


        private static (int, int) GetMaxLength((int, int) Bridge, int Ports, List<(int, int)> Components)
        {
            // Possible Followers getten
            List<(int, int)> PossibleFollowers = new List<(int, int)>();
            foreach (var element in Components)
            {
                if (element.Item1 == Ports || element.Item2 == Ports)
                {
                    PossibleFollowers.Add(element);
                }
            }

            // Wenn es keine gibt zurückgeben
            if (PossibleFollowers.Count == 0)
            {
                return Bridge;
            }

            List<(int, int)> Bridges = new List<(int, int)>();
            foreach (var element in PossibleFollowers)
            {
                int Strength = Bridge.Item1 + element.Item1 + element.Item2;
                int Length = Bridge.Item2 + 1;

                int NextPorts = Ports == element.Item1 ? element.Item2 : element.Item1;

                List<(int, int)> RemainingComponents = new List<(int, int)>(Components);
                RemainingComponents.Remove(element);

                Bridges.Add(GetMaxLength((Strength, Length), NextPorts, RemainingComponents));
            }

            // Längste Brücke finden
            (int, int) LongestBridge = Bridges[0];
            for (int i = 1; i < Bridges.Count; i++)
            {
                if (Bridges[i].Item2 > LongestBridge.Item2)
                {
                    LongestBridge = Bridges[i];
                }
                else if (Bridges[i].Item2 == LongestBridge.Item2)
                {
                    if (Bridges[i].Item1 > LongestBridge.Item1)
                    {
                        LongestBridge = Bridges[i];
                    }
                }
            }

            return LongestBridge;
        }
    }
}
