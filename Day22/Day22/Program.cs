using System;
using System.IO;

namespace Day22
{
    class MainClass
    {
        public static void Main()
        {
            string[] Input = File.ReadAllLines("../../Day22.txt");

            Input = null;

            Input = new string[]
            {
            ".........",
            ".........",
            ".........",
            ".....#...",
            "...#.....",
            ".........",
            ".........",
            "........."
            };

            char[][] Grid = new char[Input.Length][];

            for (int i = 0; i < Grid.Length; i++)
            {
                Grid[i] = Input[i].ToCharArray();
            }

            Virus Test = new Virus(Grid);

            for (int j = 0; j < 10000; j++)
            {
                Test.Burst();
            }

            Test.Print();

            Console.Write("Amount of Infections: " + Test.Infections);
        }
    }
}
