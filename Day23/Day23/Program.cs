using System;
using System.IO;
using System.Collections.Generic;

namespace Day23
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            // Get input
            string[] Input = File.ReadAllLines("../../Day23.txt");
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
        }
    }
}
